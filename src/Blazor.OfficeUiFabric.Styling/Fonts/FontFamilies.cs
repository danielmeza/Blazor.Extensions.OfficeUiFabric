using System;
using System.Collections.Generic;

namespace Blazor.OfficeUiFabric.Styling.Fonts
{
    public partial class FontFamilies : Dictionary<string, string>
    {
        public string Default { get; set; }
        public string Monospace { get; set; }

        public static Lazy<FontFamilies> DefaultFontFamilies = new Lazy<FontFamilies>(() => new FontFamilies()
        {
            Default = "",
            Monospace = "Menlo, Monaco, \"Courier New\", monospace"
        });

    }


}
