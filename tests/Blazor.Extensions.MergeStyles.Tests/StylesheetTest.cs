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
        private Stylesheet _stylessheet;

        [TestInitialize]
        public async Task Initialize()
        {

            await base.Init();
            this._stylessheet = await Stylesheet.GetInstance();
            this._stylessheet.SetConfig(new StyleSheetConfig { InjectionMode = InjectionMode.None, DefaultPrefix = "myCss" });
        }

        [TestMethod]
        public void SupportOverridingThedefaultPrefix()
        {
            //Arrange
            //var className = styleToClassName({ background: 'red' });

            //expect(className).toEqual('myCss-0');
            //expect(_stylesheet.getRules()).toEqual('.myCss-0{background:red;}');
        }
    }
}
