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
    public class BaseTest
    {
        public Task Init()
        {
            //Initialize a fake IJSRuntime with the necesary functions to work
            var jsRuntimeMock = new Mock<IJSRuntime>();
            jsRuntimeMock.Setup((rt) => rt.InvokeAsync<object>("Init", null)).Returns(Task.FromResult<object>(null));
            
            JSRuntime.SetCurrentJSRuntime(jsRuntimeMock.Object);
            return Task.CompletedTask;
        }
    }
}
