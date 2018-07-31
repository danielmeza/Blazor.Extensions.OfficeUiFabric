// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do one of these:
//
//    using Blazor.Extensions.MergeStyles;
//
//    var iRawStyle = IRawStyle.FromJson(jsonString);
//    var iStyleBase = IStyleBase.FromJson(jsonString);

namespace Blazor.Extensions.MergeStyles
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;


    public class Style : RawStyle
    {
        public Style()
        {

        }

        public Style(Style[] styles)
        {
            this.Array = styles;
        }
        public Style[] Array { get; internal set; }

        public bool IsArray => this.Array != null;

        public static implicit operator Style(Style[] values) => new Style() { Array = values };

        public static implicit operator Style(string value) => new Style() { String = value };

        public static implicit operator Style(bool value) => new Style() { Bool = value };

        public static implicit operator Style(int value) => new Style() { Numnber = value };

        public static explicit operator string(Style style) => style.String;



        public static explicit operator int(Style style) => style.Numnber ?? throw new InvalidCastException("The style is not a number value");
        public static explicit operator bool(Style style) => style.Bool ?? throw new InvalidCastException("The style is not a boolean value");



        public override bool Equals(object obj)
        {
            if (!(obj is Style style))
                return false;
            if (this.IsArray)
                return this.Array == style.Array;
            if (style.IsNumber)
                return this.Numnber == style.Numnber;
            if (style.IsString)
                return this.String == style.String;
            if (style.IsBool)
                return this.Bool == style.Bool;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            if (this.IsArray)
                return this.Array.GetHashCode();
            if (this.IsNumber)
                return this.Numnber.Value.GetHashCode();
            if (this.IsString)
                return this.String.GetHashCode();
            if (this.IsBool)
                return this.Bool.Value.GetHashCode();

            return this.GetHashCode();
        }


    }

    /// <summary>
    /// IStyleObject extends a raw style objects, but allows selectors to be defined
    /// under the selectors node.
    /// </summary>
    public partial class RawStyle : IRawStyleBase
    {
        public RawStyle()
        {

        }


        public bool IsString => this.String != null;
        public bool IsNumber => this.Numnber.HasValue;
        public bool IsBool => this.Bool.HasValue;
        public string String { get; internal set; }
        public bool? Bool { get; internal set; }
        public int? Numnber { get; internal set; }
        public bool IsNull => this.Bool is null && this.Numnber is null && this.String is null;
        /// <summary>
        /// Display name for the style.
        /// </summary>
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Custom selectors for the style.
        /// </summary>

        public IDictionary<string, Style> Selectors { get; set; } = new Dictionary<string, Style>();



    };





    public class IStyleBase
    {
        public static object FromJson(string json) => JsonConvert.DeserializeObject<object>(json, Blazor.Extensions.MergeStyles.Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this Style self) => JsonConvert.SerializeObject(self, Blazor.Extensions.MergeStyles.Converter.Settings);
    }


    internal class IStyleBaseUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Style);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new Style { };
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new Style { Bool = boolValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Style { String = stringValue };
                case JsonToken.StartObject:
                    return serializer.Deserialize<Style>(reader);
            }
            throw new Exception("Cannot unmarshal type IStyleBaseUnion");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var @object = (Style)value;
            if (@object.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (@object.Bool != null)
            {
                serializer.Serialize(writer, @object.Bool.Value);
                return;
            }
            if (@object.String != null)
            {
                serializer.Serialize(writer, @object.String);
                return;
            }

            if (@object.Numnber != null)
            {
                serializer.Serialize(writer, @object.Numnber);
                return;
            }

            if (value != null)
            {
                serializer.Serialize(writer, @object);
                return;
            }
            throw new Exception("Cannot marshal type IStyleBaseUnion");
        }

        public static readonly IStyleBaseUnionConverter Singleton = new IStyleBaseUnionConverter();
    }
}
