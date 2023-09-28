using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class ExtensionMethods<T>
    {
        public static IEnumerable<T> FirstOrDefault2(this IEnumerable<T> collection, Func<T, bool> predicate) 
        {

            return collection;
        }
    }
}
