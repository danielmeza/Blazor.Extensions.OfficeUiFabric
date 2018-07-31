using Blazor.Extensions.MergeStyles.Extensions;
using Blazor.Extensions.MergeStyles.Transforms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles
{
    public class RuleSet : Dictionary<string, object>
    {
        public List<string> __order { get; set; } = new List<string>();

    }
    public partial class Registration
    {
        public Style[] Args { get; set; }
        public string ClassName { get; set; }
        public string Key { get; set; }
        public List<string> RulesToInsert { get; set; }



    }
    public static class StylesheetUtil
    {
        public static string DISPLAY_NAME = "displayName";

        public static string GetDisplayName(Dictionary<string, object> rules)
        {
            object value = null;
            if (rules?.TryGetValue("&", out value) == true && value is RawStyle rootStyle)
            {
                return rootStyle?.DisplayName;
            }
            return null;
        }


        public static async Task<RuleSet> ExtractRules(Style[] args, RuleSet rules = null, string currentSelector = "&")
        {
            if (rules is null)
            {
                rules = new RuleSet();
            }
            var stylesheet = await Stylesheet.GetInstance();
            object value = null;

            Dictionary<string, object> currentRules;
            if (!rules.TryGetValue(currentSelector, out value))
            {
                currentRules = new Dictionary<string, object>();
                rules[currentSelector] = currentRules;
                rules.__order.Add(currentSelector);
            }
            else
            {
                currentRules = (Dictionary<string, object>)value;
            }


            foreach (var arg in args)
            {
                // If the arg is a string, we need to look up the class map and merge.
                if (arg?.IsString == true)
                {

                    Style[] expandedRules;
                    if (stylesheet.TryGetStylesFromClassName((string)arg, out expandedRules))
                    {
                        await ExtractRules(expandedRules, rules, currentSelector);
                    }
                    // Else if the arg is an array, we need to recurse in.
                }
                else if (arg?.IsArray == true)
                {
                    await ExtractRules(arg.Array, rules, currentSelector);
                }
                else if (arg != null)
                {
                    var type = arg.GetType();
                    // tslint:disable-next-line:no-any
                    foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | (BindingFlags.GetProperty & BindingFlags.SetProperty)))
                    {

                        if (!prop.CanWrite || prop.GetValue(arg) == null)
                            continue;

                        if (prop.Name == "Selectors")
                        {
                            var selectors = arg.Selectors;


                            foreach (var key in selectors.Keys)
                            {
                                var newSelector = key;
                                if (selectors.ContainsKey(newSelector))
                                {
                                    var selectorValue = selectors[newSelector];

                                    if (newSelector.IndexOf(":global(") == 0)
                                    {
                                        newSelector = newSelector.Replace(new Regex(@"/:global\(|\)$", RegexOptions.Compiled), "");
                                    }
                                    else if (newSelector.IndexOf("@media") == 0)
                                    {
                                        newSelector = newSelector + "{" + currentSelector;
                                    }
                                    else if (newSelector.IndexOf(":") == 0)
                                    {
                                        newSelector = currentSelector + newSelector;
                                    }
                                    else if (newSelector.IndexOf("&") < 0)
                                    {
                                        newSelector = currentSelector + " " + newSelector;
                                    }

                                    await ExtractRules(new Style[] { selectorValue }, rules, newSelector);
                                }
                            }
                        }
                        else
                        {
                            // Else, add the rule to the currentSelector.
                            if (prop.Name == "Margin" || prop.Name == "Padding")
                            {

                                // tslint:disable-next-line:no-any
                                expandQuads(currentRules, prop.Name.ToCamelCase(), prop.GetValue(arg)?.ToString());
                            }
                            else
                            {
                                // tslint:disable-next-line:no-any

                                currentRules[prop.Name.ToCamelCase()] = prop.GetValue(arg);
                            }
                        }
                    }
                }
            }

            return rules;
        }
        private static void expandQuads(Dictionary<string, object> currentRules, string name, string value)
        {
            var parts = value is string ? value.Split(" ") : new string[] { value };

            var partZero = parts.Length == 0 ? null : parts[0];

            var partOne = parts.Length > 1 ? parts[1] : null;

            var partTwo = parts.Length > 2 ? parts[2] : null;

            var partTree = parts.Length > 3 ? parts[3] : null;

            currentRules[name + "Top"] = partZero;

            currentRules[name + "Right"] = partOne ?? partZero;
            if (parts.Length > 2)
                currentRules[name + "Bottom"] = partTwo ?? partZero;
            currentRules[name + "Left"] = partTree ?? partOne ?? partZero;
        }

        private static async Task<string> serializeRuleEntries(IDictionary<string, object> ruleEntries)
        {
            if (ruleEntries?.Any() != true)
            {
                return "";
            }

            var allEntries = new List<CssValue>();

            foreach (var entry in ruleEntries.Keys)
            {
                object rule;

                if (entry is string str && str != DISPLAY_NAME && ruleEntries.TryGetValue(entry, out rule) && rule != null)
                {
                    allEntries.Add(str);
                    var entryValue = ruleEntries[entry];
                    CssValue value = new CssValue();
                    switch (entryValue)
                    {
                        case bool bo:
                            value = bo;
                            break;
                        case string strg:
                            value = strg;
                            break;
                        case null:

                            break;

                        default:
                            value = Convert.ToDouble(entryValue);
                            break;

                    }

                    allEntries.Add(value);
                }
            }
            var arrayRules = allEntries.ToArray();

            // Apply transforms.
            for (var i = 0; i < arrayRules.Length; i += 2)
            {
                TransformationsRules.KebabRules(arrayRules, i);
                TransformationsRules.ProvideUnits(arrayRules, i);
                await TransformationsRules.RtlifyRules(arrayRules, i);
                await TransformationsRules.RtlifyRules(arrayRules, i);
            }
            var rules = arrayRules.ToList();
            // Apply punctuation.
            for (var i = 1; i < arrayRules.Length; i += 4)
            {

                rules.Splice(i, 1, ":", arrayRules[i], ";");
            }

            return string.Join("", rules);
        }

        public static async Task<Registration> StyleToRegistration(params Style[] args)
        {
            var rules = await ExtractRules(args);
            string key = getKeyForRules(rules);

            if (key != null)
            {
                var stylesheet = await Stylesheet.GetInstance();
                var registration = new Registration
                {
                    ClassName = stylesheet.GetClassNameFromKey(key),
                    Key = key,
                    Args = args
                };

                if (registration.ClassName is null)
                {
                    registration.ClassName = stylesheet.GetClassName(GetDisplayName(rules));
                    var rulesToInsert = new List<string>();

                    foreach (var selector in rules.__order)
                    {
                        rulesToInsert.Add(selector);
                        rulesToInsert.Add(await serializeRuleEntries((Dictionary<string, object>)rules[selector]));
                    }
                    registration.RulesToInsert = rulesToInsert;
                }

                return registration;
            }
            return null;
        }

        private static string getKeyForRules(RuleSet rules)
        {
            var serialized = new List<object>();
            var hasProps = false;

            foreach (var selector in rules.__order)
            {
                serialized.Add(selector);
                var rulesForSelector = (IDictionary)rules[selector];

                foreach (var prop in rulesForSelector.Keys)
                {


                    object value = rulesForSelector[prop];


                    if (value != null)
                    {
                        hasProps = true;
                        serialized.Add(prop.ToString().ToCamelCase());
                        serialized.Add(value);
                    }
                }
            }

            return hasProps ? string.Join("", serialized) : null;
        }


        public static async Task ApplyRegistration(Registration registration, IDictionary<string, string> classMap = null)
        {
            var stylesheet = await Stylesheet.GetInstance();

            if (registration.RulesToInsert?.Any() == true)
            {
                // rulesToInsert is an ordered array of selector/rule pairs.
                for (var i = 0; i < registration.RulesToInsert.Count; i += 2)
                {
                    var rules = registration.RulesToInsert[i + 1];
                    if (!string.IsNullOrWhiteSpace(rules))
                    {
                        var selector = registration.RulesToInsert[i];

                        selector = Regex.Replace(selector, @"(&)|\$([\w-]+)\b", (m) =>
                         {

                             if (m.Captures.Any())
                             {
                                 return "." + registration.ClassName;
                             }
                             else if (m.Value != null)
                             {
                                 string value = null;
                                 return "." + ((classMap?.TryGetValue(m.Value, out value)) == true ? value : m.Value);
                             }
                             return "";
                         }, RegexOptions.Compiled);
                        // Fix selector using map.



                        // Insert. Note if a media query, we must close the query with a final bracket.
                        var processedRule = string.Format("{0}{1}{2}", selector, "{" + rules + "}", selector.IndexOf("@media") == 0 ? "}" : "");

                        stylesheet.InsertRule(processedRule);
                    }
                }
                stylesheet.CacheClassName(registration.ClassName, registration.Key, registration.Args, registration.RulesToInsert.ToArray());
            }
        }


        public static async Task<string> StyleToClassName(params Style[] args)
        {
            var registration = await StyleToRegistration(args);
            if (registration != null)
            {
                await ApplyRegistration(registration);
                return registration.ClassName;
            }

            return "";
        }


    }
}