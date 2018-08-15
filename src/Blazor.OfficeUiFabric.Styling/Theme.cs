using Blazor.OfficeUiFabric.Styling.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.OfficeUiFabric.Styling
{
    public class Theme
    {
        public Palette Palette { get; set; }

        public FontStyles Fonts { get; set; }

        public SemanticColors SemacticColors { get; set; }

        /// <summary>
        /// This setting is for a very narrow use case and you probably don't need to worry about,
        /// unless you share a environment with others that also use fabric.
        /// It is used for disabling global styles on fabric components.This will prevent global
        /// overrides that might have been set by other fabric users from applying to your components.
        /// When you set this setting to `true` on your theme the components in the subtree of your
        /// Customizer will not get the global styles applied to them.
        /// </summary>
        public bool DisableGlobalCalssNames { get; set; }

        /// <summary>
        /// @internal
        /// The typography property is still in an experimental phase.The intent is the have it
        /// eventually replace IFontStyles in a future release, but it is still undergoing review.
        /// Avoid using it until it is finalized.
        /// </summary>
        public Typography Typography { get; set; }
        public bool IsInverted { get; internal set; }
    }
}
