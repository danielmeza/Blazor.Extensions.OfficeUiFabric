// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do one of these:
//
//    using Blazor.Extensions.MergeStyles;
//
//    var icssRule = IcssRule.FromJson(jsonString);
//    var icssPercentageRule = IcssPercentageRule.FromJson(jsonString);
//    var icssPixelUnitRule = IcssPixelUnitRule.FromJson(jsonString);
//    var iFontWeight = IFontWeight.FromJson(jsonString);
//    var iRawFontStyle = IRawFontStyle.FromJson(jsonString);
//    var iFontFace = IFontFace.FromJson(jsonString);
//    var iRawStyleBase = IRawStyleBase.FromJson(jsonString);

namespace Blazor.Extensions.MergeStyles
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// All raw style properties.
    /// </summary>
    public partial class IRawStyleBase
    {
        public static IRawStyleBase FromJson(string json) => JsonConvert.DeserializeObject<IRawStyleBase>(json, Blazor.Extensions.MergeStyles.Converter.Settings);

        /// <summary>
        /// Aligns a flex container's lines within the flex container when there is extra space
        /// in the cross-axis, similar to how justify-content aligns individual items within the
        /// main-axis.
        /// </summary>
        [JsonProperty("alignContent", NullValueHandling = NullValueHandling.Ignore)]
        public AlignContent? AlignContent { get; set; }

        /// <summary>
        /// Sets the default alignment in the cross axis for all of the flex container's items,
        /// including anonymous flex items, similarly to how justify-content aligns items along the
        /// main axis.
        /// </summary>
        [JsonProperty("alignItems", NullValueHandling = NullValueHandling.Ignore)]
        public AlignItems? AlignItems { get; set; }

        /// <summary>
        /// This property allows precise alignment of elements, such as graphics, that do not
        /// have a baseline-table or lack the desired baseline in their baseline-table. With the
        /// alignment-adjust property, the position of the baseline identified by the
        /// alignment-baseline can be explicitly determined. It also determines precisely
        /// the alignment point for each glyph within a textual element.
        /// </summary>
        [JsonProperty("alignmentAdjust", NullValueHandling = NullValueHandling.Ignore)]
        public string AlignmentAdjust { get; set; }

        /// <summary>
        /// Specifies how an object is aligned with respect to its parent. This property specifies
        /// which baseline of this element is to be aligned with the corresponding baseline of the
        /// parent. For example, this allows alphabetic baselines in Roman text to stay aligned
        /// across font size changes. It defaults to the baseline with the same name as the computed
        /// value of the alignment-baseline property.
        /// </summary>
        [JsonProperty("alignmentBaseline", NullValueHandling = NullValueHandling.Ignore)]
        public string AlignmentBaseline { get; set; }

        /// <summary>
        /// Allows the default alignment to be overridden for individual flex items.
        /// </summary>
        [JsonProperty("alignSelf", NullValueHandling = NullValueHandling.Ignore)]
        public AlignSelf? AlignSelf { get; set; }

        /// <summary>
        /// The animation CSS property is a shorthand property for the various animation properties:
        /// `animation-name`, `animation-duration`, `animation-timing-function`, `animation-delay`,
        /// `animation-iteration-count`, `animation-direction`, `animation-fill-mode`, and
        /// `animation-play-state`.
        /// </summary>
        [JsonProperty("animation", NullValueHandling = NullValueHandling.Ignore)]
        public string Animation { get; set; }

        /// <summary>
        /// Defines a length of time to elapse before an animation starts, allowing an animation to
        /// begin execution some time after it is applied.
        /// </summary>
        [JsonProperty("animationDelay", NullValueHandling = NullValueHandling.Ignore)]
        public string AnimationDelay { get; set; }

        /// <summary>
        /// Defines whether an animation should run in reverse on some or all cycles.
        /// </summary>
        [JsonProperty("animationDirection", NullValueHandling = NullValueHandling.Ignore)]
        public string AnimationDirection { get; set; }

        /// <summary>
        /// Specifies the length an animation takes to finish. Default value is 0, meaning
        /// there will be no animation.
        /// </summary>
        [JsonProperty("animationDuration", NullValueHandling = NullValueHandling.Ignore)]
        public string AnimationDuration { get; set; }

        /// <summary>
        /// The animation-fill-mode CSS property specifies how a CSS animation should apply
        /// styles to its target before and after its execution.
        /// </summary>
        [JsonProperty("animationFillMode", NullValueHandling = NullValueHandling.Ignore)]
        public AnimationFillMode? AnimationFillMode { get; set; }

        /// <summary>
        /// Specifies how many times an animation cycle should play.
        /// </summary>
        [JsonProperty("animationIterationCount", NullValueHandling = NullValueHandling.Ignore)]
        public string AnimationIterationCount { get; set; }

        /// <summary>
        /// Defines the list of animations that apply to the element.
        /// </summary>
        [JsonProperty("animationName", NullValueHandling = NullValueHandling.Ignore)]
        public string AnimationName { get; set; }

        /// <summary>
        /// Defines whether an animation is running or paused.
        /// </summary>
        [JsonProperty("animationPlayState", NullValueHandling = NullValueHandling.Ignore)]
        public string AnimationPlayState { get; set; }

        /// <summary>
        /// The animation-timing-function specifies the speed curve of an animation.
        /// </summary>
        [JsonProperty("animationTimingFunction", NullValueHandling = NullValueHandling.Ignore)]
        public string AnimationTimingFunction { get; set; }

        /// <summary>
        /// Allows changing the style of any element to platform-based interface elements or
        /// vice versa.
        /// </summary>
        [JsonProperty("appearance", NullValueHandling = NullValueHandling.Ignore)]
        public string Appearance { get; set; }

        /// <summary>
        /// Determines whether or not the “back” side of a transformed element is visible when
        /// facing the viewer.
        /// </summary>
        [JsonProperty("backfaceVisibility", NullValueHandling = NullValueHandling.Ignore)]
        public string BackfaceVisibility { get; set; }

        /// <summary>
        /// Shorthand property to set the values for one or more of:
        /// background-clip, background-color, background-image,
        /// background-origin, background-position, background-repeat,
        /// background-size, and background-attachment.
        /// </summary>
        [JsonProperty("background", NullValueHandling = NullValueHandling.Ignore)]
        public string Background { get; set; }

        /// <summary>
        /// If a background-image is specified, this property determines
        /// whether that image's position is fixed within the viewport,
        /// or scrolls along with its containing block.
        /// See CSS 3 background-attachment property
        /// https://drafts.csswg.org/css-backgrounds-3/#the-background-attachment
        /// </summary>
        [JsonProperty("backgroundAttachment", NullValueHandling = NullValueHandling.Ignore)]
        public BackgroundAttachment? BackgroundAttachment { get; set; }

        /// <summary>
        /// This property describes how the element's background images should blend with each
        /// other and the element's background color. The value is a list of blend modes that
        /// corresponds to each background image. Each element in the list will apply to the
        /// corresponding element of background-image. If a property doesn’t have enough
        /// comma-separated values to match the number of layers, the UA must calculate its
        /// used value by repeating the list of values until there are enough.
        /// </summary>
        [JsonProperty("backgroundBlendMode", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundBlendMode { get; set; }

        /// <summary>
        /// The background-clip CSS property specifies if an element's background, whether a
        /// <color> or an <image>, extends underneath its border.
        ///
        /// \* Does not work in IE
        ///
        /// \* The `text` value is experimental and should not be used in production code.
        /// </summary>
        [JsonProperty("backgroundClip", NullValueHandling = NullValueHandling.Ignore)]
        public BackgroundClip? BackgroundClip { get; set; }

        /// <summary>
        /// Sets the background color of an element.
        /// </summary>
        [JsonProperty("backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Sets a compositing style for background images and colors.
        /// </summary>
        [JsonProperty("backgroundComposite", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundComposite { get; set; }

        /// <summary>
        /// Applies one or more background images to an element. These can be any valid CSS
        /// image, including url() paths to image files or CSS gradients.
        /// </summary>
        [JsonProperty("backgroundImage", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundImage { get; set; }

        /// <summary>
        /// Specifies what the background-position property is relative to.
        /// </summary>
        [JsonProperty("backgroundOrigin", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundOrigin { get; set; }

        /// <summary>
        /// Sets the position of a background image.
        /// </summary>
        [JsonProperty("backgroundPosition", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundPosition { get; set; }

        /// <summary>
        /// Background-repeat defines if and how background images will be repeated after they
        /// have been sized and positioned
        /// </summary>
        [JsonProperty("backgroundRepeat", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundRepeat { get; set; }

        /// <summary>
        /// Sets the size of background images
        /// </summary>
        [JsonProperty("backgroundSize", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundSize { get; set; }

        /// <summary>
        /// Shorthand property that defines the different properties of all four sides of an
        /// element's border in a single declaration. It can be used to set border-width,
        /// border-style and border-color, or a subset of these.
        /// </summary>
        [JsonProperty("border", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Border { get; set; }

        /// <summary>
        /// Shorthand that sets the values of border-bottom-color,
        /// border-bottom-style, and border-bottom-width.
        /// </summary>
        [JsonProperty("borderBottom", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderBottom { get; set; }

        /// <summary>
        /// Sets the color of the bottom border of an element.
        /// </summary>
        [JsonProperty("borderBottomColor", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderBottomColor { get; set; }

        /// <summary>
        /// Defines the shape of the border of the bottom-left corner.
        /// </summary>
        [JsonProperty("borderBottomLeftRadius", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderBottomLeftRadius { get; set; }

        /// <summary>
        /// Defines the shape of the border of the bottom-right corner.
        /// </summary>
        [JsonProperty("borderBottomRightRadius", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderBottomRightRadius { get; set; }

        /// <summary>
        /// Sets the line style of the bottom border of a box.
        /// </summary>
        [JsonProperty("borderBottomStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderBottomStyle { get; set; }

        /// <summary>
        /// Sets the width of an element's bottom border. To set all four borders, use the
        /// border-width shorthand property which sets the values simultaneously for
        /// border-top-width, border-right-width, border-bottom-width, and border-left-width.
        /// </summary>
        [JsonProperty("borderBottomWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderBottomWidth { get; set; }

        /// <summary>
        /// Border-collapse can be used for collapsing the borders between table cells
        /// </summary>
        [JsonProperty("borderCollapse", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderCollapse { get; set; }

        /// <summary>
        /// The CSS border-color property sets the color of an element's four borders. This
        /// property can have from one to four values, made up of the elementary properties:
        /// •       border-top-color
        /// •       border-right-color
        /// •       border-bottom-color
        /// •       border-left-color The default color is the currentColor of each of
        /// these values.
        /// If you provide one value, it sets the color for the element. Two values set the
        /// horizontal and vertical values, respectively. Providing three values sets the top,
        /// vertical, and bottom values, in that order. Four values set all for sides: top,
        /// right, bottom, and left, in that order.
        /// </summary>
        [JsonProperty("borderColor", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderColor { get; set; }

        /// <summary>
        /// Specifies different corner clipping effects, such as scoop (inner curves), bevel
        /// (straight cuts) or notch (cut-off rectangles). Works along with border-radius to
        /// specify the size of each corner effect.
        /// </summary>
        [JsonProperty("borderCornerShape", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderCornerShape { get; set; }

        /// <summary>
        /// The property border-image-source is used to set the image to be used instead of
        /// the border style. If this is set to none the border-style is used instead.
        /// </summary>
        [JsonProperty("borderImageSource", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderImageSource { get; set; }

        /// <summary>
        /// The border-image-width CSS property defines the offset to use for dividing the
        /// border image in nine parts, the top-left corner, central top edge, top-right-corner,
        /// central right edge, bottom-right corner, central bottom edge, bottom-left corner,
        /// and central right edge. They represent inward distance from the top, right, bottom,
        /// and left edges.
        /// </summary>
        [JsonProperty("borderImageWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderImageWidth { get; set; }

        /// <summary>
        /// Shorthand property that defines the border-width, border-style and border-color of
        /// an element's left border in a single declaration. Note that you can use the
        /// corresponding longhand properties to set specific individual properties of the left
        /// border — border-left-width, border-left-style and border-left-color.
        /// </summary>
        [JsonProperty("borderLeft", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderLeft { get; set; }

        /// <summary>
        /// The CSS border-left-color property sets the color of an element's left border. This
        /// page explains the border-left-color value, but often you will find it more
        /// convenient to fix the border's left color as part of a shorthand set, either
        /// border-left or border-color. Colors can be defined several ways. For more
        /// information, see Usage.
        /// </summary>
        [JsonProperty("borderLeftColor", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderLeftColor { get; set; }

        /// <summary>
        /// Sets the style of an element's left border. To set all four borders, use the
        /// shorthand property, border-style. Otherwise, you can set the borders individually
        /// with border-top-style, border-right-style, border-bottom-style, border-left-style.
        /// </summary>
        [JsonProperty("borderLeftStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderLeftStyle { get; set; }

        /// <summary>
        /// Sets the width of an element's left border. To set all four borders, use the
        /// border-width shorthand property which sets the values simultaneously for
        /// border-top-width, border-right-width, border-bottom-width, and border-left-width.
        /// </summary>
        [JsonProperty("borderLeftWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderLeftWidth { get; set; }

        /// <summary>
        /// Defines how round the border's corners are.
        /// </summary>
        [JsonProperty("borderRadius", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderRadius { get; set; }

        /// <summary>
        /// Shorthand property that defines the border-width, border-style and border-color of
        /// an element's right border in a single declaration. Note that you can use the
        /// corresponding longhand properties to set specific individual properties of the
        /// right border — border-right-width, border-right-style and border-right-color.
        /// </summary>
        [JsonProperty("borderRight", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderRight { get; set; }

        /// <summary>
        /// Sets the color of an element's right border. This page explains the
        /// border-right-color value, but often you will find it more convenient to fix the
        /// border's right color as part of a shorthand set, either border-right or border-color.
        /// Colors can be defined several ways. For more information, see Usage.
        /// </summary>
        [JsonProperty("borderRightColor", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderRightColor { get; set; }

        /// <summary>
        /// Sets the style of an element's right border. To set all four borders, use the
        /// shorthand property, border-style. Otherwise, you can set the borders individually
        /// with border-top-style, border-right-style, border-bottom-style, border-left-style.
        /// </summary>
        [JsonProperty("borderRightStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderRightStyle { get; set; }

        /// <summary>
        /// Sets the width of an element's right border. To set all four borders, use the
        /// border-width shorthand property which sets the values simultaneously for
        /// border-top-width, border-right-width, border-bottom-width, and border-left-width.
        /// </summary>
        [JsonProperty("borderRightWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderRightWidth { get; set; }

        /// <summary>
        /// Specifies the distance between the borders of adjacent cells.
        /// </summary>
        [JsonProperty("borderSpacing", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderSpacing { get; set; }

        /// <summary>
        /// Sets the style of an element's four borders. This property can have from one to
        /// four values. With only one value, the value will be applied to all four borders;
        /// otherwise, this works as a shorthand property for each of border-top-style,
        /// border-right-style, border-bottom-style, border-left-style, where each border
        /// style may be assigned a separate value.
        /// </summary>
        [JsonProperty("borderStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderStyle { get; set; }

        /// <summary>
        /// Shorthand property that defines the border-width, border-style and border-color of
        /// an element's top border in a single declaration. Note that you can use the
        /// corresponding longhand properties to set specific individual properties of the top
        /// border — border-top-width, border-top-style and border-top-color.
        /// </summary>
        [JsonProperty("borderTop", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderTop { get; set; }

        /// <summary>
        /// Sets the color of an element's top border. This page explains the border-top-color
        /// value, but often you will find it more convenient to fix the border's top color as
        /// part of a shorthand set, either border-top or border-color.
        /// Colors can be defined several ways. For more information, see Usage.
        /// </summary>
        [JsonProperty("borderTopColor", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderTopColor { get; set; }

        /// <summary>
        /// Sets the rounding of the top-left corner of the element.
        /// </summary>
        [JsonProperty("borderTopLeftRadius", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderTopLeftRadius { get; set; }

        /// <summary>
        /// Sets the rounding of the top-right corner of the element.
        /// </summary>
        [JsonProperty("borderTopRightRadius", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderTopRightRadius { get; set; }

        /// <summary>
        /// Sets the style of an element's top border. To set all four borders, use the
        /// shorthand property, border-style. Otherwise, you can set the borders individually
        /// with border-top-style, border-right-style, border-bottom-style, border-left-style.
        /// </summary>
        [JsonProperty("borderTopStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderTopStyle { get; set; }

        /// <summary>
        /// Sets the width of an element's top border. To set all four borders, use the
        /// border-width shorthand property which sets the values simultaneously for
        /// border-top-width, border-right-width, border-bottom-width, and border-left-width.
        /// </summary>
        [JsonProperty("borderTopWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderTopWidth { get; set; }

        /// <summary>
        /// Sets the width of an element's four borders. This property can have from one to
        /// four values. This is a shorthand property for setting values simultaneously for
        /// border-top-width, border-right-width, border-bottom-width, and border-left-width.
        /// </summary>
        [JsonProperty("borderWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? BorderWidth { get; set; }

        /// <summary>
        /// This property specifies how far an absolutely positioned box's bottom margin edge
        /// is offset above the bottom edge of the box's containing block. For relatively
        /// positioned boxes, the offset is with respect to the bottom edges of the box itself
        /// (i.e., the box is given a position in the normal flow, then offset from that
        /// position according to these properties).
        /// </summary>
        [JsonProperty("bottom", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Bottom { get; set; }

        /// <summary>
        /// Breaks a box into fragments creating new borders, padding and repeating backgrounds
        /// or lets it stay as a continuous box on a page break, column break, or, for inline
        /// elements, at a line break.
        /// </summary>
        [JsonProperty("boxDecorationBreak", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxDecorationBreak { get; set; }

        /// <summary>
        /// Cast a drop shadow from the frame of almost any element.
        /// MDN: https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow
        /// </summary>
        [JsonProperty("boxShadow", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxShadow { get; set; }

        /// <summary>
        /// The CSS box-sizing property is used to alter the default CSS box model used to
        /// calculate width and height of the elements.
        /// </summary>
        [JsonProperty("boxSizing", NullValueHandling = NullValueHandling.Ignore)]
        public BoxSizing? BoxSizing { get; set; }

        /// <summary>
        /// The CSS break-after property allows you to force a break on multi-column layouts.
        /// More specifically, it allows you to force a break after an element. It allows you
        /// to determine if a break should occur, and what type of break it should be. The
        /// break-after CSS property describes how the page, column or region break behaves
        /// after the generated box. If there is no generated box, the property is ignored.
        /// </summary>
        [JsonProperty("breakAfter", NullValueHandling = NullValueHandling.Ignore)]
        public string BreakAfter { get; set; }

        /// <summary>
        /// Control page/column/region breaks that fall above a block of content
        /// </summary>
        [JsonProperty("breakBefore", NullValueHandling = NullValueHandling.Ignore)]
        public string BreakBefore { get; set; }

        /// <summary>
        /// Control page/column/region breaks that fall within a block of content
        /// </summary>
        [JsonProperty("breakInside", NullValueHandling = NullValueHandling.Ignore)]
        public string BreakInside { get; set; }

        /// <summary>
        /// The clear CSS property specifies if an element can be positioned next to or must be
        /// positioned below the floating elements that precede it in the markup.
        /// </summary>
        [JsonProperty("clear", NullValueHandling = NullValueHandling.Ignore)]
        public string Clear { get; set; }

        /// <summary>
        /// Clipping crops an graphic, so that only a portion of the graphic is rendered, or
        /// filled. This clip-rule property, when used with the clip-path property, defines
        /// which clip rule, or algorithm, to use when filling the different parts of a graphics.
        /// </summary>
        [JsonProperty("clipRule", NullValueHandling = NullValueHandling.Ignore)]
        public string ClipRule { get; set; }

        /// <summary>
        /// The color property sets the color of an element's foreground content (usually text),
        /// accepting any standard CSS color from keywords and hex values to RGB(a) and HSL(a).
        /// </summary>
        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        /// <summary>
        /// Describes the number of columns of the element.
        /// See CSS 3 column-count property https://www.w3.org/TR/css3-multicol/#cc
        /// </summary>
        [JsonProperty("columnCount", NullValueHandling = NullValueHandling.Ignore)]
        public ColumnCountUnion? ColumnCount { get; set; }

        /// <summary>
        /// Specifies how to fill columns (balanced or sequential).
        /// </summary>
        [JsonProperty("columnFill", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnFill { get; set; }

        /// <summary>
        /// The column-gap property controls the width of the gap between columns in multi-column
        /// elements.
        /// </summary>
        [JsonProperty("columnGap", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnGap { get; set; }

        /// <summary>
        /// Sets the width, style, and color of the rule between columns.
        /// </summary>
        [JsonProperty("columnRule", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnRule { get; set; }

        /// <summary>
        /// Specifies the color of the rule between columns.
        /// </summary>
        [JsonProperty("columnRuleColor", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnRuleColor { get; set; }

        /// <summary>
        /// Specifies the width of the rule between columns.
        /// </summary>
        [JsonProperty("columnRuleWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? ColumnRuleWidth { get; set; }

        /// <summary>
        /// This property is a shorthand property for setting column-width and/or column-count.
        /// </summary>
        [JsonProperty("columns", NullValueHandling = NullValueHandling.Ignore)]
        public string Columns { get; set; }

        /// <summary>
        /// The column-span CSS property makes it possible for an element to span across all
        /// columns when its value is set to all. An element that spans more than one column
        /// is called a spanning element.
        /// </summary>
        [JsonProperty("columnSpan", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnSpan { get; set; }

        /// <summary>
        /// Specifies the width of columns in multi-column elements.
        /// </summary>
        [JsonProperty("columnWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? ColumnWidth { get; set; }

        /// <summary>
        /// Content for pseudo selectors.
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        /// <summary>
        /// The counter-increment property accepts one or more names of counters (identifiers),
        /// each one optionally followed by an integer which specifies the value by which the
        /// counter should be incremented (e.g. if the value is 2, the counter increases by 2
        /// each time it is invoked).
        /// </summary>
        [JsonProperty("counterIncrement", NullValueHandling = NullValueHandling.Ignore)]
        public string CounterIncrement { get; set; }

        /// <summary>
        /// The counter-reset property contains a list of one or more names of counters, each
        /// one optionally followed by an integer (otherwise, the integer defaults to 0.) Each
        /// time the given element is invoked, the counters specified by the property are set to the
        /// given integer.
        /// </summary>
        [JsonProperty("counterReset", NullValueHandling = NullValueHandling.Ignore)]
        public string CounterReset { get; set; }

        /// <summary>
        /// The cue property specifies sound files (known as an "auditory icon") to be played by
        /// speech media agents before and after presenting an element's content; if only one
        /// file is specified, it is played both before and after. The volume at which the
        /// file(s) should be played, relative to the volume of the main element, may also be
        /// specified. The icon files may also be set separately with the cue-before and
        /// cue-after properties.
        /// </summary>
        [JsonProperty("cue", NullValueHandling = NullValueHandling.Ignore)]
        public string Cue { get; set; }

        /// <summary>
        /// The cue-after property specifies a sound file (known as an "auditory icon") to be
        /// played by speech media agents after presenting an element's content; the volume at
        /// which the file should be played may also be specified. The shorthand property cue
        /// sets cue sounds for both before and after the element is presented.
        /// </summary>
        [JsonProperty("cueAfter", NullValueHandling = NullValueHandling.Ignore)]
        public string CueAfter { get; set; }

        /// <summary>
        /// Specifies the mouse cursor displayed when the mouse pointer is over an element.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        /// <summary>
        /// The direction CSS property specifies the text direction/writing direction. The rtl
        /// is used for Hebrew or Arabic text, the ltr is for other languages.
        /// </summary>
        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        public string Direction { get; set; }

        /// <summary>
        /// This property specifies the type of rendering box used for an element. It is a
        /// shorthand property for many other display properties.
        /// </summary>
        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        public string Display { get; set; }

        /// <summary>
        /// The ‘fill’ property paints the interior of the given graphical element. The area to
        /// be painted consists of any areas inside the outline of the shape. To determine the
        /// inside of the shape, all subpaths are considered, and the interior is determined
        /// according to the rules associated with the current value of the ‘fill-rule’
        /// property. The zero-width geometric outline of a shape is included in the area to be
        /// painted.
        /// </summary>
        [JsonProperty("fill", NullValueHandling = NullValueHandling.Ignore)]
        public string Fill { get; set; }

        /// <summary>
        /// SVG: Specifies the opacity of the color or the content the current object is filled
        /// with.
        /// See SVG 1.1 https://www.w3.org/TR/SVG/painting.html#FillOpacityProperty
        /// </summary>
        [JsonProperty("fillOpacity", NullValueHandling = NullValueHandling.Ignore)]
        public FillOpacity? FillOpacity { get; set; }

        /// <summary>
        /// The ‘fill-rule’ property indicates the algorithm which is to be used to determine
        /// what parts of the canvas are included inside the shape. For a simple,
        /// non-intersecting path, it is intuitively clear what region lies "inside"; however,
        /// for a more complex path, such as a path that intersects itself or where one subpath
        /// encloses another, the interpretation of "inside" is not so obvious.
        /// The ‘fill-rule’ property provides two options for how the inside of a shape is
        /// determined:
        /// </summary>
        [JsonProperty("fillRule", NullValueHandling = NullValueHandling.Ignore)]
        public string FillRule { get; set; }

        /// <summary>
        /// Applies various image processing effects. This property is largely unsupported. See
        /// Compatibility section for more information.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public string Filter { get; set; }

        /// <summary>
        /// Shorthand for `flex-grow`, `flex-shrink`, and `flex-basis`.
        /// </summary>
        [JsonProperty("flex", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Flex { get; set; }

        /// <summary>
        /// The flex-basis CSS property describes the initial main size of the flex item before
        /// any free space is distributed according to the flex factors described in the flex
        /// property (flex-grow and flex-shrink).
        /// </summary>
        [JsonProperty("flexBasis", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? FlexBasis { get; set; }

        /// <summary>
        /// The flex-direction CSS property describes how flex items are placed in the flex
        /// container, by setting the direction of the flex container's main axis.
        /// </summary>
        [JsonProperty("flexDirection", NullValueHandling = NullValueHandling.Ignore)]
        public FlexDirection? FlexDirection { get; set; }

        /// <summary>
        /// The flex-flow CSS property defines the flex container's main and cross axis. It is
        /// a shorthand property for the flex-direction and flex-wrap properties.
        /// </summary>
        [JsonProperty("flexFlow", NullValueHandling = NullValueHandling.Ignore)]
        public string FlexFlow { get; set; }

        /// <summary>
        /// Specifies the flex grow factor of a flex item.
        /// See CSS flex-grow property https://drafts.csswg.org/css-flexbox-1/#flex-grow-property
        /// </summary>
        [JsonProperty("flexGrow", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? FlexGrow { get; set; }

        /// <summary>
        /// Specifies the flex shrink factor of a flex item.
        /// See CSS flex-shrink property https://drafts.csswg.org/css-flexbox-1/#flex-shrink-property
        /// </summary>
        [JsonProperty("flexShrink", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? FlexShrink { get; set; }

        /// <summary>
        /// Specifies whether flex items are forced into a single line or can be wrapped onto
        /// multiple lines. If wrapping is allowed, this property also enables you to control
        /// the direction in which lines are stacked.
        /// See CSS flex-wrap property https://drafts.csswg.org/css-flexbox-1/#flex-wrap-property
        /// </summary>
        [JsonProperty("flexWrap", NullValueHandling = NullValueHandling.Ignore)]
        public FlexWrap? FlexWrap { get; set; }

        /// <summary>
        /// Elements which have the style float are floated horizontally. These elements can
        /// move as far to the left or right of the containing element. All elements after
        /// the floating element will flow around it, but elements before the floating element
        /// are not impacted. If several floating elements are placed after each other, they
        /// will float next to each other as long as there is room.
        /// </summary>
        [JsonProperty("float", NullValueHandling = NullValueHandling.Ignore)]
        public string Float { get; set; }

        /// <summary>
        /// Flows content from a named flow (specified by a corresponding flow-into) through
        /// selected elements to form a dynamic chain of layout regions.
        /// </summary>
        [JsonProperty("flowFrom", NullValueHandling = NullValueHandling.Ignore)]
        public string FlowFrom { get; set; }

        /// <summary>
        /// The font property is shorthand that allows you to do one of two things: you can
        /// either set up six of the most mature font properties in one line, or you can set
        /// one of a choice of keywords to adopt a system font setting.
        /// </summary>
        [JsonProperty("font", NullValueHandling = NullValueHandling.Ignore)]
        public string Font { get; set; }

        /// <summary>
        /// The font-family property allows one or more font family names and/or generic family
        /// names to be specified for usage on the selected element(s)' text. The browser then
        /// goes through the list; for each character in the selection it applies the first
        /// font family that has an available glyph for that character.
        /// </summary>
        [JsonProperty("fontFamily", NullValueHandling = NullValueHandling.Ignore)]
        public string FontFamily { get; set; }

        /// <summary>
        /// The font-kerning property allows contextual adjustment of inter-glyph spacing, i.e.
        /// the spaces between the characters in text. This property controls <bold>metric
        /// kerning</bold> - that utilizes adjustment data contained in the font. Optical
        /// Kerning is not supported as yet.
        /// </summary>
        [JsonProperty("fontKerning", NullValueHandling = NullValueHandling.Ignore)]
        public string FontKerning { get; set; }

        /// <summary>
        /// Specifies the size of the font. Used to compute em and ex units.
        /// See CSS 3 font-size property https://www.w3.org/TR/css-fonts-3/#propdef-font-size
        /// </summary>
        [JsonProperty("fontSize", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? FontSize { get; set; }

        /// <summary>
        /// The font-size-adjust property adjusts the font-size of the fallback fonts defined
        /// with font-family, so that the x-height is the same no matter what font is used.
        /// This preserves the readability of the text when fallback happens.
        /// See CSS 3 font-size-adjust property
        /// https://www.w3.org/TR/css-fonts-3/#propdef-font-size-adjust
        /// </summary>
        [JsonProperty("fontSizeAdjust", NullValueHandling = NullValueHandling.Ignore)]
        public FontSizeAdjustUnion? FontSizeAdjust { get; set; }

        /// <summary>
        /// Allows you to expand or condense the widths for a normal, condensed, or expanded
        /// font face.
        /// See CSS 3 font-stretch property
        /// https://drafts.csswg.org/css-fonts-3/#propdef-font-stretch
        /// </summary>
        [JsonProperty("fontStretch", NullValueHandling = NullValueHandling.Ignore)]
        public FontStretch? FontStretch { get; set; }

        /// <summary>
        /// The font-style property allows normal, italic, or oblique faces to be selected.
        /// Italic forms are generally cursive in nature while oblique faces are typically
        /// sloped versions of the regular face. Oblique faces can be simulated by artificially
        /// sloping the glyphs of the regular face.
        /// See CSS 3 font-style property https://www.w3.org/TR/css-fonts-3/#propdef-font-style
        /// </summary>
        [JsonProperty("fontStyle", NullValueHandling = NullValueHandling.Ignore)]
        public FontStyle? FontStyle { get; set; }

        /// <summary>
        /// This value specifies whether the user agent is allowed to synthesize bold or
        /// oblique font faces when a font family lacks bold or italic faces.
        /// </summary>
        [JsonProperty("fontSynthesis", NullValueHandling = NullValueHandling.Ignore)]
        public string FontSynthesis { get; set; }

        /// <summary>
        /// The font-variant property enables you to select the small-caps font within a font
        /// family.
        /// </summary>
        [JsonProperty("fontVariant", NullValueHandling = NullValueHandling.Ignore)]
        public string FontVariant { get; set; }

        /// <summary>
        /// Fonts can provide alternate glyphs in addition to default glyph for a character.
        /// This property provides control over the selection of these alternate glyphs.
        /// </summary>
        [JsonProperty("fontVariantAlternates", NullValueHandling = NullValueHandling.Ignore)]
        public string FontVariantAlternates { get; set; }

        /// <summary>
        /// Specifies the weight or boldness of the font.
        /// See CSS 3 'font-weight' property https://www.w3.org/TR/css-fonts-3/#propdef-font-weight
        /// </summary>
        [JsonProperty("fontWeight", NullValueHandling = NullValueHandling.Ignore)]
        public IFontWeightUnion? FontWeight { get; set; }

        /// <summary>
        /// Lays out one or more grid items bound by 4 grid lines. Shorthand for setting
        /// grid-column-start, grid-column-end, grid-row-start, and grid-row-end in a single
        /// declaration.
        /// </summary>
        [JsonProperty("gridArea", NullValueHandling = NullValueHandling.Ignore)]
        public string GridArea { get; set; }

        /// <summary>
        /// Controls a grid item's placement in a grid area, particularly grid position and a
        /// grid span. Shorthand for setting grid-column-start and grid-column-end in a single
        /// declaration.
        /// </summary>
        [JsonProperty("gridColumn", NullValueHandling = NullValueHandling.Ignore)]
        public string GridColumn { get; set; }

        /// <summary>
        /// Controls a grid item's placement in a grid area as well as grid position and a
        /// grid span. The grid-column-end property (with grid-row-start, grid-row-end, and
        /// grid-column-start) determines a grid item's placement by specifying the grid lines
        /// of a grid item's grid area.
        /// </summary>
        [JsonProperty("gridColumnEnd", NullValueHandling = NullValueHandling.Ignore)]
        public string GridColumnEnd { get; set; }

        /// <summary>
        /// Determines a grid item's placement by specifying the starting grid lines of a grid
        /// item's grid area . A grid item's placement in a grid area consists of a grid
        /// position and a grid span. See also ( grid-row-start, grid-row-end, and
        /// grid-column-end)
        /// </summary>
        [JsonProperty("gridColumnStart", NullValueHandling = NullValueHandling.Ignore)]
        public string GridColumnStart { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates which row an element within a Grid should
        /// appear in. Shorthand for setting grid-row-start and grid-row-end in a single
        /// declaration.
        /// </summary>
        [JsonProperty("gridRow", NullValueHandling = NullValueHandling.Ignore)]
        public string GridRow { get; set; }

        /// <summary>
        /// Determines a grid item’s placement by specifying the block-end. A grid item's
        /// placement in a grid area consists of a grid position and a grid span. The
        /// grid-row-end property (with grid-row-start, grid-column-start, and grid-column-end)
        /// determines a grid item's placement by specifying the grid lines of a grid item's
        /// grid area.
        /// </summary>
        [JsonProperty("gridRowEnd", NullValueHandling = NullValueHandling.Ignore)]
        public string GridRowEnd { get; set; }

        /// <summary>
        /// Specifies a row position based upon an integer location, string value, or desired
        /// row size.
        /// css/properties/grid-row is used as short-hand for grid-row-position and
        /// grid-row-position
        /// </summary>
        [JsonProperty("gridRowPosition", NullValueHandling = NullValueHandling.Ignore)]
        public string GridRowPosition { get; set; }

        /// <summary>
        /// Specifies named grid areas which are not associated with any particular grid item,
        /// but can be referenced from the grid-placement properties. The syntax of the
        /// grid-template-areas property also provides a visualization of the structure of the
        /// grid, making the overall layout of the grid container easier to understand.
        /// </summary>
        [JsonProperty("gridTemplateAreas", NullValueHandling = NullValueHandling.Ignore)]
        public string GridTemplateAreas { get; set; }

        /// <summary>
        /// Specifies (with grid-template-rows) the line names and track sizing functions of
        /// the grid. Each sizing function can be specified as a length, a percentage of the
        /// grid container’s size, a measurement of the contents occupying the column or row,
        /// or a fraction of the free space in the grid.
        /// </summary>
        [JsonProperty("gridTemplateColumns", NullValueHandling = NullValueHandling.Ignore)]
        public string GridTemplateColumns { get; set; }

        /// <summary>
        /// Specifies (with grid-template-columns) the line names and track sizing functions of
        /// the grid. Each sizing function can be specified as a length, a percentage of the
        /// grid container’s size, a measurement of the contents occupying the column or row,
        /// or a fraction of the free space in the grid.
        /// </summary>
        [JsonProperty("gridTemplateRows", NullValueHandling = NullValueHandling.Ignore)]
        public string GridTemplateRows { get; set; }

        /// <summary>
        /// Sets the height of an element. The content area of the element height does not
        /// include the padding, border, and margin of the element.
        /// </summary>
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Height { get; set; }

        /// <summary>
        /// Specifies the minimum number of characters in a hyphenated word
        /// </summary>
        [JsonProperty("hyphenateLimitChars", NullValueHandling = NullValueHandling.Ignore)]
        public string HyphenateLimitChars { get; set; }

        /// <summary>
        /// Indicates the maximum number of successive hyphenated lines in an element. The
        /// ‘no-limit’ value means that there is no limit.
        /// </summary>
        [JsonProperty("hyphenateLimitLines", NullValueHandling = NullValueHandling.Ignore)]
        public string HyphenateLimitLines { get; set; }

        /// <summary>
        /// Specifies the maximum amount of trailing whitespace (before justification) that may
        /// be left in a line before hyphenation is triggered to pull part of a word from the
        /// next line back up into the current one.
        /// </summary>
        [JsonProperty("hyphenateLimitZone", NullValueHandling = NullValueHandling.Ignore)]
        public string HyphenateLimitZone { get; set; }

        /// <summary>
        /// Specifies whether or not words in a sentence can be split by the use of a manual or
        /// automatic hyphenation mechanism.
        /// </summary>
        [JsonProperty("hyphens", NullValueHandling = NullValueHandling.Ignore)]
        public string Hyphens { get; set; }

        /// <summary>
        /// Defines how the browser distributes space between and around flex items
        /// along the main-axis of their container.
        /// See CSS justify-content property
        /// https://www.w3.org/TR/css-flexbox-1/#justify-content-property
        /// </summary>
        [JsonProperty("justifyContent", NullValueHandling = NullValueHandling.Ignore)]
        public JustifyContent? JustifyContent { get; set; }

        /// <summary>
        /// Sets the left position of an element relative to the nearest anscestor that is set
        /// to position absolute, relative, or fixed.
        /// </summary>
        [JsonProperty("left", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Left { get; set; }

        /// <summary>
        /// The letter-spacing CSS property specifies the spacing behavior between text
        /// characters.
        /// </summary>
        [JsonProperty("letterSpacing", NullValueHandling = NullValueHandling.Ignore)]
        public string LetterSpacing { get; set; }

        /// <summary>
        /// Specifies the height of an inline block level element.
        /// See CSS 2.1 line-height property
        /// https://www.w3.org/TR/CSS21/visudet.html#propdef-line-height
        /// </summary>
        [JsonProperty("lineHeight", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? LineHeight { get; set; }

        /// <summary>
        /// Shorthand property that sets the list-style-type, list-style-position and
        /// list-style-image properties in one declaration.
        /// </summary>
        [JsonProperty("listStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string ListStyle { get; set; }

        /// <summary>
        /// This property sets the image that will be used as the list item marker. When the
        /// image is available, it will replace the marker set with the 'list-style-type'
        /// marker. That also means that if the image is not available, it will show the style
        /// specified by list-style-property
        /// </summary>
        [JsonProperty("listStyleImage", NullValueHandling = NullValueHandling.Ignore)]
        public string ListStyleImage { get; set; }

        /// <summary>
        /// Specifies if the list-item markers should appear inside or outside the content flow.
        /// </summary>
        [JsonProperty("listStylePosition", NullValueHandling = NullValueHandling.Ignore)]
        public string ListStylePosition { get; set; }

        /// <summary>
        /// Specifies the type of list-item marker in a list.
        /// </summary>
        [JsonProperty("listStyleType", NullValueHandling = NullValueHandling.Ignore)]
        public string ListStyleType { get; set; }

        /// <summary>
        /// The margin property is shorthand to allow you to set all four margins of an element
        /// at once. Its equivalent longhand properties are margin-top, margin-right,
        /// margin-bottom and margin-left. Negative values are also allowed.
        /// </summary>
        [JsonProperty("margin", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Margin { get; set; }

        /// <summary>
        /// margin-bottom sets the bottom margin of an element.
        /// </summary>
        [JsonProperty("marginBottom", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MarginBottom { get; set; }

        /// <summary>
        /// margin-left sets the left margin of an element.
        /// </summary>
        [JsonProperty("marginLeft", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MarginLeft { get; set; }

        /// <summary>
        /// margin-right sets the right margin of an element.
        /// </summary>
        [JsonProperty("marginRight", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MarginRight { get; set; }

        /// <summary>
        /// margin-top sets the top margin of an element.
        /// </summary>
        [JsonProperty("marginTop", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MarginTop { get; set; }

        /// <summary>
        /// The marquee-direction determines the initial direction in which the marquee content moves.
        /// </summary>
        [JsonProperty("marqueeDirection", NullValueHandling = NullValueHandling.Ignore)]
        public string MarqueeDirection { get; set; }

        /// <summary>
        /// The 'marquee-style' property determines a marquee's scrolling behavior.
        /// </summary>
        [JsonProperty("marqueeStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string MarqueeStyle { get; set; }

        /// <summary>
        /// This property is shorthand for setting mask-image, mask-mode, mask-repeat,
        /// mask-position, mask-clip, mask-origin, mask-composite and mask-size. Omitted
        /// values are set to their original properties' initial values.
        /// </summary>
        [JsonProperty("mask", NullValueHandling = NullValueHandling.Ignore)]
        public string Mask { get; set; }

        /// <summary>
        /// This property is shorthand for setting mask-border-source, mask-border-slice,
        /// mask-border-width, mask-border-outset, and mask-border-repeat. Omitted values
        /// are set to their original properties' initial values.
        /// </summary>
        [JsonProperty("maskBorder", NullValueHandling = NullValueHandling.Ignore)]
        public string MaskBorder { get; set; }

        /// <summary>
        /// This property specifies how the images for the sides and the middle part of the
        /// mask image are scaled and tiled. The first keyword applies to the horizontal
        /// sides, the second one applies to the vertical ones. If the second keyword is
        /// absent, it is assumed to be the same as the first, similar to the CSS
        /// border-image-repeat property.
        /// </summary>
        [JsonProperty("maskBorderRepeat", NullValueHandling = NullValueHandling.Ignore)]
        public string MaskBorderRepeat { get; set; }

        /// <summary>
        /// This property specifies inward offsets from the top, right, bottom, and left
        /// edges of the mask image, dividing it into nine regions: four corners, four
        /// edges, and a middle. The middle image part is discarded and treated as fully
        /// transparent black unless the fill keyword is present. The four values set the
        /// top, right, bottom and left offsets in that order, similar to the CSS
        /// border-image-slice property.
        /// </summary>
        [JsonProperty("maskBorderSlice", NullValueHandling = NullValueHandling.Ignore)]
        public string MaskBorderSlice { get; set; }

        /// <summary>
        /// Specifies an image to be used as a mask. An image that is empty, fails to
        /// download, is non-existent, or cannot be displayed is ignored and does not mask
        /// the element.
        /// </summary>
        [JsonProperty("maskBorderSource", NullValueHandling = NullValueHandling.Ignore)]
        public string MaskBorderSource { get; set; }

        /// <summary>
        /// This property sets the width of the mask box image, similar to the CSS
        /// border-image-width property.
        /// </summary>
        [JsonProperty("maskBorderWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MaskBorderWidth { get; set; }

        /// <summary>
        /// Determines the mask painting area, which defines the area that is affected by
        /// the mask. The painted content of an element may be restricted to this area.
        /// </summary>
        [JsonProperty("maskClip", NullValueHandling = NullValueHandling.Ignore)]
        public string MaskClip { get; set; }

        /// <summary>
        /// For elements rendered as a single box, specifies the mask positioning area. For
        /// elements rendered as multiple boxes (e.g., inline boxes on several lines, boxes
        /// on several pages) specifies which boxes box-decoration-break operates on to
        /// determine the mask positioning area(s).
        /// </summary>
        [JsonProperty("maskOrigin", NullValueHandling = NullValueHandling.Ignore)]
        public string MaskOrigin { get; set; }

        /// <summary>
        /// This property must not be used. It is no longer included in any standard or
        /// standard track specification, nor is it implemented in any browser. It is only
        /// used when the text-align-last property is set to size. It controls allowed
        /// adjustments of font-size to fit line content.
        /// </summary>
        [JsonProperty("maxFontSize", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MaxFontSize { get; set; }

        /// <summary>
        /// Sets the maximum height for an element. It prevents the height of the element to
        /// exceed the specified value. If min-height is specified and is greater than
        /// max-height, max-height is overridden.
        /// </summary>
        [JsonProperty("maxHeight", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MaxHeight { get; set; }

        /// <summary>
        /// Sets the maximum width for an element. It limits the width property to be larger
        /// than the value specified in max-width.
        /// </summary>
        [JsonProperty("maxWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MaxWidth { get; set; }

        /// <summary>
        /// Sets the minimum height for an element. It prevents the height of the element to
        /// be smaller than the specified value. The value of min-height overrides both
        /// max-height and height.
        /// </summary>
        [JsonProperty("minHeight", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MinHeight { get; set; }

        /// <summary>
        /// Sets the minimum width of an element. It limits the width property to be not
        /// smaller than the value specified in min-width.
        /// </summary>
        [JsonProperty("minWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? MinWidth { get; set; }

        /// <summary>
        /// (Moz specific) font smoothing directive.
        /// </summary>
        [JsonProperty("MozOsxFontSmoothing", NullValueHandling = NullValueHandling.Ignore)]
        public FontSmoothing? MozOsxFontSmoothing { get; set; }

        /// <summary>
        /// (Ms specific) constrast adjust rule.
        /// </summary>
        [JsonProperty("MsHighContrastAdjust", NullValueHandling = NullValueHandling.Ignore)]
        public string MsHighContrastAdjust { get; set; }

        /// <summary>
        /// Specifies the transparency of an element.
        /// See CSS 3 opacity property https://drafts.csswg.org/css-color-3/#opacity
        /// </summary>
        [JsonProperty("opacity", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Opacity { get; set; }

        /// <summary>
        /// Specifies the order used to lay out flex items in their flex container.
        /// Elements are laid out in the ascending order of the order value.
        /// See CSS order property https://drafts.csswg.org/css-flexbox-1/#order-property
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public FillOpacity? Order { get; set; }

        /// <summary>
        /// In paged media, this property defines the minimum number of lines in
        /// a block container that must be left at the bottom of the page.
        /// See CSS 3 orphans, widows properties https://drafts.csswg.org/css-break-3/#widows-orphans
        /// </summary>
        [JsonProperty("orphans", NullValueHandling = NullValueHandling.Ignore)]
        public FillOpacity? Orphans { get; set; }

        /// <summary>
        /// The CSS outline property is a shorthand property for setting one or more of the
        /// individual outline properties outline-style, outline-width and outline-color in a
        /// single rule. In most cases the use of this shortcut is preferable and more
        /// convenient.
        /// Outlines differ from borders in the following ways:
        /// •       Outlines do not take up space, they are drawn above the content.
        /// •       Outlines may be non-rectangular. They are rectangular in
        /// Gecko/Firefox. Internet Explorer attempts to place the smallest contiguous outline
        /// around all elements or shapes that are indicated to have an outline. Opera draws a
        /// non-rectangular shape around a construct.
        /// </summary>
        [JsonProperty("outline", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Outline { get; set; }

        /// <summary>
        /// The outline-color property sets the color of the outline of an element. An
        /// outline is a line that is drawn around elements, outside the border edge, to make
        /// the element stand out.
        /// </summary>
        [JsonProperty("outlineColor", NullValueHandling = NullValueHandling.Ignore)]
        public string OutlineColor { get; set; }

        /// <summary>
        /// The outline-offset property offsets the outline and draw it beyond the border edge.
        /// </summary>
        [JsonProperty("outlineOffset", NullValueHandling = NullValueHandling.Ignore)]
        public string OutlineOffset { get; set; }

        /// <summary>
        /// The overflow property controls how extra content exceeding the bounding box of an
        /// element is rendered. It can be used in conjunction with an element that has a
        /// fixed width and height, to eliminate text-induced page distortion.
        /// </summary>
        [JsonProperty("overflow", NullValueHandling = NullValueHandling.Ignore)]
        public Overflow? Overflow { get; set; }

        /// <summary>
        /// Specifies the preferred scrolling methods for elements that overflow.
        /// </summary>
        [JsonProperty("overflowStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string OverflowStyle { get; set; }

        /// <summary>
        /// Specifies whether or not the browser should insert line breaks within words to
        /// prevent text from overflowing its content box. In contrast to word-break,
        /// overflow-wrap will only create a break if an entire word cannot be placed on its
        /// own line without overflowing.
        /// </summary>
        [JsonProperty("overflowWrap", NullValueHandling = NullValueHandling.Ignore)]
        public OverflowWrap? OverflowWrap { get; set; }

        /// <summary>
        /// Controls how extra content exceeding the x-axis of the bounding box of an element
        /// is rendered.
        /// </summary>
        [JsonProperty("overflowX", NullValueHandling = NullValueHandling.Ignore)]
        public Overflow? OverflowX { get; set; }

        /// <summary>
        /// Controls how extra content exceeding the y-axis of the bounding box of an element
        /// is rendered.
        /// </summary>
        [JsonProperty("overflowY", NullValueHandling = NullValueHandling.Ignore)]
        public Overflow? OverflowY { get; set; }

        /// <summary>
        /// The padding optional CSS property sets the required padding space on one to four
        /// sides of an element. The padding area is the space between an element and its
        /// border. Negative values are not allowed but decimal values are permitted. The
        /// element size is treated as fixed, and the content of the element shifts toward the
        /// center as padding is increased. The padding property is a shorthand to avoid
        /// setting each side separately (padding-top, padding-right, padding-bottom,
        /// padding-left).
        /// </summary>
        [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Padding { get; set; }

        /// <summary>
        /// The padding-bottom CSS property of an element sets the padding space required on
        /// the bottom of an element. The padding area is the space between the content of the
        /// element and its border. Contrary to margin-bottom values, negative values of
        /// padding-bottom are invalid.
        /// </summary>
        [JsonProperty("paddingBottom", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? PaddingBottom { get; set; }

        /// <summary>
        /// The padding-left CSS property of an element sets the padding space required on the
        /// left side of an element. The padding area is the space between the content of the
        /// element and its border. Contrary to margin-left values, negative values of
        /// padding-left are invalid.
        /// </summary>
        [JsonProperty("paddingLeft", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? PaddingLeft { get; set; }

        /// <summary>
        /// The padding-right CSS property of an element sets the padding space required on the
        /// right side of an element. The padding area is the space between the content of the
        /// element and its border. Contrary to margin-right values, negative values of
        /// padding-right are invalid.
        /// </summary>
        [JsonProperty("paddingRight", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? PaddingRight { get; set; }

        /// <summary>
        /// The padding-top CSS property of an element sets the padding space required on the
        /// top of an element. The padding area is the space between the content of the element
        /// and its border. Contrary to margin-top values, negative values of padding-top are
        /// invalid.
        /// </summary>
        [JsonProperty("paddingTop", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? PaddingTop { get; set; }

        /// <summary>
        /// The page-break-after property is supported in all major browsers. With CSS3,
        /// page-break-* properties are only aliases of the break-* properties. The CSS3
        /// Fragmentation spec defines breaks for all CSS box fragmentation.
        /// </summary>
        [JsonProperty("pageBreakAfter", NullValueHandling = NullValueHandling.Ignore)]
        public string PageBreakAfter { get; set; }

        /// <summary>
        /// The page-break-before property sets the page-breaking behavior before an element.
        /// With CSS3, page-break-* properties are only aliases of the break-* properties. The
        /// CSS3 Fragmentation spec defines breaks for all CSS box fragmentation.
        /// </summary>
        [JsonProperty("pageBreakBefore", NullValueHandling = NullValueHandling.Ignore)]
        public string PageBreakBefore { get; set; }

        /// <summary>
        /// Sets the page-breaking behavior inside an element. With CSS3, page-break-*
        /// properties are only aliases of the break-* properties. The CSS3 Fragmentation spec
        /// defines breaks for all CSS box fragmentation.
        /// </summary>
        [JsonProperty("pageBreakInside", NullValueHandling = NullValueHandling.Ignore)]
        public string PageBreakInside { get; set; }

        /// <summary>
        /// The pause property determines how long a speech media agent should pause before and
        /// after presenting an element. It is a shorthand for the pause-before and pause-after
        /// properties.
        /// </summary>
        [JsonProperty("pause", NullValueHandling = NullValueHandling.Ignore)]
        public string Pause { get; set; }

        /// <summary>
        /// The pause-after property determines how long a speech media agent should pause after
        /// presenting an element. It may be replaced by the shorthand property pause, which
        /// sets pause time before and after.
        /// </summary>
        [JsonProperty("pauseAfter", NullValueHandling = NullValueHandling.Ignore)]
        public string PauseAfter { get; set; }

        /// <summary>
        /// The pause-before property determines how long a speech media agent should pause
        /// before presenting an element. It may be replaced by the shorthand property pause,
        /// which sets pause time before and after.
        /// </summary>
        [JsonProperty("pauseBefore", NullValueHandling = NullValueHandling.Ignore)]
        public string PauseBefore { get; set; }

        /// <summary>
        /// The perspective property defines how far an element is placed from the view on the
        /// z-axis, from the screen to the viewer. Perspective defines how an object is viewed.
        /// In graphic arts, perspective is the representation on a flat surface of what the
        /// viewer's eye would see in a 3D space. (See Wikipedia for more information about
        /// graphical perspective and for related illustrations.)
        /// The illusion of perspective on a flat surface, such as a computer screen, is created
        /// by projecting points on the flat surface as they would appear if the flat surface
        /// were a window through which the viewer was looking at the object. In discussion of
        /// virtual environments, this flat surface is called a projection plane.
        /// </summary>
        [JsonProperty("perspective", NullValueHandling = NullValueHandling.Ignore)]
        public string Perspective { get; set; }

        /// <summary>
        /// The perspective-origin property establishes the origin for the perspective property.
        /// It effectively sets the X and Y position at which the viewer appears to be looking
        /// at the children of the element.
        /// When used with perspective, perspective-origin changes the appearance of an object,
        /// as if a viewer were looking at it from a different origin. An object appears
        /// differently if a viewer is looking directly at it versus looking at it from below,
        /// above, or from the side. Thus, the perspective-origin is like a vanishing point.
        /// The default value of perspective-origin is 50% 50%. This displays an object as if
        /// the viewer's eye were positioned directly at the center of the screen, both
        /// top-to-bottom and left-to-right. A value of 0% 0% changes the object as if the
        /// viewer was looking toward the top left angle. A value of 100% 100% changes the
        /// appearance as if viewed toward the bottom right angle.
        /// </summary>
        [JsonProperty("perspectiveOrigin", NullValueHandling = NullValueHandling.Ignore)]
        public string PerspectiveOrigin { get; set; }

        /// <summary>
        /// The pointer-events property allows you to control whether an element can be the
        /// target for the pointing device (e.g, mouse, pen) events.
        /// </summary>
        [JsonProperty("pointerEvents", NullValueHandling = NullValueHandling.Ignore)]
        public string PointerEvents { get; set; }

        /// <summary>
        /// The position property controls the type of positioning used by an element within
        /// its parent elements. The effect of the position property depends on a lot of
        /// factors, for example the position property of parent elements.
        /// </summary>
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public Position? Position { get; set; }

        /// <summary>
        /// Sets the type of quotation marks for embedded quotations.
        /// </summary>
        [JsonProperty("quotes", NullValueHandling = NullValueHandling.Ignore)]
        public string Quotes { get; set; }

        /// <summary>
        /// Controls whether the last region in a chain displays additional 'overset' content
        /// according its default overflow property, or if it displays a fragment of content
        /// as if it were flowing into a subsequent region.
        /// </summary>
        [JsonProperty("regionFragment", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionFragment { get; set; }

        /// <summary>
        /// The resize CSS sets whether an element is resizable, and if so, in which direction(s).
        /// </summary>
        [JsonProperty("resize", NullValueHandling = NullValueHandling.Ignore)]
        public Resize? Resize { get; set; }

        /// <summary>
        /// The rest-after property determines how long a speech media agent should pause after
        /// presenting an element's main content, before presenting that element's exit cue
        /// sound. It may be replaced by the shorthand property rest, which sets rest time
        /// before and after.
        /// </summary>
        [JsonProperty("restAfter", NullValueHandling = NullValueHandling.Ignore)]
        public string RestAfter { get; set; }

        /// <summary>
        /// The rest-before property determines how long a speech media agent should pause after
        /// presenting an intro cue sound for an element, before presenting that element's main
        /// content. It may be replaced by the shorthand property rest, which sets rest time
        /// before and after.
        /// </summary>
        [JsonProperty("restBefore", NullValueHandling = NullValueHandling.Ignore)]
        public string RestBefore { get; set; }

        /// <summary>
        /// Specifies the position an element in relation to the right side of the containing
        /// element.
        /// </summary>
        [JsonProperty("right", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Right { get; set; }

        /// <summary>
        /// Defines the alpha channel threshold used to extract a shape from an image. Can be
        /// thought of as a "minimum opacity" threshold; that is, a value of 0.5 means that the
        /// shape will enclose all the pixels that are more than 50% opaque.
        /// </summary>
        [JsonProperty("shapeImageThreshold", NullValueHandling = NullValueHandling.Ignore)]
        public string ShapeImageThreshold { get; set; }

        /// <summary>
        /// A future level of CSS Shapes will define a shape-inside property, which will define
        /// a shape to wrap content within the element. See Editor's Draft
        /// <http://dev.w3.org/csswg/css-shapes/> and CSSWG wiki page on next-level plans
        /// <http://wiki.csswg.org/spec/css-shapes>
        /// </summary>
        [JsonProperty("shapeInside", NullValueHandling = NullValueHandling.Ignore)]
        public string ShapeInside { get; set; }

        /// <summary>
        /// Adds a margin to a shape-outside. In effect, defines a new shape that is the
        /// smallest contour around all the points that are the shape-margin distance outward
        /// perpendicular to each point on the underlying shape. For points where a
        /// perpendicular direction is not defined (e.g., a triangle corner), takes all
        /// points on a circle centered at the point and with a radius of the shape-margin
        /// distance. This property accepts only non-negative values.
        /// </summary>
        [JsonProperty("shapeMargin", NullValueHandling = NullValueHandling.Ignore)]
        public string ShapeMargin { get; set; }

        /// <summary>
        /// Declares a shape around which text should be wrapped, with possible modifications
        /// from the shape-margin property. The shape defined by shape-outside and shape-margin
        /// changes the geometry of a float element's float area.
        /// </summary>
        [JsonProperty("shapeOutside", NullValueHandling = NullValueHandling.Ignore)]
        public string ShapeOutside { get; set; }

        /// <summary>
        /// The speak property determines whether or not a speech synthesizer will read aloud
        /// the contents of an element.
        /// </summary>
        [JsonProperty("speak", NullValueHandling = NullValueHandling.Ignore)]
        public string Speak { get; set; }

        /// <summary>
        /// The speak-as property determines how the speech synthesizer interprets the content:
        /// words as whole words or as a sequence of letters, numbers as a numerical value or a
        /// sequence of digits, punctuation as pauses in speech or named punctuation characters.
        /// </summary>
        [JsonProperty("speakAs", NullValueHandling = NullValueHandling.Ignore)]
        public string SpeakAs { get; set; }

        /// <summary>
        /// The stroke property in CSS is for adding a border to SVG shapes.
        /// See SVG 1.1 https://www.w3.org/TR/SVG/painting.html#Stroke
        /// </summary>
        [JsonProperty("stroke", NullValueHandling = NullValueHandling.Ignore)]
        public string Stroke { get; set; }

        /// <summary>
        /// SVG: Specifies the opacity of the outline on the current object.
        /// See SVG 1.1 https://www.w3.org/TR/SVG/painting.html#StrokeOpacityProperty
        /// </summary>
        [JsonProperty("strokeOpacity", NullValueHandling = NullValueHandling.Ignore)]
        public FillOpacity? StrokeOpacity { get; set; }

        /// <summary>
        /// SVG: Specifies the width of the outline on the current object.
        /// See SVG 1.1 https://www.w3.org/TR/SVG/painting.html#StrokeWidthProperty
        /// </summary>
        [JsonProperty("strokeWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? StrokeWidth { get; set; }

        /// <summary>
        /// The 'table-layout' property controls the algorithm used to lay out the table cells, rows,
        /// and columns.
        /// </summary>
        [JsonProperty("tableLayout", NullValueHandling = NullValueHandling.Ignore)]
        public string TableLayout { get; set; }

        /// <summary>
        /// The tab-size CSS property is used to customise the width of a tab (U+0009) character.
        /// </summary>
        [JsonProperty("tabSize", NullValueHandling = NullValueHandling.Ignore)]
        public string TabSize { get; set; }

        /// <summary>
        /// The text-align CSS property describes how inline content like text is aligned in its
        /// parent block element. text-align does not control the alignment of block elements
        /// itself, only their inline content.
        /// </summary>
        [JsonProperty("textAlign", NullValueHandling = NullValueHandling.Ignore)]
        public string TextAlign { get; set; }

        /// <summary>
        /// The text-align-last CSS property describes how the last line of a block element or
        /// a line before line break is aligned in its parent block element.
        /// </summary>
        [JsonProperty("textAlignLast", NullValueHandling = NullValueHandling.Ignore)]
        public string TextAlignLast { get; set; }

        /// <summary>
        /// The text-decoration CSS property is used to set the text formatting to underline,
        /// overline, line-through or blink. underline and overline decorations are positioned
        /// under the text, line-through over it.
        /// </summary>
        [JsonProperty("textDecoration", NullValueHandling = NullValueHandling.Ignore)]
        public string TextDecoration { get; set; }

        /// <summary>
        /// Sets the color of any text decoration, such as underlines, overlines, and strike
        /// throughs.
        /// </summary>
        [JsonProperty("textDecorationColor", NullValueHandling = NullValueHandling.Ignore)]
        public string TextDecorationColor { get; set; }

        /// <summary>
        /// Sets what kind of line decorations are added to an element, such as underlines,
        /// overlines, etc.
        /// </summary>
        [JsonProperty("textDecorationLine", NullValueHandling = NullValueHandling.Ignore)]
        public string TextDecorationLine { get; set; }

        /// <summary>
        /// Specifies what parts of an element’s content are skipped over when applying any
        /// text decoration.
        /// </summary>
        [JsonProperty("textDecorationSkip", NullValueHandling = NullValueHandling.Ignore)]
        public string TextDecorationSkip { get; set; }

        /// <summary>
        /// This property specifies the style of the text decoration line drawn on the
        /// specified element. The intended meaning for the values are the same as those of
        /// the border-style-properties.
        /// </summary>
        [JsonProperty("textDecorationStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string TextDecorationStyle { get; set; }

        /// <summary>
        /// The text-emphasis property will apply special emphasis marks to the elements text.
        /// Slightly similar to the text-decoration property only that this property can have
        /// affect on the line-height. It also is noted that this is shorthand for
        /// text-emphasis-style and for text-emphasis-color.
        /// </summary>
        [JsonProperty("textEmphasis", NullValueHandling = NullValueHandling.Ignore)]
        public string TextEmphasis { get; set; }

        /// <summary>
        /// The text-emphasis-color property specifies the foreground color of the emphasis
        /// marks.
        /// </summary>
        [JsonProperty("textEmphasisColor", NullValueHandling = NullValueHandling.Ignore)]
        public string TextEmphasisColor { get; set; }

        /// <summary>
        /// The text-emphasis-style property applies special emphasis marks to an element's
        /// text.
        /// </summary>
        [JsonProperty("textEmphasisStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string TextEmphasisStyle { get; set; }

        /// <summary>
        /// This property helps determine an inline box's block-progression dimension, derived
        /// from the text-height and font-size properties for non-replaced elements, the height
        /// or the width for replaced elements, and the stacked block-progression dimension for
        /// inline-block elements. The block-progression dimension determines the position of
        /// the padding, border and margin for the element.
        /// </summary>
        [JsonProperty("textHeight", NullValueHandling = NullValueHandling.Ignore)]
        public string TextHeight { get; set; }

        /// <summary>
        /// Specifies the amount of space horizontally that should be left on the first line of
        /// the text of an element. This horizontal spacing is at the beginning of the first
        /// line and is in respect to the left edge of the containing block box.
        /// </summary>
        [JsonProperty("textIndent", NullValueHandling = NullValueHandling.Ignore)]
        public string TextIndent { get; set; }

        /// <summary>
        /// The text-overflow shorthand CSS property determines how overflowed content that is
        /// not displayed is signaled to the users. It can be clipped, display an ellipsis
        /// ('…', U+2026 HORIZONTAL ELLIPSIS) or a Web author-defined string. It covers the
        /// two long-hand properties text-overflow-mode and text-overflow-ellipsis
        /// </summary>
        [JsonProperty("textOverflow", NullValueHandling = NullValueHandling.Ignore)]
        public string TextOverflow { get; set; }

        /// <summary>
        /// The text-overline property is the shorthand for the text-overline-style,
        /// text-overline-width, text-overline-color, and text-overline-mode properties.
        /// </summary>
        [JsonProperty("textOverline", NullValueHandling = NullValueHandling.Ignore)]
        public string TextOverline { get; set; }

        /// <summary>
        /// Specifies the line color for the overline text decoration.
        /// </summary>
        [JsonProperty("textOverlineColor", NullValueHandling = NullValueHandling.Ignore)]
        public string TextOverlineColor { get; set; }

        /// <summary>
        /// Sets the mode for the overline text decoration, determining whether the text
        /// decoration affects the space characters or not.
        /// </summary>
        [JsonProperty("textOverlineMode", NullValueHandling = NullValueHandling.Ignore)]
        public string TextOverlineMode { get; set; }

        /// <summary>
        /// Specifies the line style for overline text decoration.
        /// </summary>
        [JsonProperty("textOverlineStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string TextOverlineStyle { get; set; }

        /// <summary>
        /// Specifies the line width for the overline text decoration.
        /// </summary>
        [JsonProperty("textOverlineWidth", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? TextOverlineWidth { get; set; }

        /// <summary>
        /// The text-rendering CSS property provides information to the browser about how to
        /// optimize when rendering text. Options are: legibility, speed or geometric precision.
        /// </summary>
        [JsonProperty("textRendering", NullValueHandling = NullValueHandling.Ignore)]
        public string TextRendering { get; set; }

        /// <summary>
        /// The CSS text-shadow property applies one or more drop shadows to the text and
        /// <text-decorations> of an element. Each shadow is specified as an offset from the
        /// text, along with optional color and blur radius values.
        /// </summary>
        [JsonProperty("textShadow", NullValueHandling = NullValueHandling.Ignore)]
        public string TextShadow { get; set; }

        /// <summary>
        /// This property transforms text for styling purposes. (It has no effect on the
        /// underlying content.)
        /// </summary>
        [JsonProperty("textTransform", NullValueHandling = NullValueHandling.Ignore)]
        public string TextTransform { get; set; }

        /// <summary>
        /// Unsupported.
        /// This property will add a underline position value to the element that has an
        /// underline defined.
        /// </summary>
        [JsonProperty("textUnderlinePosition", NullValueHandling = NullValueHandling.Ignore)]
        public string TextUnderlinePosition { get; set; }

        /// <summary>
        /// After review this should be replaced by text-decoration should it not?
        /// This property will set the underline style for text with a line value for
        /// underline, overline, and line-through.
        /// </summary>
        [JsonProperty("textUnderlineStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string TextUnderlineStyle { get; set; }

        /// <summary>
        /// This property specifies how far an absolutely positioned box's top margin edge is
        /// offset below the top edge of the box's containing block. For relatively positioned
        /// boxes, the offset is with respect to the top edges of the box itself (i.e., the box
        /// is given a position in the normal flow, then offset from that position according to
        /// these properties).
        /// </summary>
        [JsonProperty("top", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Top { get; set; }

        /// <summary>
        /// Determines whether touch input may trigger default behavior supplied by the user
        /// agent, such as panning or zooming.
        /// </summary>
        [JsonProperty("touchAction", NullValueHandling = NullValueHandling.Ignore)]
        public string TouchAction { get; set; }

        /// <summary>
        /// CSS transforms allow elements styled with CSS to be transformed in two-dimensional
        /// or three-dimensional space. Using this property, elements can be translated,
        /// rotated, scaled, and skewed. The value list may consist of 2D and/or 3D transform
        /// values.
        /// </summary>
        [JsonProperty("transform", NullValueHandling = NullValueHandling.Ignore)]
        public string Transform { get; set; }

        /// <summary>
        /// This property defines the origin of the transformation axes relative to the element
        /// to which the transformation is applied.
        /// </summary>
        [JsonProperty("transformOrigin", NullValueHandling = NullValueHandling.Ignore)]
        public string TransformOrigin { get; set; }

        /// <summary>
        /// This property allows you to define the relative position of the origin of the
        /// transformation grid along the z-axis.
        /// </summary>
        [JsonProperty("transformOriginZ", NullValueHandling = NullValueHandling.Ignore)]
        public string TransformOriginZ { get; set; }

        /// <summary>
        /// This property specifies how nested elements are rendered in 3D space relative to their
        /// parent.
        /// </summary>
        [JsonProperty("transformStyle", NullValueHandling = NullValueHandling.Ignore)]
        public string TransformStyle { get; set; }

        /// <summary>
        /// The transition CSS property is a shorthand property for transition-property,
        /// transition-duration, transition-timing-function, and transition-delay. It allows to
        /// define the transition between two states of an element.
        /// </summary>
        [JsonProperty("transition", NullValueHandling = NullValueHandling.Ignore)]
        public string Transition { get; set; }

        /// <summary>
        /// Defines when the transition will start. A value of ‘0s’ means the transition will
        /// execute as soon as the property is changed. Otherwise, the value specifies an
        /// offset from the moment the property is changed, and the transition will delay
        /// execution by that offset.
        /// </summary>
        [JsonProperty("transitionDelay", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitionDelay { get; set; }

        /// <summary>
        /// The 'transition-duration' property specifies the length of time a transition
        /// animation takes to complete.
        /// </summary>
        [JsonProperty("transitionDuration", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitionDuration { get; set; }

        /// <summary>
        /// The 'transition-property' property specifies the name of the CSS property to which
        /// the transition is applied.
        /// </summary>
        [JsonProperty("transitionProperty", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitionProperty { get; set; }

        /// <summary>
        /// Sets the pace of action within a transition
        /// </summary>
        [JsonProperty("transitionTimingFunction", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitionTimingFunction { get; set; }

        /// <summary>
        /// The unicode-bidi CSS property specifies the level of embedding with respect to the
        /// bidirectional algorithm.
        /// </summary>
        [JsonProperty("unicodeBidi", NullValueHandling = NullValueHandling.Ignore)]
        public string UnicodeBidi { get; set; }

        /// <summary>
        /// This is for all the high level UX stuff.
        /// </summary>
        [JsonProperty("userFocus", NullValueHandling = NullValueHandling.Ignore)]
        public string UserFocus { get; set; }

        /// <summary>
        /// For inputing user content
        /// </summary>
        [JsonProperty("userInput", NullValueHandling = NullValueHandling.Ignore)]
        public string UserInput { get; set; }

        /// <summary>
        /// Defines the text selection behavior.
        /// </summary>
        [JsonProperty("userSelect", NullValueHandling = NullValueHandling.Ignore)]
        public UserSelect? UserSelect { get; set; }

        /// <summary>
        /// The vertical-align property controls how inline elements or text are vertically
        /// aligned compared to the baseline. If this property is used on table-cells it
        /// controls the vertical alignment of content of the table cell.
        /// </summary>
        [JsonProperty("verticalAlign", NullValueHandling = NullValueHandling.Ignore)]
        public string VerticalAlign { get; set; }

        /// <summary>
        /// The visibility property specifies whether the boxes generated by an element are rendered.
        /// </summary>
        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        public string Visibility { get; set; }

        /// <summary>
        /// The voice-balance property sets the apparent position (in stereo sound) of the
        /// synthesized voice for spoken media.
        /// </summary>
        [JsonProperty("voiceBalance", NullValueHandling = NullValueHandling.Ignore)]
        public string VoiceBalance { get; set; }

        /// <summary>
        /// The voice-duration property allows the author to explicitly set the amount of time
        /// it should take a speech synthesizer to read an element's content, for example to
        /// allow the speech to be synchronized with other media. With a value of auto (the
        /// default) the length of time it takes to read the content is determined by the
        /// content itself and the voice-rate property.
        /// </summary>
        [JsonProperty("voiceDuration", NullValueHandling = NullValueHandling.Ignore)]
        public string VoiceDuration { get; set; }

        /// <summary>
        /// The voice-family property sets the speaker's voice used by a speech media agent to
        /// read an element. The speaker may be specified as a named character (to match a
        /// voice option in the speech reading software) or as a generic description of the
        /// age and gender of the voice. Similar to the font-family property for visual media,
        /// a comma-separated list of fallback options may be given in case the speech reader
        /// does not recognize the character name or cannot synthesize the requested combination
        /// of generic properties.
        /// </summary>
        [JsonProperty("voiceFamily", NullValueHandling = NullValueHandling.Ignore)]
        public string VoiceFamily { get; set; }

        /// <summary>
        /// The voice-pitch property sets pitch or tone (high or low) for the synthesized speech
        /// when reading an element; the pitch may be specified absolutely or relative to the
        /// normal pitch for the voice-family used to read the text.
        /// </summary>
        [JsonProperty("voicePitch", NullValueHandling = NullValueHandling.Ignore)]
        public string VoicePitch { get; set; }

        /// <summary>
        /// The voice-range property determines how much variation in pitch or tone will be
        /// created by the speech synthesize when reading an element. Emphasized text,
        /// grammatical structures and punctuation may all be rendered as changes in pitch,
        /// this property determines how strong or obvious those changes are; large ranges are
        /// associated with enthusiastic or emotional speech, while small ranges are associated
        /// with flat or mechanical speech.
        /// </summary>
        [JsonProperty("voiceRange", NullValueHandling = NullValueHandling.Ignore)]
        public string VoiceRange { get; set; }

        /// <summary>
        /// The voice-rate property sets the speed at which the voice synthesized by a speech
        /// media agent will read content.
        /// </summary>
        [JsonProperty("voiceRate", NullValueHandling = NullValueHandling.Ignore)]
        public string VoiceRate { get; set; }

        /// <summary>
        /// The voice-stress property sets the level of vocal emphasis to be used for
        /// synthesized speech reading the element.
        /// </summary>
        [JsonProperty("voiceStress", NullValueHandling = NullValueHandling.Ignore)]
        public string VoiceStress { get; set; }

        /// <summary>
        /// The voice-volume property sets the volume for spoken content in speech media. It
        /// replaces the deprecated volume property.
        /// </summary>
        [JsonProperty("voiceVolume", NullValueHandling = NullValueHandling.Ignore)]
        public string VoiceVolume { get; set; }

        /// <summary>
        /// (Webkit specific) font smoothing directive.
        /// </summary>
        [JsonProperty("WebkitFontSmoothing", NullValueHandling = NullValueHandling.Ignore)]
        public FontSmoothing? WebkitFontSmoothing { get; set; }

        /// <summary>
        /// (Webkit specific) momentum scrolling on iOS devices
        /// </summary>
        [JsonProperty("WebkitOverflowScrolling", NullValueHandling = NullValueHandling.Ignore)]
        public WebkitOverflowScrolling? WebkitOverflowScrolling { get; set; }

        /// <summary>
        /// The white-space property controls whether and how white space inside the element is
        /// collapsed, and whether lines may wrap at unforced "soft wrap" opportunities.
        /// </summary>
        [JsonProperty("whiteSpace", NullValueHandling = NullValueHandling.Ignore)]
        public string WhiteSpace { get; set; }

        /// <summary>
        /// In paged media, this property defines the mimimum number of lines that must be left
        /// at the top of the second page.
        /// See CSS 3 orphans, widows properties
        /// https://drafts.csswg.org/css-break-3/#widows-orphans
        /// </summary>
        [JsonProperty("widows", NullValueHandling = NullValueHandling.Ignore)]
        public FillOpacity? Widows { get; set; }

        /// <summary>
        /// Specifies the width of the content area of an element. The content area of the element
        /// width does not include the padding, border, and margin of the element.
        /// </summary>
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Width { get; set; }

        /// <summary>
        /// The word-break property is often used when there is long generated content that is
        /// strung together without and spaces or hyphens to beak apart. A common case of this
        /// is when there is a long URL that does not have any hyphens. This case could
        /// potentially cause the breaking of the layout as it could extend past the parent
        /// element.
        /// </summary>
        [JsonProperty("wordBreak", NullValueHandling = NullValueHandling.Ignore)]
        public string WordBreak { get; set; }

        /// <summary>
        /// The word-spacing CSS property specifies the spacing behavior between "words".
        /// </summary>
        [JsonProperty("wordSpacing", NullValueHandling = NullValueHandling.Ignore)]
        public string WordSpacing { get; set; }

        /// <summary>
        /// An alias of css/properties/overflow-wrap, word-wrap defines whether to break
        /// words when the content exceeds the boundaries of its container.
        /// </summary>
        [JsonProperty("wordWrap", NullValueHandling = NullValueHandling.Ignore)]
        public string WordWrap { get; set; }

        /// <summary>
        /// Specifies how exclusions affect inline content within block-level elements. Elements
        /// lay out their inline content in their content area but wrap around exclusion areas.
        /// </summary>
        [JsonProperty("wrapFlow", NullValueHandling = NullValueHandling.Ignore)]
        public string WrapFlow { get; set; }

        /// <summary>
        /// Set the value that is used to offset the inner wrap shape from other shapes. Inline
        /// content that intersects a shape with this property will be pushed by this shape's
        /// margin.
        /// </summary>
        [JsonProperty("wrapMargin", NullValueHandling = NullValueHandling.Ignore)]
        public string WrapMargin { get; set; }

        /// <summary>
        /// writing-mode specifies if lines of text are laid out horizontally or vertically,
        /// and the direction which lines of text and blocks progress.
        /// </summary>
        [JsonProperty("writingMode", NullValueHandling = NullValueHandling.Ignore)]
        public string WritingMode { get; set; }

        /// <summary>
        /// The z-index property specifies the z-order of an element and its descendants.
        /// When elements overlap, z-order determines which one covers the other.
        /// See CSS 2 z-index property https://www.w3.org/TR/CSS2/visuren.html#z-index
        /// </summary>
        [JsonProperty("zIndex", NullValueHandling = NullValueHandling.Ignore)]
        public ColumnCountUnion? ZIndex { get; set; }

        /// <summary>
        /// Sets the initial zoom factor of a document defined by @viewport.
        /// See CSS zoom descriptor https://drafts.csswg.org/css-device-adapt/#zoom-desc
        /// </summary>
        [JsonProperty("zoom", NullValueHandling = NullValueHandling.Ignore)]
        public CssValue? Zoom { get; set; }
    }

   
}
