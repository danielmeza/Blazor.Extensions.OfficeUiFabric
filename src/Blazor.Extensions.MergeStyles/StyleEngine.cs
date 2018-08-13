using Blazor.Extensions.MergeStyles.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles
{
    public class StyleEngine
    {

        /// <summary>
        /// Combine a set of styles together (but does not register css classes).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">One or more stylesets to be merged (each param can also be falsy).</param>
        /// <returns></returns>
        public static T ConcatStyleSet<T>(params StyleSet<T>[] args)
            where T : StyleSet<T>, new()
        {
            var mergedSet = new T();
            var workingSubcomponentStyles = new Dictionary<string, List<object>>();
            foreach (var currentSet in args)
            {
                if (currentSet?.Any() == true || (currentSet?.IsBool == true && currentSet.Bolean.Value))
                {
                    foreach (var pair in currentSet)
                    {
                        var prop = pair.Key.properertyName;
                        if (prop == "SubComponentStyles")
                        {
                            // subcomponent styles - style functions or objects
                            var currentComponentStyles = (IDictionary<string, object>)pair.Value;
                            foreach (var subCompProp in currentComponentStyles)
                            {
                                if (workingSubcomponentStyles.ContainsKey(subCompProp.Key))
                                {
                                    workingSubcomponentStyles[subCompProp.Key].Add(currentComponentStyles[subCompProp.Key]);
                                }
                                else
                                {
                                    workingSubcomponentStyles[subCompProp.Key] = new List<object> { currentComponentStyles[subCompProp.Key] };
                                }
                            }
                            continue;
                        }

                        // the as any casts below is a workaround for ts 2.8.
                        // todo: remove cast to any in ts 2.9.
                        object value;
                        var currentValue = (Style)pair.Value;

                        if (!mergedSet.TryGetValue(pair.Key, out value))
                        {
                            ((IStyleSet<T>)mergedSet).AddStyle(prop, currentValue);
                        }
                        else if (value is Style mergedValue)
                        {
                            var styleSet = ((IStyleSet<T>)mergedSet);
                            var mvalues = mergedValue.IsArray ? mergedValue.Array : new[] { mergedValue };
                            var values = mvalues.Concat(currentValue.IsArray ? currentValue.Array : new[] { currentValue }).ToArray();
                            styleSet.AddStyle(prop, values);
                        }
                    }
                }
            }

            if (workingSubcomponentStyles.Any())
            {
                mergedSet.SubComponentStyles = new Dictionary<string, object>();
                var mergedSubStyles = mergedSet.SubComponentStyles;
                // now we process the subcomponent styles if there are any
                foreach (var subCompProp in workingSubcomponentStyles)
                {
                    var workinSet = workingSubcomponentStyles[subCompProp.Key];
                    Func<object, T> subComponentStyle = (styleProps) =>
                    {
                        var result = workinSet.Select(styleFunctionOrObject => styleFunctionOrObject is Func<object, T> function ? function(styleProps) : (T)styleFunctionOrObject).ToArray();
                        return ConcatStyleSet(result);
                    };

                    mergedSubStyles[subCompProp.Key] = subComponentStyle;
                }
            }
            return mergedSet;
        }

        /// <summary>
        /// Separates the classes and style objects. Any classes that are pre-registered
        /// args are auto expanded into objects.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task<(List<string>, List<Style>)> ExtractStyleParts(params Style[] args)
        {
            var classes = new List<string>();
            var objects = new List<Style>();
            var stylesheet = await Stylesheet.GetInstance();

            void _processArgs(params Style[] argsList)
            {
                foreach (var arg in argsList)
                {
                    if (arg != null)
                    {
                        if (arg.IsString)
                        {
                            if (arg.String.IndexOf(" ") >= 0)
                            {
                                _processArgs(arg.String.Split(' '));
                            }
                            else
                            {
                                Style[] styles;
                                if (stylesheet.TryGetStylesFromClassName(arg.String, out styles))
                                {
                                    _processArgs(styles);
                                }
                                else
                                {
                                    // Avoid adding the same class twice.
                                    if (classes.IndexOf(arg.String) == -1)
                                    {
                                        classes.Add(arg.String);
                                    }
                                }
                            }
                        }
                        else if (arg.IsArray)
                        {
                            _processArgs(arg.Array);
                        }
                        else
                        {
                            objects.Add(arg);
                        }

                    }
                }
            };

            _processArgs(args);
            return (classes, objects);
        }

        /// <summary>
        /// Concatination helper, which can merge class names together. Skips over falsey values.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task<string> MergeStyle(params Style[] args)
        {
            (List<string> classes, List<Style> objects) = await ExtractStyleParts(args);
            if (objects.Any())
            {
                classes.Add(await StylesheetUtil.StyleToClassName(objects.ToArray()));
            }
            return classes.Join(" ");
        }

        /// <summary>
        /// Registers keyframe definitions.
        /// </summary>
        /// <param name="timeline"></param>
        /// <returns></returns>
        public static string Keyframes(Keyframes timeline)
        {
            var stylesheet = Stylesheet.GetInstance().GetAwaiter().GetResult();
            var name = stylesheet.GetClassName();
            var rulesArray = new List<string>();
            foreach (var pair in timeline)
            {
                rulesArray.Add(pair.Key, "{", StylesheetUtil.SerializeRuleEntries(pair.Value).GetAwaiter().GetResult(), "}");
            }
            var rules = rulesArray.Join("");
            stylesheet.InsertRule($"@keyframes {name}{{{rules}}}", true);
            stylesheet.CacheClassName(name, rules, new Style[] { }, new string[] { "keyframes", rules });
            return name;
        }

        /// <summary>
        ///  Renders a given string and returns both html and css needed for the html.
        /// </summary>
        /// <param name="onRender">Function that returns a string</param>
        /// <param name="namespace">Optional namespace to prepend to css classnames to avoid collisions</param>
        /// <returns></returns>
        public static (string html, string css) RenderStatic(Func<string> onRender, string @namespace = null)
        {
            var stylesheet = Stylesheet.GetInstance().ConfigureAwait(false).GetAwaiter().GetResult();
            stylesheet.SetConfig(new StyleSheetConfig() { InjectionMode = InjectionMode.None, Namespace = @namespace });
            stylesheet.Reset();

            return (onRender(), stylesheet.GetRules());
        }

        public static T MergeStyleSets<T>(params StyleSet<T>[] styleSets)
            where T : StyleSet<T>, new()
        {
            var classNameSet = new T();
            var classMap = new Dictionary<string, string>();

            if (!styleSets.Any())
                return new T();

            var styleSet = styleSets[0];
            StyleSet<T> concatenatedStyleSet = styleSet;
            if (styleSets.Any())
            {
                concatenatedStyleSet = ConcatStyleSet(styleSets);
            }

            var registrations = new List<Registration>();
            foreach (var styleSetArea in concatenatedStyleSet)
            {
                var subCompKey = nameof(concatenatedStyleSet.SubComponentStyles);
                if (styleSetArea.Key.properertyName == subCompKey)
                {
                    classNameSet.SubComponentStyles = concatenatedStyleSet.ContainsKey(styleSetArea.Key) ? concatenatedStyleSet.SubComponentStyles : new Dictionary<string, object>();
                    continue;
                }

                var styles = (Style)styleSetArea.Value;
                (var classes, var objects) = ExtractStyleParts(styles).GetAwaiter().GetResult();

                var displayName = styleSetArea.Key.key;

                var registration = StylesheetUtil.StyleToRegistration(new Style { DisplayName = displayName }, objects.ToArray()).GetAwaiter().GetResult();

                registrations.Add(registration);
                if (registration != null)
                {
                    classMap[styleSetArea.Key.key] = registration.ClassName;
                    var value = classes.Concat(new string[] { registration.ClassName }).Join(" ");
                    ((IStyleSet<T>)classNameSet).AddStyle(styleSetArea.Key.properertyName, value);
                }
            }

            foreach (var registration in registrations)
            {
                if (registration != null)
                {
                    StylesheetUtil.ApplyRegistration(registration, classMap).GetAwaiter().GetResult();
                }
            }

            return classNameSet;

        }
    }
}
