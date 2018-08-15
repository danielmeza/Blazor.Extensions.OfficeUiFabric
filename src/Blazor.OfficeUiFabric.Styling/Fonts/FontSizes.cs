using System;
using System.Collections.Generic;

namespace Blazor.OfficeUiFabric.Styling.Fonts
{
    public partial class FontSizes : Dictionary<string, string>
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Mega { get; set; }
        public string Small { get; set; }
        public string Tiny { get; set; }
        public string XLarge { get; set; }
        public string XSmall { get; set; }
        public string XxLarge { get; set; }
        public string XxxLarge { get; set; }
        public string MediumPlus { get; internal set; }
        public string SmallPlus { get; internal set; }
        public string Mini { get; internal set; }
        public string Icon { get; internal set; }
        public string SuperLarge { get; internal set; }

        public static Lazy<FontSizes> Default = new Lazy<FontSizes>(() => new FontSizes()
        {
            Tiny = "1rem",
            XSmall = "1.2rem",
            Small = "1.3rem",
            Medium = "1.4rem",
            Large = "1.6rem",
            XLarge = "1.8rem",
            XxLarge = "2rem",
            XxxLarge = "3rem",
            Mega = "4rem"
        });
    }


}
