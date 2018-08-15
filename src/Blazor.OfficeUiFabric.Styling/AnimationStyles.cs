

using Blazor.Extensions.MergeStyles;
using Newtonsoft.Json;
namespace Blazor.OfficeUiFabric.Styling
{

    /// <summary>
    /// All Fabric standard animations, exposed as json objects referencing predefined
    /// keyframes. These objects can be mixed in with other class definitions.
    /// </summary>
    public partial class AnimationStyles
    {
        [JsonProperty("fadeIn100", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style FadeIn100 { get; set; }

        [JsonProperty("fadeIn200", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style FadeIn200 { get; set; }

        [JsonProperty("fadeIn400", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style FadeIn400 { get; set; }

        [JsonProperty("fadeIn500", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style FadeIn500 { get; set; }

        [JsonProperty("fadeOut100", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style FadeOut100 { get; set; }

        [JsonProperty("fadeOut200", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style FadeOut200 { get; set; }

        [JsonProperty("fadeOut400", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style FadeOut400 { get; set; }

        [JsonProperty("fadeOut500", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style FadeOut500 { get; set; }

        [JsonProperty("rotate90deg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style Rotate90Deg { get; set; }

        [JsonProperty("rotateN90deg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style RotateN90Deg { get; set; }

        [JsonProperty("scaleDownIn100", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style ScaleDownIn100 { get; set; }

        [JsonProperty("scaleDownOut98", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style ScaleDownOut98 { get; set; }

        [JsonProperty("scaleUpIn100", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style ScaleUpIn100 { get; set; }

        [JsonProperty("scaleUpOut103", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style ScaleUpOut103 { get; set; }

        [JsonProperty("slideDownIn10", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideDownIn10 { get; set; }

        [JsonProperty("slideDownIn20", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideDownIn20 { get; set; }

        [JsonProperty("slideDownOut10", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideDownOut10 { get; set; }

        [JsonProperty("slideDownOut20", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideDownOut20 { get; set; }

        [JsonProperty("slideLeftIn10", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideLeftIn10 { get; set; }

        [JsonProperty("slideLeftIn20", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideLeftIn20 { get; set; }

        [JsonProperty("slideLeftIn40", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideLeftIn40 { get; set; }

        [JsonProperty("slideLeftIn400", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideLeftIn400 { get; set; }

        [JsonProperty("slideLeftOut10", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideLeftOut10 { get; set; }

        [JsonProperty("slideLeftOut20", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideLeftOut20 { get; set; }

        [JsonProperty("slideLeftOut40", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideLeftOut40 { get; set; }

        [JsonProperty("slideLeftOut400", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideLeftOut400 { get; set; }

        [JsonProperty("slideRightIn10", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideRightIn10 { get; set; }

        [JsonProperty("slideRightIn20", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideRightIn20 { get; set; }

        [JsonProperty("slideRightIn40", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideRightIn40 { get; set; }

        [JsonProperty("slideRightIn400", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideRightIn400 { get; set; }

        [JsonProperty("slideRightOut10", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideRightOut10 { get; set; }

        [JsonProperty("slideRightOut20", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideRightOut20 { get; set; }

        [JsonProperty("slideRightOut40", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideRightOut40 { get; set; }

        [JsonProperty("slideRightOut400", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideRightOut400 { get; set; }

        [JsonProperty("slideUpIn10", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideUpIn10 { get; set; }

        [JsonProperty("slideUpIn20", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideUpIn20 { get; set; }

        [JsonProperty("slideUpOut10", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideUpOut10 { get; set; }

        [JsonProperty("slideUpOut20", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style SlideUpOut20 { get; set; }
    }
}
