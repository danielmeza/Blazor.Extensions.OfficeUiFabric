using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles
{
    public static partial class Serialize
    {
        public static string ToJson(this CssRule self) => JsonConvert.SerializeObject(self, Blazor.Extensions.MergeStyles.Converter.Settings);
        public static string ToJson(this string self) => JsonConvert.SerializeObject(self, Blazor.Extensions.MergeStyles.Converter.Settings);
        public static string ToJson(this object self) => JsonConvert.SerializeObject(self, Blazor.Extensions.MergeStyles.Converter.Settings);
        public static string ToJson(this IRawFontStyle self) => JsonConvert.SerializeObject(self, Blazor.Extensions.MergeStyles.Converter.Settings);
        public static string ToJson(this IFontFace self) => JsonConvert.SerializeObject(self, Blazor.Extensions.MergeStyles.Converter.Settings);
        public static string ToJson(this RawStyleBase self) => JsonConvert.SerializeObject(self, Blazor.Extensions.MergeStyles.Converter.Settings);
    }
}
