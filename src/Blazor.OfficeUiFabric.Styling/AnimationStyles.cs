

using Blazor.Extensions.MergeStyles;
using Newtonsoft.Json;
using System;

namespace Blazor.OfficeUiFabric.Styling
{

    /// <summary>
    /// All Fabric standard animations, exposed as json objects referencing predefined
    /// keyframes. These objects can be mixed in with other class definitions.
    /// </summary>
    public partial class AnimationStyles
    {

        const string EASING_FUNCTION_1 = "cubic-bezier(.1,.9,.2,1)";

        const string EASING_FUNCTION_2 = "cubic-bezier(.1,.25,.75,.9)";

        const string DURATION_1 = "0.167s";
        const string DURATION_2 = "0.267s";
        const string DURATION_3 = "0.367s";
        const string DURATION_4 = "0.467s";

        static string FADE_IN = StyleEngine.Keyframes(new Keyframes
        {
            From = { Opacity = 0 },
            To = { Opacity = 1 }
        });
        static string FADE_OUT = StyleEngine.Keyframes(new Keyframes
        {
            From = { Opacity = 0 },
            To = { Opacity = 1 }
        });

        static string SLIDE_RIGHT_IN10 = _createSlideInX(-10);
        static string SLIDE_RIGHT_IN20 = _createSlideInX(-20);
        static string SLIDE_RIGHT_IN40 = _createSlideInX(-40);
        static string SLIDE_RIGHT_IN400 = _createSlideInX(-400);
        static string SLIDE_LEFT_IN10 = _createSlideInX(10);
        static string SLIDE_LEFT_IN20 = _createSlideInX(20);
        static string SLIDE_LEFT_IN40 = _createSlideInX(40);
        static string SLIDE_LEFT_IN400 = _createSlideInX(400);
        static string SLIDE_UP_IN10 = _createSlideInY(10);
        static string SLIDE_UP_IN20 = _createSlideInY(20);
        static string SLIDE_DOWN_IN10 = _createSlideInY(-10);
        static string SLIDE_DOWN_IN20 = _createSlideInY(-20);

        static string SLIDE_RIGHT_OUT10 = _createSlideOutX(10);
        static string SLIDE_RIGHT_OUT20 = _createSlideOutX(20);
        static string SLIDE_RIGHT_OUT40 = _createSlideOutX(40);
        static string SLIDE_RIGHT_OUT400 = _createSlideOutX(400);
        static string SLIDE_LEFT_OUT10 = _createSlideOutX(-10);
        static string SLIDE_LEFT_OUT20 = _createSlideOutX(-20);
        static string SLIDE_LEFT_OUT40 = _createSlideOutX(-40);
        static string SLIDE_LEFT_OUT400 = _createSlideOutX(-400);
        static string SLIDE_UP_OUT10 = _createSlideOutY(-10);
        static string SLIDE_UP_OUT20 = _createSlideOutY(-20);
        static string SLIDE_DOWN_OUT10 = _createSlideOutY(10);
        static string SLIDE_DOWN_OUT20 = _createSlideOutY(20);


        static string SCALE_UP100 = StyleEngine.Keyframes(new Keyframes
        {
            From = { Transform = "scale3d(.98,.98,1)" },
            To = { Transform = "scale3d(1,1,1)" }
        });

        static string SCALE_DOWN98 = StyleEngine.Keyframes(new Keyframes
        {
            From = { Transform = "scale3d(1,1,1)" },
            To = { Transform = "scale3d(.98,.98,1)" }
        });

        static string SCALE_DOWN100 = StyleEngine.Keyframes(new Keyframes
        {
            From = { Transform = "scale3d(1.03,1.03,1)" },
            To = { Transform = "scale3d(1,1,1)" }
        });

        static string SCALE_UP103 = StyleEngine.Keyframes(new Keyframes
        {
            From = { Transform = "scale3d(1,1,1)" },
            To = { Transform = "scale3d(1.03,1.03,1)" }
        });

        static string ROTATE90 = StyleEngine.Keyframes(new Keyframes
        {
            From = { Transform = "rotateZ(0deg)" },
            To = { Transform = "rotateZ(90deg)" }
        });

        static string ROTATE_N90 = StyleEngine.Keyframes(new Keyframes
        {
            From = { Transform = "rotateZ(0deg)" },
            To = { Transform = "rotateZ(-90deg)" }
        });

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


        [JsonProperty("rotate90deg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style Rotate90deg { get; set; }

        [JsonProperty("rotateN90deg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Style RotateN90deg { get; set; }

        public AnimationVariables AnimationVariables => lazyAnimationVariables.Value;

        static Lazy<AnimationVariables> lazyAnimationVariables = new Lazy<AnimationVariables>(() => new AnimationVariables
        {
            EaseFunction1 = EASING_FUNCTION_1,
            EaseFunction2 = EASING_FUNCTION_2,
            DurationValue1 = DURATION_1,
            DurationValue2 = DURATION_2,
            DurationValue3 = DURATION_3,
            DurationValue4 = DURATION_4
        });


        static Lazy<AnimationStyles> lazyAnimationStyles = new Lazy<AnimationStyles>(() => new AnimationStyles()
        {
            SlideRightIn10 = _createAnimation($"{FADE_IN},{SLIDE_RIGHT_IN10}", DURATION_3, EASING_FUNCTION_1),
            SlideRightIn20 = _createAnimation($"{ FADE_IN},{SLIDE_RIGHT_IN20}", DURATION_3, EASING_FUNCTION_1),
            SlideRightIn40 = _createAnimation($"{ FADE_IN},{SLIDE_RIGHT_IN40}", DURATION_3, EASING_FUNCTION_1),
            SlideRightIn400 = _createAnimation($"{ FADE_IN},{SLIDE_RIGHT_IN400}", DURATION_3, EASING_FUNCTION_1),
            SlideLeftIn10 = _createAnimation($"{ FADE_IN},{SLIDE_LEFT_IN10}", DURATION_3, EASING_FUNCTION_1),
            SlideLeftIn20 = _createAnimation($"{ FADE_IN},{SLIDE_LEFT_IN20}", DURATION_3, EASING_FUNCTION_1),
            SlideLeftIn40 = _createAnimation($"{ FADE_IN},{SLIDE_LEFT_IN40}", DURATION_3, EASING_FUNCTION_1),
            SlideLeftIn400 = _createAnimation($"{ FADE_IN},{SLIDE_LEFT_IN400}", DURATION_3, EASING_FUNCTION_1),
            SlideUpIn10 = _createAnimation($"{ FADE_IN},{SLIDE_UP_IN10}", DURATION_3, EASING_FUNCTION_1),
            SlideUpIn20 = _createAnimation($"{ FADE_IN},{SLIDE_UP_IN20}", DURATION_3, EASING_FUNCTION_1),
            SlideDownIn10 = _createAnimation($"{ FADE_IN},{SLIDE_DOWN_IN10}", DURATION_3, EASING_FUNCTION_1),
            SlideDownIn20 = _createAnimation($"{ FADE_IN},{SLIDE_DOWN_IN20}", DURATION_3, EASING_FUNCTION_1),

            SlideRightOut10 = _createAnimation($"{ FADE_OUT},{SLIDE_RIGHT_OUT10}", DURATION_3, EASING_FUNCTION_1),
            SlideRightOut20 = _createAnimation($"{ FADE_OUT},{SLIDE_RIGHT_OUT20}", DURATION_3, EASING_FUNCTION_1),
            SlideRightOut40 = _createAnimation($"{ FADE_OUT},{SLIDE_RIGHT_OUT40}", DURATION_3, EASING_FUNCTION_1),
            SlideRightOut400 = _createAnimation($"{ FADE_OUT},{SLIDE_RIGHT_OUT400}", DURATION_3, EASING_FUNCTION_1),
            SlideLeftOut10 = _createAnimation($"{ FADE_OUT},{SLIDE_LEFT_OUT10}", DURATION_3, EASING_FUNCTION_1),
            SlideLeftOut20 = _createAnimation($"{ FADE_OUT},{SLIDE_LEFT_OUT20}", DURATION_3, EASING_FUNCTION_1),
            SlideLeftOut40 = _createAnimation($"{ FADE_OUT},{SLIDE_LEFT_OUT40}", DURATION_3, EASING_FUNCTION_1),
            SlideLeftOut400 = _createAnimation($"{ FADE_OUT},{SLIDE_LEFT_OUT400}", DURATION_3, EASING_FUNCTION_1),
            SlideUpOut10 = _createAnimation($"{ FADE_OUT},{SLIDE_UP_OUT10}", DURATION_3, EASING_FUNCTION_1),
            SlideUpOut20 = _createAnimation($"{ FADE_OUT},{SLIDE_UP_OUT20}", DURATION_3, EASING_FUNCTION_1),
            SlideDownOut10 = _createAnimation($"{ FADE_OUT},{SLIDE_DOWN_OUT10}", DURATION_3, EASING_FUNCTION_1),
            SlideDownOut20 = _createAnimation($"{ FADE_OUT},{SLIDE_DOWN_OUT20}", DURATION_3, EASING_FUNCTION_1),

            ScaleUpIn100 = _createAnimation($"{ FADE_IN},{SCALE_UP100}", DURATION_3, EASING_FUNCTION_1),
            ScaleDownIn100 = _createAnimation($"{ FADE_IN},{SCALE_DOWN100}", DURATION_3, EASING_FUNCTION_1),
            ScaleUpOut103 = _createAnimation($"{ FADE_OUT},{SCALE_UP103}", DURATION_1, EASING_FUNCTION_2),
            ScaleDownOut98 = _createAnimation($"{ FADE_OUT},{SCALE_DOWN98}", DURATION_1, EASING_FUNCTION_2),

            FadeIn100 = _createAnimation(FADE_IN, DURATION_1, EASING_FUNCTION_2),
            FadeIn200 = _createAnimation(FADE_IN, DURATION_2, EASING_FUNCTION_2),
            FadeIn400 = _createAnimation(FADE_IN, DURATION_3, EASING_FUNCTION_2),
            FadeIn500 = _createAnimation(FADE_IN, DURATION_4, EASING_FUNCTION_2),

            FadeOut100 = _createAnimation(FADE_OUT, DURATION_1, EASING_FUNCTION_2),
            FadeOut200 = _createAnimation(FADE_OUT, DURATION_2, EASING_FUNCTION_2),
            FadeOut400 = _createAnimation(FADE_OUT, DURATION_3, EASING_FUNCTION_2),
            FadeOut500 = _createAnimation(FADE_OUT, DURATION_4, EASING_FUNCTION_2),

            Rotate90deg = _createAnimation(ROTATE90, "0.1s", EASING_FUNCTION_2),
            RotateN90deg = _createAnimation(ROTATE_N90, "0.1s", EASING_FUNCTION_2)

        });


        static Style _createAnimation(string animationName, string animationDuration, string animationTimingFunction)
        {
            return new Style
            {
                AnimationName = animationName,
                AnimationDirection = animationDuration,
                AnimationTimingFunction = animationTimingFunction,
                AnimationFillMode = AnimationFillMode.Both,
            };
        }

        static string _createSlideInX(int fromX)
        {
            return StyleEngine.Keyframes(new Keyframes
            {
                From = { Transform = $"translate3d({fromX}px,0,0)" },
                To = { Transform = "translate3d(0,0,0)" }
            });
        }

        static string _createSlideInY(int fromY)
        {
            return StyleEngine.Keyframes(new Keyframes
            {
                From = { Transform = $"translate3d(0,{fromY}px,0)" },
                To = { Transform = "translate3d(0,0,0)" }
            });
        }

        static string _createSlideOutX(int toX)
        {
            return StyleEngine.Keyframes(new Keyframes
            {
                From = { Transform = $"translate3d(0,0,0)" },
                To = { Transform = $"translate3d({toX}px,0,0)" }
            });
        }

        static string _createSlideOutY(int toY)
        {
            return StyleEngine.Keyframes(new Keyframes
            {
                From = { Transform = $"translate3d(0,0,0)" },
                To = { Transform = $"translate3d(0,{toY}px,0)" }
            });
        }


    }
}
