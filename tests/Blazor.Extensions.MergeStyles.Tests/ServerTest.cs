using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles.Tests
{
    [TestClass]
    public class ServerTest : BaseTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Initialize();
        }

        [TestMethod]
        [Description("can render content")]
        public void CanRenderContent()
        {
            //TODO: implementMergeStyleSet first
        //    var (html, css) = StyleEngine.RenderStatic(() =>
        //    {
        //    var classNames = StyleEngine.M mergeStyleSets({
        //        root:
        //        {
        //            background: 'red'
        //                }
        //    });

        //    return $"<div class=\"{classNames.root}\">Hello!</div>";
        //});
        }

}
}
