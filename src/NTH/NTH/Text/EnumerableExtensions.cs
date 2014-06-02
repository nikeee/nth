using System.Collections.Generic;
using System.Linq;

namespace NTH.Text
{
    public static class EnumerableExtensions
    {
        public static IOrderedEnumerable<string> OrderByLevenshteinDistanceTo(this IEnumerable<string> strings, string target)
        {
            return strings.OrderByLevenshteinDistanceTo(target, LevenshteinMethod.Default);
        }
        
        public static IOrderedEnumerable<string> OrderByLevenshteinDistanceTo(this IEnumerable<string> strings, string target, LevenshteinMethod method)
        {
            return strings.OrderByLevenshteinDistanceTo(target, method, true);
        }

        public static IOrderedEnumerable<string> OrderByLevenshteinDistanceTo(this IEnumerable<string> strings, string target, LevenshteinMethod method, bool descending)
        {
            if(descending)
                return strings.OrderByDescending(s => s.LevenshteinDistanceTo(target, method));
            return strings.OrderBy(s => s.LevenshteinDistanceTo(target, method));
        } 
    }
}
