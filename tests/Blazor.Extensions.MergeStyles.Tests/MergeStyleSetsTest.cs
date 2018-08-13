using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles.Tests
{
    [TestClass]
    public class MergeStyleSetsTest : BaseTest
    {
        private static Stylesheet _stylesheet;

        [ClassInitialize]
        public static async Task InitClass(TestContext context)
        {
            Initialize();
            _stylesheet = await Stylesheet.GetInstance();
            _stylesheet.SetConfig(new StyleSheetConfig { InjectionMode = InjectionMode.None });
        }

        [TestInitialize]
        public void InitTest()
        {
            Initialize();
            _stylesheet.Reset();
        }
        [TestCleanup]
        public void TestClean()
        {
            _stylesheet.SetConfig(new StyleSheetConfig { InjectionMode = InjectionMode.None, DefaultPrefix = "css" });
        }

        [TestMethod]
        [Description("can merge style stets")]
        public void CanMergeStylesSet()
        {
            Func<object, StyleSetFake> fn1 = (prop) =>
            {
                return new StyleSetFake()
                {
                    Root = new Style { Background = "green", FontSize = 12 },
                };
            };

            Func<object, StyleSetFake> fn2 = (porps) =>
            {
                return new StyleSetFake
                {
                    Root = new Style
                    {
                        Background = "yellow",
                        Color = "pink"
                    }
                };
            };

            var empty = new StyleSetFake { };

            var result = StyleEngine
                .MergeStyleSets(empty,
                new StyleSetFake
                {
                    Root = new Style
                    {
                        Background = "red",
                    },
                    A = new Style
                    {
                        Background = "green"
                    },
                    SubComponentStyles =
                    {
                        ["labelStyles"] = fn1
                    }
                }, new StyleSetFake
                {
                    A = new Style
                    {
                        Background = "white"
                    },
                    B = new Style
                    {
                        Background = "blue"
                    }
                }, new StyleSetFake
                {
                    Root = new Style
                    {
                        Selectors =
                        {
                            [":hover"] = new Style
                            {
                                Background = "yellow"
                            }
                        }
                    },
                    SubComponentStyles =
                    {
                        ["labelStyles"] = fn2
                    }
                });

            Assert.AreEqual("root-0", result.Root);
            Assert.AreEqual("a-1", result.A);
            Assert.AreEqual("b-2", result.B);
            Assert.IsTrue(result.ContainsKey(("sub-component-styles", "SubComponentStyles")));

            if (result.SubComponentStyles["labelStyles"] is Func<object, StyleSetFake> function)
            {
                var mergedLabelStyles = function(new StyleSetFake { });
                Assert.AreEqual(new StyleSetFake
                {
                    Root = new Style[] { new Style { Background = "green", FontSize = 12, }, new Style { Background = "yellow", Color = "pink" } }
                }, mergedLabelStyles);

            }
            else
            {
                Assert.IsTrue(false, "The subcompoment must be a function");

            }

            Assert.AreEqual(".root-0{background:red;}.root-0:hover{background:yellow;}" + ".a-1{background:white;}" + ".b-2{background:blue;}",
                _stylesheet.GetRules());

        }

        [TestMethod]
        [Description("can merge correctly when falsey values are provided as inputs")]
        public void CanMergeWHenFalseyValues()
        {
            var result = StyleEngine
                .MergeStyleSets(null,
                new StyleSetFake
                {
                    Root = new Style { Background = "red" },
                    A = new Style { Background = "green" }
                },
                null,
                new StyleSetFake
                {
                    A = new Style { Background = "white" },
                    B = new Style { Background = "blue" }
                });

            Assert.AreEqual("root-0", result.Root);
            Assert.AreEqual("a-1", result.A);
            Assert.AreEqual("b-2", result.B);
            Assert.AreEqual(".root-0{background:red;}" + ".a-1{background:white;}" + ".b-2{background:blue;}", _stylesheet.GetRules());
        }

        [TestMethod]
        [Description("can merge correctly when all inputs are falsey")]
        public void CanMergeWhenAllInputsAraFalsy()
        {
            var result = StyleEngine.MergeStyleSets<StyleSetFake>(null, false, null);

            Assert.AreEqual(new StyleSetFake(), result);
            Assert.AreEqual("", _stylesheet.GetRules());
        }

        [TestMethod]
        [Description("can expand child selectors")]
        public void CanExpandChildSelector()
        {
      
            var result = StyleEngine.MergeStyleSets(new StyleSetFake
            {
                A = new Style
                {
                    Selectors =
                    {
                        [":hover $b"] = new Style { Background = "green" },
                        [":focus $c-foo"] = new Style{ Background = "red"},
                        [":active .d"] = new Style{ Background = "pink" }
                    }
                },
                B = new Style
                {
                    Background = "blue"
                },
                CFoo = new Style
                {

                }
            });

            Assert.AreEqual(result, new StyleSetFake
            {
                A = "a-0",
                B = "b-1",
                CFoo = "c-foo-2",
                //SubComponentStyles = new Dictionary<string, object>()
            });

            var rules = ".a-0:hover .b-1{background:green;}" +
                ".a-0:focus .c-foo-2{background:red;}" +
                ".a-0:active .d{background:pink;}" +
                ".b-1{background:blue;}";
            Assert.AreEqual(rules, _stylesheet.GetRules());
        }

        [TestMethod]
        [Description("can expand child selectors with static class names")]
        public void CanExpandChildSelectorsWithStaticClassNames()
        {
            var result = StyleEngine.MergeStyleSets(new StyleSetFake
            {
                Root = new Style[] {
                    "a",
                    new Style
                    {
                        Selectors =
                        {
                            ["&:hover $child"] = new Style{Background = "red"}
                        }
                    }
                },
                Child = new Style[]{
                    "d",
                    new Style
                    {
                        Background = "green"
                    }
                }
            });

            Assert.AreEqual(new StyleSetFake
            {
                Root = "a root-0",
                Child = "d child-1"
            }, result);
            Assert.AreEqual(".root-0:hover .child-1{background:red;}" + ".child-1{background:green;}", _stylesheet.GetRules());
        }
    }
}
