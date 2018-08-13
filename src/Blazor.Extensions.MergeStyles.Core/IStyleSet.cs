using System;
using System.Collections.Generic;

namespace Blazor.Extensions.MergeStyles
{
    public interface IStyleSet<T>
        where T : IStyleSet<T>
    {
        Dictionary<string, object> SubComponentStyles { get; set; }

        void AddStyle(string key, Style styleSet);

     
    }
}