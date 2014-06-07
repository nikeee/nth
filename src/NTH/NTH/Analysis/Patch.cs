using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

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

#if false
        
        const int MaxMatchBits = 10;
        const int PatchMargin = 47;

        private void AddContext(Patch<T> p, T content)
        {

            var sc = content.ToString();
            if(sc.Length == 0)
                return;
            var pattern = sc.Substring(p.Start1, p.Length0);
            int padding = 0;

            int begin, end;

            while (sc.IndexOf(pattern, StringComparison.Ordinal) != sc.LastIndexOf(pattern, StringComparison.Ordinal)
                   && pattern.Length < MaxMatchBits - PatchMargin*2)
            {
                padding += PatchMargin;

                // May optimize here
                begin = Math.Max(0, p.Start1 - padding);
                end = Math.Min(sc.Length, p.Start1 + p.Length0 + padding);
                pattern = sc.Substring(begin, end - begin);
            }
            padding += PatchMargin;

            begin = Math.Max(0, p.Start1 - padding);
            end = p.Start1;

            var prefix = sc.Substring(begin, end - begin);

            if (prefix.Length != 0)
            {
                p.Diffs.Insert(0,new Diff<T>());
            }
        }

        public static IList<Patch<T>> Create(IList<T> source, IList<Diff<T>> diffs)
        {
            if (diffs == null)
                throw new ArgumentNullException("diffs");
            if (diffs.Count == 0)
                return new List<Patch<T>>();


            var p = new Patch<T>();
            var patches = new List<Patch<T>>();

            int charCount0 = 0;
            int charCount1 = 0;

            var prePatchText = source;
            var postPatchText = new List<T>(source);

            foreach (var d in diffs)
            {
                if (p.Diffs.Count == 0 && d.Type != DiffType.Equal)
                {
                    p.Start0 = charCount0;
                    p.Start1 = charCount1;
                }

                var len = d.Content.ToString().Length + 1;

                switch (d.Type)
                {
                    case DiffType.Equal:

                        if (d.Content.ToString().Length >= 2 * PatchMargin
                            && p.Diffs.Count != 0
                            && d != diffs[diffs.Count - 1])
                        {
                            p.Diffs.Add(d);
                            p.Length0 += len;
                            p.Length1 += len;
                        }
                        if (len >= 2 * PatchMargin)
                        {
                            if (p.Diffs.Count != 0)
                            {
                                // TODO: p_addContext
                                patches.Add(p);
                                p = new Patch<T>();
                                prePatchText = postPatchText;
                                charCount0 = charCount1;
                            }
                        }
                        break;
                    case DiffType.Insert:
                        p.Diffs.Add(d);
                        p.Length1 += d.Content.ToString().Length;
                        postPatchText.Insert(charCount1, d.Content);
                        // postPatchText = postPatchText.Insert(charCount1, d.Content);
                        break;
                    case DiffType.Delete:
                        p.Length0 += d.Content.ToString().Length;
                        p.Diffs.Add(d);
                        postPatchText.RemoveRange(charCount1, d.Content.ToString().Length);
                        // postPatchText = postPatchText.Remove(charCount1, d.Content.ToString().Length);
                        break;
                    default:
                        break;
                }

                if (d.Type != DiffType.Insert)
                    charCount0 += len;
                if (d.Type != DiffType.Delete)
                    charCount1 += len;

            }

            if (p.Diffs.Count != 0)
            {
                // TODO: p_addContext
                patches.Add(p);
            }

            return patches;
        }

        #endif

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
