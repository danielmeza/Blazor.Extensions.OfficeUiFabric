using Blazor.Extensions.MergeStyles;
using Blazor.OfficeUiFabric.Styling.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.OfficeUiFabric.Styling
{
    public class StylingEngine
    {
        public static Lazy<Theme> DefaultTheme = new Lazy<Theme>(() => 
        {
            var palette = new DefaultPalette();
            var semacticColors = palette.MakeSemanticColors(false, false);
            var theme = new Theme()
            {
                IsInverted = false,
                Palette = palette,
                Fonts = FontStyles.DefaultFontStyle,
                SemacticColors = semacticColors,
                DisableGlobalCalssNames = false,
                Typography = Typography.DefaultTypography
            };
            return theme;
        });
        /// <summary>
        ///  Checks for the `disableGlobalClassNames` property on the `theme` to determine if it should return `classNames`
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="classNames">The global class names that apply when the flag is false</param>
        /// <param name="theme">The theme to check the flag on</param>
        /// <returns></returns>
        public T GetBlobalClassNames<T>(T classNames, Theme theme)
            where T : StyleSet<T>, new()
        {
            if (theme.DisableGlobalCalssNames)
            {
                return new T();
            }

            return classNames;
        }

        public Theme CreateTheme(Theme theme, bool depComments = false)
        {
            throw new NotImplementedException();
        }

      
    }
}
