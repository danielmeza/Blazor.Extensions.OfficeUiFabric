using Microsoft.JSInterop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles.Tests
{
    [TestClass]
    public class StylesheetTest : BaseTest
    {
        private static Stylesheet _stylessheet;

        [ClassInitialize]
        public static async Task Initialize(TestContext context)
        {
            Initialize();
            _stylessheet = await Stylesheet.GetInstance();
            _stylessheet.SetConfig(new StyleSheetConfig { InjectionMode = InjectionMode.None, DefaultPrefix = "myCss" });

        }

        [TestMethod]
        [Description("supports overriding the default prefix")]
        public async Task SupportOverridingThedefaultPrefix()
        {
            VendorSettings.SetCurrent(new VendorSettings() { IsWebKit = true });

            //Arrange
            var className = await StylesheetUtil.StyleToClassName(new Style { Background = "red" });
            Assert.AreEqual(className, "myCss-0");
            Assert.AreEqual(".myCss-0{background:red;}", _stylessheet.GetRules());
            VendorSettings.SetCurrent(null);

        }
    }
}
