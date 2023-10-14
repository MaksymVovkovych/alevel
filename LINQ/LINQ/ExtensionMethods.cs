using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class Methods 
    {
        public static T? FirstOrDefault2<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default;
        }


        public static IEnumerable<T> SkipWhile2<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            if (collection != null && predicate != null)
            {
                using (var enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        var item = enumerator.Current;
                        if (!predicate(item))
                        {
                            yield return item;
                            while (enumerator.MoveNext())
                            {
                                yield return enumerator.Current;
                            }
                            yield break;
                        }
                    }
                }
            }
            else 
            {
                throw new ArgumentNullException();
            }
        }
    }
}
