using Mono.WebAssembly;
using Mono.WebAssembly.Browser.DOM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.OfficeUiFabric.Styling
{

    public class Measurement
    {
        /// <summary>
        /// Count of style element injected, which is the slow operation in IE
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Total duration of all loadStyles exectionss
        /// </summary>
        public long Duration { get; set; }

    }


    public class RunState
    {
        public RunState()
        {
            this.Buffer = new List<List<ThemingEngine>>();
        }
        Mode Mode { get; set; }
        List<List<ThemingEngine>> Buffer { get; set; }
        int FlushTimer { get; set; }
    }

    internal enum Mode
    {
        Sync,
        Async
    }

    internal enum ClearStyleOptions
    {
        OnlyThemable = 1,
        OnlyNonThemable = 2,
        All = 3
    }

    public class ThemeState
    {
        public ThemeState()
        {
            this.RegisteredStyles = new List<StyleRecord>();
            this.RegisteredThemableStyles = new List<StyleRecord>();
            this.RunState = new RunState();
            this.Performance = new Measurement();

        }
        public Dictionary<string, string> Theme { get; set; }

        public HTMLStyleElement LastStyleElement { get; set; }

        /// <summary>
        /// Records of already registered non-themable styles
        /// </summary>
        public ICollection<StyleRecord> RegisteredStyles { get; set; }

        /// <summary>
        /// Records of already registered themable styles
        /// </summary>
        public ICollection<StyleRecord> RegisteredThemableStyles { get; set; }

        public Measurement Performance { get; set; }

        public RunState RunState { get; set; }


    }

    public class ThemingInstruction
    {
        public string Theme { get; set; }
        public string DefaultValue { get; set; }
        public string RawString { get; set; }
    }

    public class StyleRecord
    {
        public Element StyleElement { get; set; }

        public ICollection<ThemingInstruction> ThemableStyle { get; set; }
    }

    public class LoadThemeStyle
    {
        /// <summary>
        /// Matches theming tokens. For example, "[theme: themeSlotName, default: #FFF]" (including the quotes).
        /// </summary>
        const string _themeTokenRegex = @"[\'\""]\[theme:\s*(\w+)\s*(?:\,\s*default:\s*([\\""\']?[\.\,\(\)\#\-\s\w]*[\.\,\(\)\#\-\w][\""\']?))?\s*\][\'\""]";

        /// <summary>
        /// Maximum style text length, for supporting IE style restrictions.
        /// </summary>
        const int MAX_STYLE_CONTENT_SIZE = 10000;

        Lazy<ThemeState> lazyThemeState = new Lazy<ThemeState>(() => new ThemeState());
        ThemeState themeState => this.lazyThemeState.Value;

        bool _injectStylesWithCssText;

        void bool shouldUseCssText()
        {
            var useCSSText = false;


            var emptyStyle = HTMLPage.Document.CreateElement<HTMLStyleElement>();

            emptyStyle.Type = "text/css";
            var useCssText = emptyStyle.GetAttribute("styleSheet");
            ;


            return useCSSText;
        }

        void registerStyle(ICollection<ThemingInstruction> styleArray)
        {
            var document = HTMLPage.Document;
            var head = document.GetElementsByTagName("head")[0];
            var styleElement = document.CreateElement<HTMLStyleElement>();

            (string styleString, bool themable) = resolveThemableArray(styleArray);

            styleElement.Type = "text/css";

            styleElement.AppendChild(document.CreateTextNode(styleString));
            this.themeState.Performance.Count++;
            head.AppendChild(styleElement);

            var record = new StyleRecord()
            {
                StyleElement = styleElement,
                ThemableStyle = styleArray,
            };
            if (themable)
            {
                this.themeState.RegisteredThemableStyles.Add(record);
            }
            else
            {
                this.themeState.RegisteredStyles.Add(record);
            }
        }

        (string styleString, bool themable) resolveThemableArray(IEnumerable<ThemingInstruction> splitStyleArray)
        {
            var theme = this.themeState.Theme;
            var themable = false;
            var resolvedArray = splitStyleArray.Select(currentValue =>
           {
               var themeSlot = currentValue.Theme;
               if (!string.IsNullOrWhiteSpace(themeSlot))
               {
                   themable = true;
                   var themedValue = theme.Any() ? theme[themeSlot] : null;
                   var defaultValue = currentValue.DefaultValue ?? "inherit";
                   return themedValue ?? defaultValue;
               }
               else
               {
                   return currentValue.RawString;
               }
           });

            return (resolvedArray.Join(""), themable);
        }

        private void Measure(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            this.themeState.Performance.Duration += stopwatch.ElapsedMilliseconds;
        }
    }
}