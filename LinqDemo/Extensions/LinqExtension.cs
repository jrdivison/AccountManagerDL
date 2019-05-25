using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    public static class LinqExtension
    {
        public static IEnumerable<T> GetTop<T>(this IEnumerable<T> items
            , int topRows)
        {
            return items.Take(topRows);
        }
    }
}
