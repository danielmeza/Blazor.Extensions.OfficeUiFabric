using Blazor.Extensions.MergeStyles;
using Blazor.OfficeUiFabric.Styling.Fonts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.OfficeUiFabric.Styling.Fonts
{
    public partial class FontStyles
    {
        public RawStyle Large { get; set; }
        public RawStyle Medium { get; set; }
        public RawStyle MediumPlus { get; set; }
        public RawStyle Mega { get; set; }
        public RawStyle Small { get; set; }
        public RawStyle SmallPlus { get; set; }
        public RawStyle SuperLarge { get; set; }
        public RawStyle Tiny { get; set; }
        public RawStyle XLarge { get; set; }
        public RawStyle XSmall { get; set; }
        public RawStyle XxLarge { get; set; }

        public static FontStyles DefaultFontStyle => lazyDefaultFontStyle.Value;

        static Lazy<FontStyles> lazyDefaultFontStyle = new Lazy<FontStyles>(()
            => FontEngine.CreateFontStyles(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName));


    }


}
