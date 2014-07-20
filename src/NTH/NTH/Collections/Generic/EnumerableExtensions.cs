using System;
using System.Collections.Generic;
using System.Linq;

namespace NTH.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> GetPageItems<T>(this IEnumerable<T> items, int page, int itemsPerPage)
        {
            if (items == null)
                throw new ArgumentNullException("items");
            if (page < 0)
                throw new ArgumentException("Argument page must be greater than or equal to zero.");
            if (itemsPerPage < 0)
                throw new ArgumentException("Argument itemsPerPage must be greater than or equal to zero.");
            return items.Skip(page * itemsPerPage).Take(itemsPerPage);
        }

        /// <summary>Performs the specified action on each element of the IEnumerable.</summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="source">The items to interate through.</param>
        /// <param name="action">The Action delegate to perform on each element of the IEnumerable.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            foreach (var item in source)
                action(item);
        }
    }
}
