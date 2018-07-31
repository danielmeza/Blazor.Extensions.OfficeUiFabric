using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Extensions.MergeStyles.Tests
{
    [TestClass]
    public class CssValueTest
    {
        [TestMethod]
        public void CanCastToBool()
        {
            object bolean = true;
            CssValue value = (CssValue)bolean;
        }
        
    }
}
