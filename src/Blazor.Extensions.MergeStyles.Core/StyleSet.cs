using Blazor.Extensions.MergeStyles.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles
{
    public class StyleSet<T> : ReadOnlyDictionary<(string key, string properertyName), object>, IStyleSet<T>
        where T : StyleSet<T>
    {
        Type type;
        private Dictionary<string, object> subComponentStyles;
        private Style root;
        private Style child;

        public StyleSet() : base(new Dictionary<(string key, string properertyName), object>())
        {
            this.type = this.GetType();
        }

        protected bool SetProperty<TValue>(ref TValue field, TValue value, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName) || EqualityComparer<TValue>.Default.Equals(field, value))
                return false;

            field = value;
            var key = (propertyName.Kebab(), propertyName);
            //Remove the value if default
            if (value == default && this.Dictionary.ContainsKey(key))
            {
                this.Dictionary.Remove(key);
            }
            //add or update the new value
            else
            {
                this.Dictionary.AddOrUpdate(key, value);
            }
            return true;

        }

        public bool? Bolean { get; internal set; }

        public bool IsBool => this.Bolean.HasValue;

        public static implicit operator StyleSet<T>(bool value) => new StyleSet<T>() { Bolean = value };

        public static explicit operator bool(StyleSet<T> value) => value.IsBool ? value.Bolean.Value : throw new InvalidCastException("The style set is not a boolean value");

        public Style Root { get => this.root; set => SetProperty(ref this.root, value); }

        public Style Child { get => this.child; set => SetProperty(ref this.child, value); }

        [JsonProperty("SubComponentStyles")]
        public Dictionary<string, object> SubComponentStyles
        {
            get
            {
                if (this.subComponentStyles == null)
                {
                    var subComponentStyles = new Dictionary<string, object>();
                    SetProperty(ref this.subComponentStyles, subComponentStyles);
                }
                return this.subComponentStyles;
            }
            set
            {
                SetProperty(ref this.subComponentStyles, value);
            }
        }

        Dictionary<string, object> IStyleSet<T>.SubComponentStyles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool Equals(object obj)
        {
            if (!(obj is StyleSet<T> style))
                return false;
            if (this.Dictionary.AreEquals(style.Dictionary))
                return true;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        void IStyleSet<T>.AddStyle(string key, Style style)
        {
            var prop = this.GetType().GetProperty(key);
            prop?.SetValue(this, style);
        }


    }
}
