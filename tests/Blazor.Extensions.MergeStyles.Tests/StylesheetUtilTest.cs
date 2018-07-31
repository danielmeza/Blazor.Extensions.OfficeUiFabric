using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles.Tests
{
    [TestClass]
    public class StylesheetUtilTest : BaseTest
    {
        public StylesheetUtilTest()
        {
            this.Init();
        }
        private static Stylesheet _stylesheet;

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {

            _stylesheet = await Stylesheet.GetInstance();
            _stylesheet.SetConfig(new StyleSheetConfig() { InjectionMode = InjectionMode.None });

        }

        [TestInitialize]
        public void TestInitialize()
        {
            _stylesheet.Reset();
        }

        [TestMethod]
        public async Task CanRegisterClassesAndAvoidReRegistering()
        {

            var className = await StylesheetUtil.StyleToClassName(new Style { Background = "red" });

            Assert.AreEqual("css-0", className, $"Bad generated class name, expected css-0 and get {className}");
            Assert.AreEqual(".css-0{background:red;}", _stylesheet.GetRules());

            className = await StylesheetUtil.StyleToClassName(new Style { Background = "red" });

            Assert.AreEqual("css-0", className, $"Bad generated class name, expected css-0 and get {className}");
            Assert.AreEqual(".css-0{background:red;}", _stylesheet.GetRules());

            className = await StylesheetUtil.StyleToClassName(new Style { Background = "green" });

            Assert.AreEqual("css-1", className, $"Bad generated class name, expected css-0 and get {className}");
            Assert.AreEqual(".css-0{background:red;}.css-1{background:green;}", _stylesheet.GetRules());
        }

        [TestMethod]

        public async Task CanHaveChildSelector()
        {
            _stylesheet.Reset();
            var className = await StylesheetUtil.StyleToClassName(new Style
            {
                Selectors = new Dictionary<string, Style>
                {
                    [".foo"] = new Style { Background = "red" }
                }
            });

            Assert.AreEqual(".css-0 .foo{background:red;}", _stylesheet.GetRules());
        }
        [TestMethod]
        public async Task CanRegisterPseduoSelectors()
        {
            var className = await StylesheetUtil.StyleToClassName(new Style
            {
                Selectors =
                {
                    [":hover"] = new Style { Background = "red" }
                }
            });



            Assert.AreEqual("css-0", className, $"Bad generated class name, expected css-0 and get {className}");

            Assert.AreEqual(".css-0:hover{background:red;}", _stylesheet.GetRules());
        }
        [TestMethod]
        public async Task CanRegisterParentAndSiblinSelectors()
        {
            var style = new Style
            {
                Selectors = new Dictionary<string, Style>
                {
                    ["& .child"] = new Style { Background = "red" },
                    [".parent &"] = new Style { Background = "green" }
                }
            };
            var className = await StylesheetUtil.StyleToClassName(style);


            Assert.AreEqual("css-0", className, $"Bad generated class name, expected css-0 and get {className}");
            Assert.AreEqual(".css-0 .child{background:red;}.parent .css-0{background:green;}", _stylesheet.GetRules());
        }

        [TestMethod]
        public async Task CanMergeTools()
        {
            var className = await StylesheetUtil.StyleToClassName(
     null,
     false,
     null,
     new Style
     { BackgroundColor = "red", Color = "white" },
    new Style { BackgroundColor = "green" }
    );


            Assert.AreEqual("css-0", className, $"Bad generated class name, expected css-0 and get {className}");
            Assert.AreEqual(".css-0{background-color:green;color:white;}", _stylesheet.GetRules());

            className = await StylesheetUtil.StyleToClassName(new Style { BackgroundColor = "green", Color = "white" });
            Assert.AreEqual("css-0", className, $"Bad generated class name, expected css-0 and get {className}");
        }

        [TestMethod]
        public async Task ReturnBlankStringWithNoInput()
        {
            var className = await StylesheetUtil.StyleToClassName();
            Assert.AreEqual(className, "");
        }
    }
  
}
