using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles
{
    public struct CssValue : IComparable<string>, IComparable<double>, IComparable<bool>
    {


        public CssValue(double value)
        {
            this.Number = value;
            this.String = null;
            this.Bolean = null;
        }

        public CssValue(string value)
        {
            this.String = value;
            this.Number = null;
            this.Bolean = null;
        }

        public CssValue(bool value)
        {
            this.Bolean = value;
            this.Number = null;
            this.String = null;

        }

        public bool IsNumber => this.Number.HasValue;

        public bool IsBolean => this.Bolean.HasValue;

        public string String { get; internal set; }
        public bool? Bolean { get; internal set; }
        public double? Number { get; internal set; }

        public static implicit operator CssValue(in double value) => new CssValue(value);
        public static implicit operator CssValue(in string value) => new CssValue(value);
        public static implicit operator CssValue(in bool value) => new CssValue(value);
        public static implicit operator CssValue(in bool? value) => new CssValue { Bolean = value };
        public static explicit operator string(in CssValue rule) => rule.String;
        public static explicit operator double(in CssValue rule) => rule.Number ?? 0;
        public static explicit operator bool(in CssValue rule) => rule.Bolean.Value;
        public static explicit operator bool? (in CssValue rule) => rule.Bolean;

        public bool IsNull => this.String is null && this.Number is null && this.Bolean is null;

        public override bool Equals(object obj)
        {
            if (!(obj is CssValue other))
            {
                return false;
            }
            if (other.IsNumber)
                return other.Number == this.Number;
            else if (other.IsBolean)
                return other.Bolean == this.Bolean;

            return other.String == this.String;
        }

        public override int GetHashCode()
        {
            if (this.IsNumber)
                return this.Number.Value.GetHashCode();
            if (this.IsBolean)
                return this.Bolean.Value.GetHashCode();
            return (this.String.GetHashCode());
        }

        public int CompareTo(double other)
        {
            if (!this.Number.HasValue)
                return 1;

            return this.Number == other ? 0 : 1;
        }

        public int CompareTo(string other)
        {

            if (this.String != null)
                return 1;
            return this.String == other ? 0 : 1;
        }

        public static bool operator ==(CssValue rule, string value) => rule.String == value;
        public static bool operator !=(CssValue rule, string value) => rule.String != value;

        public static bool operator ==(CssValue rule1, CssValue rule2)
        {
            if (rule1.IsNull || rule2.IsNull)
                return false;
            return rule1.String == rule2.String || rule1.Number == rule2.Number;
        }

        public static bool operator !=(CssValue rule1, CssValue rule2)
        {
            if (rule1.IsNull || rule2.IsNull)
                return true;
            return rule1.String == rule2.String || rule1.Number == rule2.Number;
        }

        public override string ToString()
        {
            return this.Number?.ToString() ?? this.String ?? this.Bolean?.ToString();
        }


        public string Replace(string oldValue, string newValue)
        {
            if (this.String is null)
                throw new InvalidOperationException($"This rule is not a string, value {this}");
            return this.String.Replace(oldValue, newValue);
        }

        public int CompareTo(bool other)
        {
            if (!this.IsBolean)
                return 1;
            return this.Bolean == other ? 0 : 1;
        }
    }
}
