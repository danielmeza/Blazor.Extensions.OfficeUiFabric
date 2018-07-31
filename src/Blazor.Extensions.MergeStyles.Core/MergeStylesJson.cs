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
        public static string ToJson(this IRawStyleBase self) => JsonConvert.SerializeObject(self, Blazor.Extensions.MergeStyles.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                IcssRuleEnumConverter.Singleton,
                CssValueConverter.Singleton,
                IFontWeightUnionConverter.Singleton,
                IFontWeightEnumConverter.Singleton,
                FontSizeAdjustUnionConverter.Singleton,
                FontSizeAdjustEnumConverter.Singleton,
                FontStretchConverter.Singleton,
                FontStyleConverter.Singleton,
                FontSmoothingConverter.Singleton,
                WebkitOverflowScrollingConverter.Singleton,
                AlignContentConverter.Singleton,
                AlignItemsConverter.Singleton,
                AlignSelfConverter.Singleton,
                AnimationFillModeConverter.Singleton,
                BackgroundAttachmentConverter.Singleton,
                BackgroundClipConverter.Singleton,
                BoxSizingConverter.Singleton,
                ColumnCountUnionConverter.Singleton,
                ColumnCountEnumConverter.Singleton,
                FillOpacityConverter.Singleton,
                FlexDirectionConverter.Singleton,
                FlexWrapConverter.Singleton,
                JustifyContentConverter.Singleton,
                OverflowConverter.Singleton,
                OverflowWrapConverter.Singleton,
                PositionConverter.Singleton,
                ResizeConverter.Singleton,
                UserSelectConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class IcssRuleEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CssRule) || t == typeof(CssRule?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "inherit":
                    return CssRule.Inherit;
                case "initial":
                    return CssRule.Initial;
                case "unset":
                    return CssRule.Unset;
            }
            throw new Exception("Cannot unmarshal type IcssRuleEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CssRule)untypedValue;
            switch (value)
            {
                case CssRule.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case CssRule.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case CssRule.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type IcssRuleEnum");
        }

        public static readonly IcssRuleEnumConverter Singleton = new IcssRuleEnumConverter();
    }

    internal class CssValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CssValue) || t == typeof(CssValue?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new CssValue { Number = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new CssValue { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type CssValue");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (CssValue)untypedValue;
            if (value.Number != null)
            {
                serializer.Serialize(writer, value.Number.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if(value.IsBolean)
            {
                serializer.Serialize(writer, value.Bolean);
            }
            throw new Exception("Cannot marshal type CssValue");
        }

        public static readonly CssValueConverter Singleton = new CssValueConverter();
    }

    internal class IFontWeightUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IFontWeightUnion) || t == typeof(IFontWeightUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new IFontWeightUnion { Integer = integerValue };
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<decimal>(reader);
                    return new IFontWeightUnion { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "100":
                            return new IFontWeightUnion { Enum = FontWeight.The100 };
                        case "200":
                            return new IFontWeightUnion { Enum = FontWeight.The200 };
                        case "300":
                            return new IFontWeightUnion { Enum = FontWeight.The300 };
                        case "400":
                            return new IFontWeightUnion { Enum = FontWeight.The400 };
                        case "500":
                            return new IFontWeightUnion { Enum = FontWeight.The500 };
                        case "600":
                            return new IFontWeightUnion { Enum = FontWeight.The600 };
                        case "700":
                            return new IFontWeightUnion { Enum = FontWeight.The700 };
                        case "800":
                            return new IFontWeightUnion { Enum = FontWeight.The800 };
                        case "900":
                            return new IFontWeightUnion { Enum = FontWeight.The900 };
                        case "bold":
                            return new IFontWeightUnion { Enum = FontWeight.Bold };
                        case "bolder":
                            return new IFontWeightUnion { Enum = FontWeight.Bolder };
                        case "inherit":
                            return new IFontWeightUnion { Enum = FontWeight.Inherit };
                        case "initial":
                            return new IFontWeightUnion { Enum = FontWeight.Initial };
                        case "lighter":
                            return new IFontWeightUnion { Enum = FontWeight.Lighter };
                        case "normal":
                            return new IFontWeightUnion { Enum = FontWeight.Normal };
                        case "unset":
                            return new IFontWeightUnion { Enum = FontWeight.Unset };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type IFontWeightUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (IFontWeightUnion)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case FontWeight.The100:
                        serializer.Serialize(writer, "100");
                        return;
                    case FontWeight.The200:
                        serializer.Serialize(writer, "200");
                        return;
                    case FontWeight.The300:
                        serializer.Serialize(writer, "300");
                        return;
                    case FontWeight.The400:
                        serializer.Serialize(writer, "400");
                        return;
                    case FontWeight.The500:
                        serializer.Serialize(writer, "500");
                        return;
                    case FontWeight.The600:
                        serializer.Serialize(writer, "600");
                        return;
                    case FontWeight.The700:
                        serializer.Serialize(writer, "700");
                        return;
                    case FontWeight.The800:
                        serializer.Serialize(writer, "800");
                        return;
                    case FontWeight.The900:
                        serializer.Serialize(writer, "900");
                        return;
                    case FontWeight.Bold:
                        serializer.Serialize(writer, "bold");
                        return;
                    case FontWeight.Bolder:
                        serializer.Serialize(writer, "bolder");
                        return;
                    case FontWeight.Inherit:
                        serializer.Serialize(writer, "inherit");
                        return;
                    case FontWeight.Initial:
                        serializer.Serialize(writer, "initial");
                        return;
                    case FontWeight.Lighter:
                        serializer.Serialize(writer, "lighter");
                        return;
                    case FontWeight.Normal:
                        serializer.Serialize(writer, "normal");
                        return;
                    case FontWeight.Unset:
                        serializer.Serialize(writer, "unset");
                        return;
                }
            }
            throw new Exception("Cannot marshal type IFontWeightUnion");
        }

        public static readonly IFontWeightUnionConverter Singleton = new IFontWeightUnionConverter();
    }

    internal class IFontWeightEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FontWeight) || t == typeof(FontWeight?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "100":
                    return FontWeight.The100;
                case "200":
                    return FontWeight.The200;
                case "300":
                    return FontWeight.The300;
                case "400":
                    return FontWeight.The400;
                case "500":
                    return FontWeight.The500;
                case "600":
                    return FontWeight.The600;
                case "700":
                    return FontWeight.The700;
                case "800":
                    return FontWeight.The800;
                case "900":
                    return FontWeight.The900;
                case "bold":
                    return FontWeight.Bold;
                case "bolder":
                    return FontWeight.Bolder;
                case "inherit":
                    return FontWeight.Inherit;
                case "initial":
                    return FontWeight.Initial;
                case "lighter":
                    return FontWeight.Lighter;
                case "normal":
                    return FontWeight.Normal;
                case "unset":
                    return FontWeight.Unset;
            }
            throw new Exception("Cannot unmarshal type IFontWeightEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FontWeight)untypedValue;
            switch (value)
            {
                case FontWeight.The100:
                    serializer.Serialize(writer, "100");
                    return;
                case FontWeight.The200:
                    serializer.Serialize(writer, "200");
                    return;
                case FontWeight.The300:
                    serializer.Serialize(writer, "300");
                    return;
                case FontWeight.The400:
                    serializer.Serialize(writer, "400");
                    return;
                case FontWeight.The500:
                    serializer.Serialize(writer, "500");
                    return;
                case FontWeight.The600:
                    serializer.Serialize(writer, "600");
                    return;
                case FontWeight.The700:
                    serializer.Serialize(writer, "700");
                    return;
                case FontWeight.The800:
                    serializer.Serialize(writer, "800");
                    return;
                case FontWeight.The900:
                    serializer.Serialize(writer, "900");
                    return;
                case FontWeight.Bold:
                    serializer.Serialize(writer, "bold");
                    return;
                case FontWeight.Bolder:
                    serializer.Serialize(writer, "bolder");
                    return;
                case FontWeight.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case FontWeight.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case FontWeight.Lighter:
                    serializer.Serialize(writer, "lighter");
                    return;
                case FontWeight.Normal:
                    serializer.Serialize(writer, "normal");
                    return;
                case FontWeight.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type IFontWeightEnum");
        }

        public static readonly IFontWeightEnumConverter Singleton = new IFontWeightEnumConverter();
    }

    internal class FontSizeAdjustUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FontSizeAdjustUnion) || t == typeof(FontSizeAdjustUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<decimal>(reader);
                    return new FontSizeAdjustUnion { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "inherit":
                            return new FontSizeAdjustUnion { Enum = FontSizeAdjust.Inherit };
                        case "initial":
                            return new FontSizeAdjustUnion { Enum = FontSizeAdjust.Initial };
                        case "none":
                            return new FontSizeAdjustUnion { Enum = FontSizeAdjust.None };
                        case "unset":
                            return new FontSizeAdjustUnion { Enum = FontSizeAdjust.Unset };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type FontSizeAdjustUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (FontSizeAdjustUnion)untypedValue;
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case FontSizeAdjust.Inherit:
                        serializer.Serialize(writer, "inherit");
                        return;
                    case FontSizeAdjust.Initial:
                        serializer.Serialize(writer, "initial");
                        return;
                    case FontSizeAdjust.None:
                        serializer.Serialize(writer, "none");
                        return;
                    case FontSizeAdjust.Unset:
                        serializer.Serialize(writer, "unset");
                        return;
                }
            }
            throw new Exception("Cannot marshal type FontSizeAdjustUnion");
        }

        public static readonly FontSizeAdjustUnionConverter Singleton = new FontSizeAdjustUnionConverter();
    }

    internal class FontSizeAdjustEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FontSizeAdjust) || t == typeof(FontSizeAdjust?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "inherit":
                    return FontSizeAdjust.Inherit;
                case "initial":
                    return FontSizeAdjust.Initial;
                case "none":
                    return FontSizeAdjust.None;
                case "unset":
                    return FontSizeAdjust.Unset;
            }
            throw new Exception("Cannot unmarshal type FontSizeAdjustEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FontSizeAdjust)untypedValue;
            switch (value)
            {
                case FontSizeAdjust.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case FontSizeAdjust.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case FontSizeAdjust.None:
                    serializer.Serialize(writer, "none");
                    return;
                case FontSizeAdjust.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type FontSizeAdjustEnum");
        }

        public static readonly FontSizeAdjustEnumConverter Singleton = new FontSizeAdjustEnumConverter();
    }

    internal class FontStretchConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FontStretch) || t == typeof(FontStretch?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "condensed":
                    return FontStretch.Condensed;
                case "expanded":
                    return FontStretch.Expanded;
                case "extra-condensed":
                    return FontStretch.ExtraCondensed;
                case "extra-expanded":
                    return FontStretch.ExtraExpanded;
                case "inherit":
                    return FontStretch.Inherit;
                case "initial":
                    return FontStretch.Initial;
                case "normal":
                    return FontStretch.Normal;
                case "semi-condensed":
                    return FontStretch.SemiCondensed;
                case "semi-expanded":
                    return FontStretch.SemiExpanded;
                case "ultra-condensed":
                    return FontStretch.UltraCondensed;
                case "ultra-expanded":
                    return FontStretch.UltraExpanded;
                case "unset":
                    return FontStretch.Unset;
            }
            throw new Exception("Cannot unmarshal type FontStretch");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FontStretch)untypedValue;
            switch (value)
            {
                case FontStretch.Condensed:
                    serializer.Serialize(writer, "condensed");
                    return;
                case FontStretch.Expanded:
                    serializer.Serialize(writer, "expanded");
                    return;
                case FontStretch.ExtraCondensed:
                    serializer.Serialize(writer, "extra-condensed");
                    return;
                case FontStretch.ExtraExpanded:
                    serializer.Serialize(writer, "extra-expanded");
                    return;
                case FontStretch.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case FontStretch.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case FontStretch.Normal:
                    serializer.Serialize(writer, "normal");
                    return;
                case FontStretch.SemiCondensed:
                    serializer.Serialize(writer, "semi-condensed");
                    return;
                case FontStretch.SemiExpanded:
                    serializer.Serialize(writer, "semi-expanded");
                    return;
                case FontStretch.UltraCondensed:
                    serializer.Serialize(writer, "ultra-condensed");
                    return;
                case FontStretch.UltraExpanded:
                    serializer.Serialize(writer, "ultra-expanded");
                    return;
                case FontStretch.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type FontStretch");
        }

        public static readonly FontStretchConverter Singleton = new FontStretchConverter();
    }

    internal class FontStyleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FontStyle) || t == typeof(FontStyle?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "inherit":
                    return FontStyle.Inherit;
                case "initial":
                    return FontStyle.Initial;
                case "italic":
                    return FontStyle.Italic;
                case "normal":
                    return FontStyle.Normal;
                case "oblique":
                    return FontStyle.Oblique;
                case "unset":
                    return FontStyle.Unset;
            }
            throw new Exception("Cannot unmarshal type FontStyle");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FontStyle)untypedValue;
            switch (value)
            {
                case FontStyle.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case FontStyle.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case FontStyle.Italic:
                    serializer.Serialize(writer, "italic");
                    return;
                case FontStyle.Normal:
                    serializer.Serialize(writer, "normal");
                    return;
                case FontStyle.Oblique:
                    serializer.Serialize(writer, "oblique");
                    return;
                case FontStyle.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type FontStyle");
        }

        public static readonly FontStyleConverter Singleton = new FontStyleConverter();
    }

    internal class FontSmoothingConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FontSmoothing) || t == typeof(FontSmoothing?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "antialiased":
                    return FontSmoothing.Antialiased;
                case "grayscale":
                    return FontSmoothing.Grayscale;
                case "none":
                    return FontSmoothing.None;
                case "subpixel-antialiased":
                    return FontSmoothing.SubpixelAntialiased;
            }
            throw new Exception("Cannot unmarshal type FontSmoothing");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FontSmoothing)untypedValue;
            switch (value)
            {
                case FontSmoothing.Antialiased:
                    serializer.Serialize(writer, "antialiased");
                    return;
                case FontSmoothing.Grayscale:
                    serializer.Serialize(writer, "grayscale");
                    return;
                case FontSmoothing.None:
                    serializer.Serialize(writer, "none");
                    return;
                case FontSmoothing.SubpixelAntialiased:
                    serializer.Serialize(writer, "subpixel-antialiased");
                    return;
            }
            throw new Exception("Cannot marshal type FontSmoothing");
        }

        public static readonly FontSmoothingConverter Singleton = new FontSmoothingConverter();
    }

    internal class WebkitOverflowScrollingConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(WebkitOverflowScrolling) || t == typeof(WebkitOverflowScrolling?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "auto":
                    return WebkitOverflowScrolling.Auto;
                case "touch":
                    return WebkitOverflowScrolling.Touch;
            }
            throw new Exception("Cannot unmarshal type WebkitOverflowScrolling");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WebkitOverflowScrolling)untypedValue;
            switch (value)
            {
                case WebkitOverflowScrolling.Auto:
                    serializer.Serialize(writer, "auto");
                    return;
                case WebkitOverflowScrolling.Touch:
                    serializer.Serialize(writer, "touch");
                    return;
            }
            throw new Exception("Cannot marshal type WebkitOverflowScrolling");
        }

        public static readonly WebkitOverflowScrollingConverter Singleton = new WebkitOverflowScrollingConverter();
    }

    internal class AlignContentConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AlignContent) || t == typeof(AlignContent?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "center":
                    return AlignContent.Center;
                case "flex-end":
                    return AlignContent.FlexEnd;
                case "flex-start":
                    return AlignContent.FlexStart;
                case "inherit":
                    return AlignContent.Inherit;
                case "initial":
                    return AlignContent.Initial;
                case "space-around":
                    return AlignContent.SpaceAround;
                case "space-between":
                    return AlignContent.SpaceBetween;
                case "stretch":
                    return AlignContent.Stretch;
                case "unset":
                    return AlignContent.Unset;
            }
            throw new Exception("Cannot unmarshal type AlignContent");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AlignContent)untypedValue;
            switch (value)
            {
                case AlignContent.Center:
                    serializer.Serialize(writer, "center");
                    return;
                case AlignContent.FlexEnd:
                    serializer.Serialize(writer, "flex-end");
                    return;
                case AlignContent.FlexStart:
                    serializer.Serialize(writer, "flex-start");
                    return;
                case AlignContent.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case AlignContent.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case AlignContent.SpaceAround:
                    serializer.Serialize(writer, "space-around");
                    return;
                case AlignContent.SpaceBetween:
                    serializer.Serialize(writer, "space-between");
                    return;
                case AlignContent.Stretch:
                    serializer.Serialize(writer, "stretch");
                    return;
                case AlignContent.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type AlignContent");
        }

        public static readonly AlignContentConverter Singleton = new AlignContentConverter();
    }

    internal class AlignItemsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AlignItems) || t == typeof(AlignItems?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "baseline":
                    return AlignItems.Baseline;
                case "center":
                    return AlignItems.Center;
                case "flex-end":
                    return AlignItems.FlexEnd;
                case "flex-start":
                    return AlignItems.FlexStart;
                case "inherit":
                    return AlignItems.Inherit;
                case "initial":
                    return AlignItems.Initial;
                case "stretch":
                    return AlignItems.Stretch;
                case "unset":
                    return AlignItems.Unset;
            }
            throw new Exception("Cannot unmarshal type AlignItems");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AlignItems)untypedValue;
            switch (value)
            {
                case AlignItems.Baseline:
                    serializer.Serialize(writer, "baseline");
                    return;
                case AlignItems.Center:
                    serializer.Serialize(writer, "center");
                    return;
                case AlignItems.FlexEnd:
                    serializer.Serialize(writer, "flex-end");
                    return;
                case AlignItems.FlexStart:
                    serializer.Serialize(writer, "flex-start");
                    return;
                case AlignItems.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case AlignItems.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case AlignItems.Stretch:
                    serializer.Serialize(writer, "stretch");
                    return;
                case AlignItems.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type AlignItems");
        }

        public static readonly AlignItemsConverter Singleton = new AlignItemsConverter();
    }

    internal class AlignSelfConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AlignSelf) || t == typeof(AlignSelf?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "auto":
                    return AlignSelf.Auto;
                case "baseline":
                    return AlignSelf.Baseline;
                case "center":
                    return AlignSelf.Center;
                case "flex-end":
                    return AlignSelf.FlexEnd;
                case "flex-start":
                    return AlignSelf.FlexStart;
                case "inherit":
                    return AlignSelf.Inherit;
                case "initial":
                    return AlignSelf.Initial;
                case "stretch":
                    return AlignSelf.Stretch;
                case "unset":
                    return AlignSelf.Unset;
            }
            throw new Exception("Cannot unmarshal type AlignSelf");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AlignSelf)untypedValue;
            switch (value)
            {
                case AlignSelf.Auto:
                    serializer.Serialize(writer, "auto");
                    return;
                case AlignSelf.Baseline:
                    serializer.Serialize(writer, "baseline");
                    return;
                case AlignSelf.Center:
                    serializer.Serialize(writer, "center");
                    return;
                case AlignSelf.FlexEnd:
                    serializer.Serialize(writer, "flex-end");
                    return;
                case AlignSelf.FlexStart:
                    serializer.Serialize(writer, "flex-start");
                    return;
                case AlignSelf.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case AlignSelf.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case AlignSelf.Stretch:
                    serializer.Serialize(writer, "stretch");
                    return;
                case AlignSelf.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type AlignSelf");
        }

        public static readonly AlignSelfConverter Singleton = new AlignSelfConverter();
    }

    internal class AnimationFillModeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AnimationFillMode) || t == typeof(AnimationFillMode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "backwards":
                    return AnimationFillMode.Backwards;
                case "both":
                    return AnimationFillMode.Both;
                case "forwards":
                    return AnimationFillMode.Forwards;
                case "inherit":
                    return AnimationFillMode.Inherit;
                case "initial":
                    return AnimationFillMode.Initial;
                case "none":
                    return AnimationFillMode.None;
                case "unset":
                    return AnimationFillMode.Unset;
            }
            throw new Exception("Cannot unmarshal type AnimationFillMode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AnimationFillMode)untypedValue;
            switch (value)
            {
                case AnimationFillMode.Backwards:
                    serializer.Serialize(writer, "backwards");
                    return;
                case AnimationFillMode.Both:
                    serializer.Serialize(writer, "both");
                    return;
                case AnimationFillMode.Forwards:
                    serializer.Serialize(writer, "forwards");
                    return;
                case AnimationFillMode.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case AnimationFillMode.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case AnimationFillMode.None:
                    serializer.Serialize(writer, "none");
                    return;
                case AnimationFillMode.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type AnimationFillMode");
        }

        public static readonly AnimationFillModeConverter Singleton = new AnimationFillModeConverter();
    }

    internal class BackgroundAttachmentConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BackgroundAttachment) || t == typeof(BackgroundAttachment?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "fixed":
                    return BackgroundAttachment.Fixed;
                case "inherit":
                    return BackgroundAttachment.Inherit;
                case "initial":
                    return BackgroundAttachment.Initial;
                case "local":
                    return BackgroundAttachment.Local;
                case "scroll":
                    return BackgroundAttachment.Scroll;
                case "unset":
                    return BackgroundAttachment.Unset;
            }
            throw new Exception("Cannot unmarshal type BackgroundAttachment");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BackgroundAttachment)untypedValue;
            switch (value)
            {
                case BackgroundAttachment.Fixed:
                    serializer.Serialize(writer, "fixed");
                    return;
                case BackgroundAttachment.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case BackgroundAttachment.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case BackgroundAttachment.Local:
                    serializer.Serialize(writer, "local");
                    return;
                case BackgroundAttachment.Scroll:
                    serializer.Serialize(writer, "scroll");
                    return;
                case BackgroundAttachment.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type BackgroundAttachment");
        }

        public static readonly BackgroundAttachmentConverter Singleton = new BackgroundAttachmentConverter();
    }

    internal class BackgroundClipConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BackgroundClip) || t == typeof(BackgroundClip?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "border-box":
                    return BackgroundClip.BorderBox;
                case "content-box":
                    return BackgroundClip.ContentBox;
                case "inherit":
                    return BackgroundClip.Inherit;
                case "initial":
                    return BackgroundClip.Initial;
                case "padding-box":
                    return BackgroundClip.PaddingBox;
                case "text":
                    return BackgroundClip.Text;
                case "unset":
                    return BackgroundClip.Unset;
            }
            throw new Exception("Cannot unmarshal type BackgroundClip");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BackgroundClip)untypedValue;
            switch (value)
            {
                case BackgroundClip.BorderBox:
                    serializer.Serialize(writer, "border-box");
                    return;
                case BackgroundClip.ContentBox:
                    serializer.Serialize(writer, "content-box");
                    return;
                case BackgroundClip.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case BackgroundClip.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case BackgroundClip.PaddingBox:
                    serializer.Serialize(writer, "padding-box");
                    return;
                case BackgroundClip.Text:
                    serializer.Serialize(writer, "text");
                    return;
                case BackgroundClip.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type BackgroundClip");
        }

        public static readonly BackgroundClipConverter Singleton = new BackgroundClipConverter();
    }

    internal class BoxSizingConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BoxSizing) || t == typeof(BoxSizing?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "border-box":
                    return BoxSizing.BorderBox;
                case "content-box":
                    return BoxSizing.ContentBox;
                case "inherit":
                    return BoxSizing.Inherit;
                case "initial":
                    return BoxSizing.Initial;
                case "unset":
                    return BoxSizing.Unset;
            }
            throw new Exception("Cannot unmarshal type BoxSizing");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BoxSizing)untypedValue;
            switch (value)
            {
                case BoxSizing.BorderBox:
                    serializer.Serialize(writer, "border-box");
                    return;
                case BoxSizing.ContentBox:
                    serializer.Serialize(writer, "content-box");
                    return;
                case BoxSizing.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case BoxSizing.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case BoxSizing.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type BoxSizing");
        }

        public static readonly BoxSizingConverter Singleton = new BoxSizingConverter();
    }

    internal class ColumnCountUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ColumnCountUnion) || t == typeof(ColumnCountUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<decimal>(reader);
                    return new ColumnCountUnion { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "auto":
                            return new ColumnCountUnion { Enum = ColumnCount.Auto };
                        case "inherit":
                            return new ColumnCountUnion { Enum = ColumnCount.Inherit };
                        case "initial":
                            return new ColumnCountUnion { Enum = ColumnCount.Initial };
                        case "unset":
                            return new ColumnCountUnion { Enum = ColumnCount.Unset };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type ColumnCountUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ColumnCountUnion)untypedValue;
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case ColumnCount.Auto:
                        serializer.Serialize(writer, "auto");
                        return;
                    case ColumnCount.Inherit:
                        serializer.Serialize(writer, "inherit");
                        return;
                    case ColumnCount.Initial:
                        serializer.Serialize(writer, "initial");
                        return;
                    case ColumnCount.Unset:
                        serializer.Serialize(writer, "unset");
                        return;
                }
            }
            throw new Exception("Cannot marshal type ColumnCountUnion");
        }

        public static readonly ColumnCountUnionConverter Singleton = new ColumnCountUnionConverter();
    }

    internal class ColumnCountEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ColumnCount) || t == typeof(ColumnCount?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "auto":
                    return ColumnCount.Auto;
                case "inherit":
                    return ColumnCount.Inherit;
                case "initial":
                    return ColumnCount.Initial;
                case "unset":
                    return ColumnCount.Unset;
            }
            throw new Exception("Cannot unmarshal type ColumnCountEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ColumnCount)untypedValue;
            switch (value)
            {
                case ColumnCount.Auto:
                    serializer.Serialize(writer, "auto");
                    return;
                case ColumnCount.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case ColumnCount.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case ColumnCount.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type ColumnCountEnum");
        }

        public static readonly ColumnCountEnumConverter Singleton = new ColumnCountEnumConverter();
    }

    internal class FillOpacityConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FillOpacity) || t == typeof(FillOpacity?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<decimal>(reader);
                    return new FillOpacity { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "inherit":
                            return new FillOpacity { Enum = CssRule.Inherit };
                        case "initial":
                            return new FillOpacity { Enum = CssRule.Initial };
                        case "unset":
                            return new FillOpacity { Enum = CssRule.Unset };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type FillOpacity");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (FillOpacity)untypedValue;
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case CssRule.Inherit:
                        serializer.Serialize(writer, "inherit");
                        return;
                    case CssRule.Initial:
                        serializer.Serialize(writer, "initial");
                        return;
                    case CssRule.Unset:
                        serializer.Serialize(writer, "unset");
                        return;
                }
            }
            throw new Exception("Cannot marshal type FillOpacity");
        }

        public static readonly FillOpacityConverter Singleton = new FillOpacityConverter();
    }

    internal class FlexDirectionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FlexDirection) || t == typeof(FlexDirection?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "column":
                    return FlexDirection.Column;
                case "column-reverse":
                    return FlexDirection.ColumnReverse;
                case "inherit":
                    return FlexDirection.Inherit;
                case "initial":
                    return FlexDirection.Initial;
                case "row":
                    return FlexDirection.Row;
                case "row-reverse":
                    return FlexDirection.RowReverse;
                case "unset":
                    return FlexDirection.Unset;
            }
            throw new Exception("Cannot unmarshal type FlexDirection");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FlexDirection)untypedValue;
            switch (value)
            {
                case FlexDirection.Column:
                    serializer.Serialize(writer, "column");
                    return;
                case FlexDirection.ColumnReverse:
                    serializer.Serialize(writer, "column-reverse");
                    return;
                case FlexDirection.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case FlexDirection.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case FlexDirection.Row:
                    serializer.Serialize(writer, "row");
                    return;
                case FlexDirection.RowReverse:
                    serializer.Serialize(writer, "row-reverse");
                    return;
                case FlexDirection.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type FlexDirection");
        }

        public static readonly FlexDirectionConverter Singleton = new FlexDirectionConverter();
    }

    internal class FlexWrapConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FlexWrap) || t == typeof(FlexWrap?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "inherit":
                    return FlexWrap.Inherit;
                case "initial":
                    return FlexWrap.Initial;
                case "nowrap":
                    return FlexWrap.Nowrap;
                case "unset":
                    return FlexWrap.Unset;
                case "wrap":
                    return FlexWrap.Wrap;
                case "wrap-reverse":
                    return FlexWrap.WrapReverse;
            }
            throw new Exception("Cannot unmarshal type FlexWrap");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FlexWrap)untypedValue;
            switch (value)
            {
                case FlexWrap.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case FlexWrap.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case FlexWrap.Nowrap:
                    serializer.Serialize(writer, "nowrap");
                    return;
                case FlexWrap.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
                case FlexWrap.Wrap:
                    serializer.Serialize(writer, "wrap");
                    return;
                case FlexWrap.WrapReverse:
                    serializer.Serialize(writer, "wrap-reverse");
                    return;
            }
            throw new Exception("Cannot marshal type FlexWrap");
        }

        public static readonly FlexWrapConverter Singleton = new FlexWrapConverter();
    }

    internal class JustifyContentConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(JustifyContent) || t == typeof(JustifyContent?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "center":
                    return JustifyContent.Center;
                case "flex-end":
                    return JustifyContent.FlexEnd;
                case "flex-start":
                    return JustifyContent.FlexStart;
                case "inherit":
                    return JustifyContent.Inherit;
                case "initial":
                    return JustifyContent.Initial;
                case "space-around":
                    return JustifyContent.SpaceAround;
                case "space-between":
                    return JustifyContent.SpaceBetween;
                case "space-evenly":
                    return JustifyContent.SpaceEvenly;
                case "unset":
                    return JustifyContent.Unset;
            }
            throw new Exception("Cannot unmarshal type JustifyContent");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (JustifyContent)untypedValue;
            switch (value)
            {
                case JustifyContent.Center:
                    serializer.Serialize(writer, "center");
                    return;
                case JustifyContent.FlexEnd:
                    serializer.Serialize(writer, "flex-end");
                    return;
                case JustifyContent.FlexStart:
                    serializer.Serialize(writer, "flex-start");
                    return;
                case JustifyContent.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case JustifyContent.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case JustifyContent.SpaceAround:
                    serializer.Serialize(writer, "space-around");
                    return;
                case JustifyContent.SpaceBetween:
                    serializer.Serialize(writer, "space-between");
                    return;
                case JustifyContent.SpaceEvenly:
                    serializer.Serialize(writer, "space-evenly");
                    return;
                case JustifyContent.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type JustifyContent");
        }

        public static readonly JustifyContentConverter Singleton = new JustifyContentConverter();
    }

    internal class OverflowConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Overflow) || t == typeof(Overflow?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "auto":
                    return Overflow.Auto;
                case "hidden":
                    return Overflow.Hidden;
                case "inherit":
                    return Overflow.Inherit;
                case "initial":
                    return Overflow.Initial;
                case "scroll":
                    return Overflow.Scroll;
                case "unset":
                    return Overflow.Unset;
                case "visible":
                    return Overflow.Visible;
            }
            throw new Exception("Cannot unmarshal type Overflow");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Overflow)untypedValue;
            switch (value)
            {
                case Overflow.Auto:
                    serializer.Serialize(writer, "auto");
                    return;
                case Overflow.Hidden:
                    serializer.Serialize(writer, "hidden");
                    return;
                case Overflow.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case Overflow.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case Overflow.Scroll:
                    serializer.Serialize(writer, "scroll");
                    return;
                case Overflow.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
                case Overflow.Visible:
                    serializer.Serialize(writer, "visible");
                    return;
            }
            throw new Exception("Cannot marshal type Overflow");
        }

        public static readonly OverflowConverter Singleton = new OverflowConverter();
    }

    internal class OverflowWrapConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OverflowWrap) || t == typeof(OverflowWrap?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "break-word":
                    return OverflowWrap.BreakWord;
                case "inherit":
                    return OverflowWrap.Inherit;
                case "initial":
                    return OverflowWrap.Initial;
                case "normal":
                    return OverflowWrap.Normal;
                case "unset":
                    return OverflowWrap.Unset;
            }
            throw new Exception("Cannot unmarshal type OverflowWrap");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OverflowWrap)untypedValue;
            switch (value)
            {
                case OverflowWrap.BreakWord:
                    serializer.Serialize(writer, "break-word");
                    return;
                case OverflowWrap.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case OverflowWrap.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case OverflowWrap.Normal:
                    serializer.Serialize(writer, "normal");
                    return;
                case OverflowWrap.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type OverflowWrap");
        }

        public static readonly OverflowWrapConverter Singleton = new OverflowWrapConverter();
    }

    internal class PositionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Position) || t == typeof(Position?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "absolute":
                    return Position.Absolute;
                case "fixed":
                    return Position.Fixed;
                case "inherit":
                    return Position.Inherit;
                case "initial":
                    return Position.Initial;
                case "relative":
                    return Position.Relative;
                case "static":
                    return Position.Static;
                case "sticky":
                    return Position.Sticky;
                case "unset":
                    return Position.Unset;
            }
            throw new Exception("Cannot unmarshal type Position");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Position)untypedValue;
            switch (value)
            {
                case Position.Absolute:
                    serializer.Serialize(writer, "absolute");
                    return;
                case Position.Fixed:
                    serializer.Serialize(writer, "fixed");
                    return;
                case Position.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case Position.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case Position.Relative:
                    serializer.Serialize(writer, "relative");
                    return;
                case Position.Static:
                    serializer.Serialize(writer, "static");
                    return;
                case Position.Sticky:
                    serializer.Serialize(writer, "sticky");
                    return;
                case Position.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type Position");
        }

        public static readonly PositionConverter Singleton = new PositionConverter();
    }

    internal class ResizeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Resize) || t == typeof(Resize?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "block":
                    return Resize.Block;
                case "both":
                    return Resize.Both;
                case "horizontal":
                    return Resize.Horizontal;
                case "inherit":
                    return Resize.Inherit;
                case "initial":
                    return Resize.Initial;
                case "inline":
                    return Resize.Inline;
                case "none":
                    return Resize.None;
                case "unset":
                    return Resize.Unset;
                case "vertical":
                    return Resize.Vertical;
            }
            throw new Exception("Cannot unmarshal type Resize");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Resize)untypedValue;
            switch (value)
            {
                case Resize.Block:
                    serializer.Serialize(writer, "block");
                    return;
                case Resize.Both:
                    serializer.Serialize(writer, "both");
                    return;
                case Resize.Horizontal:
                    serializer.Serialize(writer, "horizontal");
                    return;
                case Resize.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case Resize.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case Resize.Inline:
                    serializer.Serialize(writer, "inline");
                    return;
                case Resize.None:
                    serializer.Serialize(writer, "none");
                    return;
                case Resize.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
                case Resize.Vertical:
                    serializer.Serialize(writer, "vertical");
                    return;
            }
            throw new Exception("Cannot marshal type Resize");
        }

        public static readonly ResizeConverter Singleton = new ResizeConverter();
    }

    internal class UserSelectConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(UserSelect) || t == typeof(UserSelect?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "all":
                    return UserSelect.All;
                case "auto":
                    return UserSelect.Auto;
                case "contain":
                    return UserSelect.Contain;
                case "inherit":
                    return UserSelect.Inherit;
                case "initial":
                    return UserSelect.Initial;
                case "none":
                    return UserSelect.None;
                case "text":
                    return UserSelect.Text;
                case "unset":
                    return UserSelect.Unset;
            }
            throw new Exception("Cannot unmarshal type UserSelect");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (UserSelect)untypedValue;
            switch (value)
            {
                case UserSelect.All:
                    serializer.Serialize(writer, "all");
                    return;
                case UserSelect.Auto:
                    serializer.Serialize(writer, "auto");
                    return;
                case UserSelect.Contain:
                    serializer.Serialize(writer, "contain");
                    return;
                case UserSelect.Inherit:
                    serializer.Serialize(writer, "inherit");
                    return;
                case UserSelect.Initial:
                    serializer.Serialize(writer, "initial");
                    return;
                case UserSelect.None:
                    serializer.Serialize(writer, "none");
                    return;
                case UserSelect.Text:
                    serializer.Serialize(writer, "text");
                    return;
                case UserSelect.Unset:
                    serializer.Serialize(writer, "unset");
                    return;
            }
            throw new Exception("Cannot marshal type UserSelect");
        }

        public static readonly UserSelectConverter Singleton = new UserSelectConverter();
    }
}
