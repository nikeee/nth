using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Text;

namespace NTH.Analysis
{
    public class Patch<T> where T : IComparable<T>
    {
        public IList<Diff<T>> Diffs { get; private set; }
        public int Start0 { get; private set; }
        public int Start1 { get; private set; }
        public int Length0 { get; private set; }
        public int Length1 { get; private set; }

        internal static IList<T> GetSourceContent(IList<Diff<T>> diffs)
        {
            // Non-LINQ:
            /*
            var l = new List<T>();
            for (int i = 0; i < diffs.Count; ++i)
                if (diffs[i].Type != DiffType.Insert)
                    l.Add(diffs[i].Content);
            return l;
            */

            return diffs.Where(d => d.Type != DiffType.Insert).Select(d => d.Content).ToList();
        }
        internal static IList<T> GetTargetContent(IList<Diff<T>> diffs)
        {
            // Non-LINQ:
            /*
            var l = new List<T>();
            for (int i = 0; i < diffs.Count; ++i)
                if (diffs[i].Type != DiffType.Delete)
                    l.Add(diffs[i].Content);
            return l;
            */

            return diffs.Where(d => d.Type != DiffType.Delete).Select(d => d.Content).ToList();
        }



        private static char GetDiffTypeChar(DiffType type)
        {
            switch (type)
            {
                case DiffType.Equal:
                    return ' ';
                case DiffType.Insert:
                    return '+';
                case DiffType.Delete:
                    return '-';
                default:
                    throw new ArgumentException("Invalid DiffType: " + (int)type);
            }
        }

        private static string EncodeContent(T contentItem)
        {
            var c = HttpUtility.UrlEncode(contentItem.ToString(), Encoding.UTF8);
            return FixEncoding(c);
        }

        private static string FixEncoding(string encodedString)
        {
            return encodedString.Replace('+', ' ');
        }

        private static string GetFormattedCoord(int start, int length)
        {
            if (length == 0)
                return start + ",0";
            if (length == 1)
                return (start + 1).ToString();
            return string.Concat(start + 1, ',', length);
        }


        /// <summary>Emmulates GNU diff format. Indicies are printed as 1-based, not 0-based.</summary>
        /// <remarks>Header: @@ -382,8 +481,9 @@</remarks>
        /// <returns>The GNU diff string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            var coord0 = GetFormattedCoord(Start0, Length0);
            var coord1 = GetFormattedCoord(Start1, Length1);

            sb.AppendFormat("@@ -{0} +{1} @@", coord0, coord1);

            foreach (var d in Diffs)
            {
                sb.Append(GetDiffTypeChar(d.Type));
                sb.Append(EncodeContent(d.Content));
                sb.Append('\n');
            }
            return sb.ToString();
        }

    }
}
