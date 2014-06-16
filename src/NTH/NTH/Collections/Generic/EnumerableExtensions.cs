using System;
using System.Collections.Generic;
using System.Linq;

namespace NTH.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> GetPageItems<T>(this IEnumerable<T> items, int page, int itemsPerPage)
        {
            if(page < 0)
                throw new ArgumentException("Argument Page must be greater than or equal to zero.");
            if(itemsPerPage < 0)
                throw new ArgumentException("Argument itemsPerPage must be greater than or equal to zero.");
            return items.Skip(page * itemsPerPage).Take(itemsPerPage);
        }
    }
}
