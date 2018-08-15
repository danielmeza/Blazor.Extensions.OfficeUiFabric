namespace Blazor.OfficeUiFabric.Styling
{
    /// <summary>
    /// UI Fabric color palette.
    /// </summary>
    public abstract class Palette
    {
        protected string accent;
        protected string black;
        protected string blackTranslucent40;
        protected string blue;
        protected string blueDark;
        protected string blueLight;
        protected string blueMid;
        protected string green;
        protected string yellowLight;
        protected string yellow;
        protected string whiteTranslucent40;
        protected string white;
        protected string themeTertiary;
        protected string themeSecondary;
        protected string themePrimary;
        protected string themeLighterAlt;
        protected string themeLighter;
        protected string themeLight;
        protected string themeDarker;
        protected string themeDarkAlt;
        protected string themeDark;
        protected string tealLight;
        protected string tealDark;
        protected string teal;
        protected string redDark;
        protected string red;
        protected string purpleLight;
        protected string purpleDark;
        protected string purple;
        protected string orangeLighter;
        protected string orangeLight;
        protected string orange;
        protected string neutralTertiaryAlt;
        protected string neutralTertiary;
        protected string neutralSecondaryAlt;
        protected string neutralSecondary;
        protected string neutralQuaternaryAlt;
        protected string neutralQuaternary;
        protected string neutralPrimaryAlt;
        protected string neutralPrimary;
        protected string neutralLighterAlt;
        protected string neutralLighter;
        protected string neutralLight;
        protected string neutralDark;
        protected string magentaLight;
        protected string magentaDark;
        protected string magenta;
        protected string greenLight;
        protected string greenDark;

        /// <summary>
        /// Color code for the accent.
        /// </summary>
        public abstract string Accent { get; set; }

        /// <summary>
        /// Color code for the strongest color, which is black in the default theme. This is a very
        /// light color in inverted themes.
        /// </summary>
        public abstract string Black { get; set; }

        /// <summary>
        /// Color code for blackTranslucent40.
        /// </summary>
        public abstract string BlackTranslucent40 { get; set; }

        /// <summary>
        /// Color code for blue.
        /// </summary>
        public abstract string Blue { get; set; }

        /// <summary>
        /// Color code for blueDark.
        /// </summary>
        public abstract string BlueDark { get; set; }

        /// <summary>
        /// Color code for blueLight.
        /// </summary>
        public abstract string BlueLight { get; set; }

        /// <summary>
        /// Color code for blueMid.
        /// </summary>
        public abstract string BlueMid { get; set; }

        /// <summary>
        /// Color code for green.
        /// </summary>
        public abstract string Green { get; set; }

        /// <summary>
        /// Color code for greenDark.
        /// </summary>
        public abstract string GreenDark { get; set; }

        /// <summary>
        /// Color code for greenLight.
        /// </summary>
        public abstract string GreenLight { get; set; }

        /// <summary>
        /// Color code for magenta.
        /// </summary>
        public abstract string Magenta { get; set; }

        /// <summary>
        /// Color code for magentaDark.
        /// </summary>
        public abstract string MagentaDark { get; set; }

        /// <summary>
        /// Color code for magentaLight.
        /// </summary>
        public abstract string MagentaLight { get; set; }

        /// <summary>
        /// Color code for neutralDark.
        /// </summary>
        public abstract string NeutralDark { get; set; }

        /// <summary>
        /// Color code for neutralLight.
        /// </summary>
        public abstract string NeutralLight { get; set; }

        /// <summary>
        /// Color code for neutralLighter.
        /// </summary>
        public abstract string NeutralLighter { get; set; }

        /// <summary>
        /// Color code for neutralLighterAlt.
        /// </summary>
        public abstract string NeutralLighterAlt { get; set; }

        /// <summary>
        /// Color code for neutralPrimary.
        /// </summary>
        public abstract string NeutralPrimary { get; set; }

        /// <summary>
        /// Color code for neutralPrimaryAlt.
        /// </summary>
        public abstract string NeutralPrimaryAlt { get; set; }

        /// <summary>
        /// Color code for neutralQuaternary.
        /// </summary>
        public abstract string NeutralQuaternary { get; set; }

        /// <summary>
        /// Color code for neutralQuaternaryAlt.
        /// </summary>
        public abstract string NeutralQuaternaryAlt { get; set; }

        /// <summary>
        /// Color code for neutralSecondary.
        /// </summary>
        public abstract string NeutralSecondary { get; set; }

        /// <summary>
        /// Color code for neutralSecondaryAlt.
        /// </summary>
        public abstract string NeutralSecondaryAlt { get; set; }

        /// <summary>
        /// Color code for neutralTertiary.
        /// </summary>
        public abstract string NeutralTertiary { get; set; }

        /// <summary>
        /// Color code for neutralTertiaryAlt.
        /// </summary>
        public abstract string NeutralTertiaryAlt { get; set; }

        /// <summary>
        /// Color code for orange.
        /// </summary>
        public abstract string Orange { get; set; }

        /// <summary>
        /// Color code for orangeLight.
        /// </summary>
        public abstract string OrangeLight { get; set; }

        /// <summary>
        /// Color code for orangeLighter.
        /// </summary>
        public abstract string OrangeLighter { get; set; }

        /// <summary>
        /// Color code for purple.
        /// </summary>
        public abstract string Purple { get; set; }

        /// <summary>
        /// Color code for purpleDark.
        /// </summary>
        public abstract string PurpleDark { get; set; }

        /// <summary>
        /// Color code for purpleLight.
        /// </summary>
        public abstract string PurpleLight { get; set; }

        /// <summary>
        /// Color code for red.
        /// </summary>
        public abstract string Red { get; set; }

        /// <summary>
        /// Color code for redDark.
        /// </summary>
        public abstract string RedDark { get; set; }

        /// <summary>
        /// Color code for teal.
        /// </summary>
        public abstract string Teal { get; set; }

        /// <summary>
        /// Color code for tealDark.
        /// </summary>
        public abstract string TealDark { get; set; }

        /// <summary>
        /// Color code for tealLight.
        /// </summary>
        public abstract string TealLight { get; set; }

        /// <summary>
        /// Color code for themeDark.
        /// </summary>
        public abstract string ThemeDark { get; set; }

        /// <summary>
        /// Color code for themeDarkAlt.
        /// </summary>
        public abstract string ThemeDarkAlt { get; set; }

        /// <summary>
        /// Color code for themeDarker.
        /// </summary>
        public abstract string ThemeDarker { get; set; }

        /// <summary>
        /// Color code for themeLight.
        /// </summary>
        public abstract string ThemeLight { get; set; }

        /// <summary>
        /// Color code for themeLighter.
        /// </summary>
        public abstract string ThemeLighter { get; set; }

        /// <summary>
        /// Color code for themeLighterAlt.
        /// </summary>
        public abstract string ThemeLighterAlt { get; set; }

        /// <summary>
        /// Color code for themePrimary.
        /// </summary>
        public abstract string ThemePrimary { get; set; }

        /// <summary>
        /// Color code for themeSecondary.
        /// </summary>
        public abstract string ThemeSecondary { get; set; }

        /// <summary>
        /// Color code for themeTertiary.
        /// </summary>
        public abstract string ThemeTertiary { get; set; }

        /// <summary>
        /// Color code for the softest color, which is white in the default theme. This is a very
        /// dark color in dark themes. This is the page background.
        /// </summary>
        public abstract string White { get; set; }

        /// <summary>
        /// Color code for whiteTranslucent40
        /// </summary>
        public abstract string WhiteTranslucent40 { get; set; }

        /// <summary>
        /// Color code for yellow.
        /// </summary>
        public abstract string Yellow { get; set; }

        /// <summary>
        /// Color code for yellowLight.
        /// </summary>
        public abstract string YellowLight { get; set; }

        internal SemanticColors MakeSemanticColors(bool isInverted, bool depComments) => fixSlots(new SemanticColors()
        {
            BodyBackground = this.white,
            BodyFrameBackground = this.white,
            BodyFrameDivider = this.neutralLight,
            BodyText = this.neutralPrimary,
            BodyTextChecked = this.black,
            BodySubtext = this.neutralSecondary,
            BodyDivider = this.neutralTertiaryAlt,

            DisabledBackground = this.neutralLighter,
            DisabledText = this.neutralTertiary,
            DisabledBodyText = this.neutralTertiaryAlt,
            DisabledSubtext = this.neutralQuaternary,

            FocusBorder = this.black,

            ErrorText = !isInverted ? this.redDark : "#ff5f5f",
            WarningText = !isInverted ? "#333333" : "#ffffff",
            ErrorBackground = !isInverted ? "rgba(232, 17, 35, .2)" : "rgba(232, 17, 35, .5)",
            BlockingBackground = !isInverted ? "rgba(234, 67, 0, .2)" : "rgba(234, 67, 0, .5)",
            WarningBackground = !isInverted ? "rgba(255, 185, 0, .2)" : "rgba(255, 251, 0, .6)",
            WarningHighlight = !isInverted ? "#ffb900" : "#fff100",
            SuccessBackground = !isInverted ? "rgba(186, 216, 10, .2)" : "rgba(186, 216, 10, .4)",

            InputBorder = this.neutralTertiary,
            InputBorderHovered = this.neutralDark,
            InputBackground = this.white,
            InputBackgroundChecked = this.themePrimary,
            InputBackgroundCheckedHovered = this.themeDarkAlt,
            InputForegroundChecked = this.white,
            InputFocusBorderAlt = this.themePrimary,
            SmallInputBorder = this.neutralSecondary,
            InputPlaceholderText = this.neutralSecondary,

            ButtonBackground = this.neutralLighter,
            ButtonBackgroundChecked = this.neutralTertiaryAlt,
            ButtonBackgroundHovered = this.neutralLight,
            ButtonBackgroundCheckedHovered = this.neutralLight,
            ButtonBorder = "transparent",
            ButtonText = this.neutralPrimary,
            ButtonTextHovered = this.black,
            ButtonTextChecked = this.neutralDark,
            ButtonTextCheckedHovered = this.black,

            MenuItemBackgroundHovered = this.neutralLighter,
            MenuIcon = this.themePrimary,
            MenuHeader = this.themePrimary,

            ListBackground = this.white,
            ListText = this.neutralPrimary,
            ListItemBackgroundHovered = this.neutralLighter,
            ListItemBackgroundChecked = this.neutralLight,
            ListItemBackgroundCheckedHovered = this.neutralQuaternaryAlt,

            ListHeaderBackgroundHovered = this.neutralLighter,
            ListHeaderBackgroundPressed = this.neutralLight,

            Link = this.themePrimary,
            LinkHovered = this.themeDarker,

            // Deprecated slots, second pass by _fixDeprecatedSlots() later for self-referential slots
#pragma warning disable CS0618 // Type or member is obsolete
            ListTextColor = "",
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            MenuItemBackgroundChecked = this.neutralLight
#pragma warning restore CS0618 // Type or member is obsolete
        }, depComments);

        private SemanticColors fixSlots(SemanticColors s, bool depComments)
        {
            var dep = "";
            if (depComments)
            {
                dep = "/* @deprecated */";
            }

#pragma warning disable CS0618 // Type or member is obsolete
            s.ListTextColor = s.ListText + dep;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            s.MenuItemBackgroundChecked += dep;
#pragma warning restore CS0618 // Type or member is obsolete
            return s;
        }
    }
}