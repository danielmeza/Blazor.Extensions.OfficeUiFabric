namespace Blazor.OfficeUiFabric.Styling
{
    public class DefaultPalette : Palette
    {
        #region Public Fields

        public const string DefaultAccent = "#0078d4";

        public const string DefaultBlack = "#000000";

        public const string DefaultBlackTranslucent40 = "rgba(0,0,0,.4)";

        public const string DefaultBlue = "#0078d4";

        public const string DefaultBlueDark = "#002050";

        public const string DefaultBlueLight = "#00bcf2";

        public const string DefaultBlueMid = "#00188f";

        public const string DefaultGreen = "#107c10";

        public const string DefaultGreenDark = "#004b1c";

        public const string DefaultGreenLight = "#bad80a";

        public const string DefaultMagenta = "#b4009e";

        public const string DefaultMagentaDark = "#5c005c";

        public const string DefaultMagentaLight = "#e3008c";

        public const string DefaultNeutralDark = "#212121";

        public const string DefaultNeutralLight = "#eaeaea";

        public const string DefaultNeutralLighter = "#f4f4f4";

        public const string DefaultNeutralLighterAlt = "#f8f8f8";

        public const string DefaultNeutralPrimary = "#333333";

        public const string DefaultNeutralPrimaryAlt = "#3c3c3c";

        public const string DefaultNeutralQuaternary = "#d0d0d0";

        public const string DefaultNeutralQuaternaryAlt = "#dadada";

        public const string DefaultNeutralSecondary = "#666666";

        public const string DefaultNeutralSecondaryAlt = "#767676";

        public const string DefaultNeutralTertiary = "#a6a6a6";

        public const string DefaultNeutralTertiaryAlt = "#c8c8c8";

        public const string DefaultOrange = "#d83b01";

        public const string DefaultOrangeLight = "#ea4300";

        public const string DefaultOrangeLighter = "#ff8c00";

        public const string DefaultPurple = "#5c2d91";

        public const string DefaultPurpleDark = "#32145a";

        public const string DefaultPurpleLight = "#b4a0ff";

        public const string DefaultRed = "#e81123";

        public const string DefaultRedDark = "#a80000";

        public const string DefaultTeal = "#008272";

        public const string DefaultTealDark = "#004b50";

        public const string DefaultTealLight = "#00b294";

        public const string DefaultThemeDark = "#005a9e";

        public const string DefaultThemeDarkAlt = "#106ebe";

        public const string DefaultThemeDarker = "#004578";

        public const string DefaultThemeLight = "#c7e0f4";

        public const string DefaultThemeLighter = "#deecf9";

        public const string DefaultThemeLighterAlt = "#eff6fc";

        public const string DefaultThemePrimary = "#0078d4";

        public const string DefaultThemeSecondary = "#2b88d8";

        public const string DefaultThemeTertiary = "#71afe5";

        public const string DefaultWhite = "#ffffff";

        public const string DefaultWhiteTranslucent40 = "rgba(255,255,255,.4)";

        public const string DefaultYellow = "#ffb900";

        public const string DefaultYellowLight = "#fff100";

        public override string Accent { get => this.accent ?? DefaultAccent; set => this.accent = value; }
        public override string Black { get => this.black ?? DefaultBlack; set => this.black = value; }
        public override string BlackTranslucent40 { get => this.blackTranslucent40 ?? DefaultBlackTranslucent40; set => this.blackTranslucent40 = value; }
        public override string Blue { get => this.blue ?? DefaultBlue; set => this.blue = value; }
        public override string BlueDark { get => this.blueDark ?? DefaultBlueDark; set => this.blueDark = value; }
        public override string BlueLight { get => this.blueLight ?? DefaultBlueLight; set => this.blueLight = value; }
        public override string BlueMid { get => this.blueMid ?? DefaultBlueMid; set => this.blueMid = value; }
        public override string Green { get => this.green ?? DefaultGreen; set => this.green = value; }
        public override string GreenDark { get => this.greenDark ?? DefaultGreenDark; set => this.greenDark = value; }
        public override string GreenLight { get => this.greenLight ?? DefaultGreenLight; set => this.greenLight = value; }
        public override string Magenta { get => this.magenta ?? DefaultMagenta; set => this.magenta = value; }
        public override string MagentaDark { get => this.magentaDark ?? DefaultMagentaDark; set => this.magentaDark = value; }
        public override string MagentaLight { get => this.magentaLight ?? DefaultMagentaLight; set => this.magentaLight = value; }
        public override string NeutralDark { get => this.neutralDark ?? DefaultNeutralDark; set => this.neutralDark = value; }
        public override string NeutralLight { get => this.neutralLight ?? DefaultNeutralLight; set => this.neutralLight = value; }
        public override string NeutralLighter { get => this.neutralLighter ?? DefaultNeutralLighter; set => this.neutralLighter = value; }
        public override string NeutralLighterAlt { get => this.neutralLighterAlt ?? DefaultNeutralLighterAlt; set => this.neutralLighterAlt = value; }
        public override string NeutralPrimary { get => this.neutralPrimary ?? DefaultNeutralPrimary; set => this.neutralPrimary = value; }
        public override string NeutralPrimaryAlt { get => this.neutralPrimaryAlt ?? DefaultNeutralPrimaryAlt; set => this.neutralPrimaryAlt = value; }
        public override string NeutralQuaternary { get => this.neutralQuaternary ?? DefaultNeutralQuaternary; set => this.neutralQuaternary = value; }
        public override string NeutralQuaternaryAlt { get => this.neutralQuaternaryAlt ?? DefaultNeutralQuaternaryAlt; set => this.neutralQuaternaryAlt = value; }
        public override string NeutralSecondary { get => this.neutralSecondary ?? DefaultNeutralSecondary; set => this.neutralSecondary = value; }
        public override string NeutralSecondaryAlt { get => this.neutralSecondaryAlt ?? DefaultNeutralSecondaryAlt; set => this.neutralSecondaryAlt = value; }
        public override string NeutralTertiary { get => this.neutralTertiary ?? DefaultNeutralTertiary; set => this.neutralTertiary = value; }
        public override string NeutralTertiaryAlt { get => this.neutralTertiaryAlt ?? DefaultNeutralTertiaryAlt; set => this.neutralTertiaryAlt = value; }
        public override string Orange { get => this.orange ?? DefaultOrange; set => this.orange = value; }
        public override string OrangeLight { get => this.orangeLight ?? DefaultOrangeLight; set => this.orangeLight = value; }
        public override string OrangeLighter { get => this.orangeLighter ?? DefaultOrangeLighter; set => this.orangeLighter = value; }
        public override string Purple { get => this.purple ?? DefaultPurple; set => this.purple = value; }
        public override string PurpleDark { get => this.purpleDark ?? DefaultPurpleDark; set => this.purpleDark = value; }
        public override string PurpleLight { get => this.purpleLight ?? DefaultPurpleLight; set => this.purpleLight = value; }
        public override string Red { get => this.red ?? DefaultRed; set => this.red = value; }
        public override string RedDark { get => this.redDark ?? DefaultRedDark; set => this.redDark = value; }
        public override string Teal { get => this.teal ?? DefaultTeal; set => this.teal = value; }
        public override string TealDark { get => this.tealDark ?? DefaultTealDark; set => this.tealDark = value; }
        public override string TealLight { get => this.tealLight ?? DefaultTealLight; set => this.tealLight = value; }
        public override string ThemeDark { get => this.themeDark ?? DefaultThemeDark; set => this.themeDark = value; }
        public override string ThemeDarkAlt { get => this.themeDarkAlt ?? DefaultThemeDarkAlt; set => this.themeDarkAlt = value; }
        public override string ThemeDarker { get => this.themeDarker ?? DefaultThemeDarker; set => this.themeDarker = value; }
        public override string ThemeLight { get => this.themeLight ?? DefaultThemeLight; set => this.themeLight = value; }
        public override string ThemeLighter { get => this.themeLighter ?? DefaultThemeLighter; set => this.themeLighter = value; }
        public override string ThemeLighterAlt { get => this.themeLighterAlt ?? DefaultThemeLighterAlt; set => this.themeLighterAlt = value; }
        public override string ThemePrimary { get => this.themePrimary ?? DefaultThemePrimary; set => this.themePrimary = value; }
        public override string ThemeSecondary { get => this.themeSecondary ?? DefaultThemeSecondary; set => this.themeSecondary = value; }
        public override string ThemeTertiary { get => this.themeTertiary ?? DefaultThemeTertiary; set => this.themeTertiary = value; }
        public override string White { get => this.white ?? DefaultWhite; set => this.white = value; }
        public override string WhiteTranslucent40 { get => this.whiteTranslucent40 ?? DefaultWhiteTranslucent40; set => this.whiteTranslucent40 = value; }
        public override string Yellow { get => this.yellow ?? DefaultYellow; set => this.yellow = value; }
        public override string YellowLight { get => this.yellowLight ?? DefaultYellowLight; set => this.yellowLight = value; }

        #endregion Public Fields
    }
}