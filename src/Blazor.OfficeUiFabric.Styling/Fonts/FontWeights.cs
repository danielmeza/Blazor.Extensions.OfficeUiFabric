using Blazor.Extensions.MergeStyles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.OfficeUiFabric.Styling.Fonts
{

    public partial class FontWeights : ReadOnlyDictionary<string, FontWeight>
    {
        private FontWeight bold;
        private FontWeight light;
        private FontWeight regular;
        private FontWeight semibold;
        private FontWeight semiLight;

        public FontWeights() : base(new Dictionary<string, FontWeight>())
        {

        }

        protected void SetProperty(in FontWeight value, [CallerMemberName]string propertyName = null)
        {
            this.Dictionary[propertyName] = value;
        }

        public FontWeight Bold { get => this.bold; set => this.bold = value; }
        public FontWeight Light { get => this.light; set => this.light = value; }
        public FontWeight Regular { get => this.regular; set => this.regular = value; }
        public FontWeight SemiBold { get => this.semibold; set => this.semibold = value; }
        public FontWeight SemiLight { get => this.semiLight; set => this.semiLight = value; }


    }
}
