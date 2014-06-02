using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NTH.Analysis
{
    public class DiffFinder<T> where T : IComparable<T>
    {
        public List<Diff<T>> ComputeDiff(T[] before, T[] after)
        {
            var diffs = new List<Diff<T>>();
            // Performance improvements
            if (before != null && before.Length != 0)
            {
                if (after != null && after.Length != 0)
                {
                    if (before.Length == after.Length)
                    {
                        bool areEqual = true;
                        for (int i = 0; i < before.Length; ++i)
                        {
                            if (before[i].CompareTo((after[i])) != 0)
                            {
                                areEqual = false;
                                break;
                            }
                        }
                        if (areEqual)
                        {
                            diffs.AddRange(Diff<T>.Create(DiffType.Equal, before));
                            return diffs; // before != null, after != null
                        }
                    }
                }
                else
                {
                    diffs.AddRange(Diff<T>.Create(DiffType.Delete, before));
                    return diffs; // before != null, after == null
                }
            }
            else
            {
                if (after != null && after.Length != 0)
                {
                    diffs.AddRange(Diff<T>.Create(DiffType.Insert, after));
                    return diffs; // before == null, after != null
                }
                diffs.AddRange(Diff<T>.Create(DiffType.Equal, new T[0]));
                return diffs; // before and after are null
            }

            T[] commonPrefix = null;
            int commonPrefixLength = GetCommonPrefixLength(before, after);
            if (commonPrefixLength > 0)
            {
                commonPrefix = ArrayExtensions<T>.Substring(before, 0, commonPrefixLength);
                before = ArrayExtensions<T>.Substring(before, commonPrefixLength);
                after = ArrayExtensions<T>.Substring(after, commonPrefixLength);
            }

            T[] commonPostfix = null;
            int commonPostfixLength = GetCommonPostfixLength(before, after);
            if (commonPostfixLength > 0)
            {
                commonPostfix = ArrayExtensions<T>.Substring(before, before.Length - commonPostfixLength);
                before = ArrayExtensions<T>.Substring(before, 0, before.Length - commonPostfixLength);
                after = ArrayExtensions<T>.Substring(after, 0, after.Length - commonPostfixLength);
            }

            // TODO: actual diffing
            if (commonPrefix != null)
                diffs.AddRange(Diff<T>.Create(DiffType.Equal, commonPrefix));

            var actualDiffs = ComputeDiffInternal(before, after);
            diffs.AddRange(actualDiffs);

            if (commonPostfix != null)
                diffs.AddRange(Diff<T>.Create(DiffType.Equal, commonPostfix));

            return diffs;
        }

        private IList<Diff<T>> ComputeDiffInternal(T[] before, T[] after)
        {
            Debug.Assert(before != null);
            Debug.Assert(after != null);

            // Might never happen, so commented out:
            if (before.Length == 0)
                return new List<Diff<T>>(Diff<T>.Create(DiffType.Insert, after));
            if (after.Length == 0)
                return new List<Diff<T>>(Diff<T>.Create(DiffType.Delete, before));

            T[] longerText = before.Length > after.Length ? before : after;
            T[] shorterText = before.Length < after.Length ? before : after;

            // Optimization
            int index = ArrayExtensions<T>.IndexOf(longerText, shorterText);
            if (index != -1)
            {
                // short text is part of long text, so use optimization here

                // If before is the longer one, then text has been removed
                DiffType t = before.Length > after.Length ? DiffType.Delete : DiffType.Insert;

                var diffs = new List<Diff<T>>();
                diffs.AddRange(Diff<T>.Create(t, ArrayExtensions<T>.Substring(longerText, 0, index)));
                diffs.AddRange(Diff<T>.Create(DiffType.Equal, shorterText));
                diffs.AddRange(Diff<T>.Create(t, ArrayExtensions<T>.Substring(longerText, index + shorterText.Length)));
                return diffs;
            }

            // Optimization
            if (shorterText.Length == 1)
            {
                // This is only true if before or after is only one char
                // this char is not present in the opposite text,
                // so the diff consists of the removal of before and insertion of after
                var diffs = new List<Diff<T>>();
                diffs.AddRange(Diff<T>.Create(DiffType.Delete, before));
                diffs.AddRange(Diff<T>.Create(DiffType.Insert, after));
                return diffs;
            }

            //TODO : HalfMatch

            return Bisect(before, after);
        }

        protected IList<Diff<T>> Bisect(T[] before, T[] after)
        {
            Debug.Assert(before != null);
            Debug.Assert(after != null);

            // Cache the text lengths to prevent multiple calls.
            int beforeLength = before.Length;
            int afterLength = after.Length;
            int maxD = (beforeLength + afterLength + 1) / 2;
            int vOffset = maxD;
            int vLength = 2 * maxD;
            var v1 = new int[vLength];
            var v2 = new int[vLength];
            for (int x = 0; x < vLength; x++)
            {
                v1[x] = -1;
                v2[x] = -1;
            }
            v1[vOffset + 1] = 0;
            v2[vOffset + 1] = 0;
            int delta = beforeLength - afterLength;
            // If the total number of characters is odd, then the front path will
            // collide with the reverse path.
            bool front = (delta % 2 != 0);
            // Offsets for start and end of k loop.
            // Prevents mapping of space beyond the grid.
            int k1start = 0;
            int k1end = 0;
            int k2start = 0;
            int k2end = 0;
            for (int d = 0; d < maxD; d++)
            {
                // Walk the front path one step.
                for (int k1 = -d + k1start; k1 <= d - k1end; k1 += 2)
                {
                    int k1Offset = vOffset + k1;
                    int x1;
                    if (k1 == -d || k1 != d && v1[k1Offset - 1] < v1[k1Offset + 1])
                    {
                        x1 = v1[k1Offset + 1];
                    }
                    else
                    {
                        x1 = v1[k1Offset - 1] + 1;
                    }
                    int y1 = x1 - k1;
                    while (x1 < beforeLength && y1 < afterLength
                        && before[x1].CompareTo(after[y1]) == 0)
                    {
                        x1++;
                        y1++;
                    }
                    v1[k1Offset] = x1;
                    if (x1 > beforeLength)
                    {
                        // Ran off the right of the graph.
                        k1end += 2;
                    }
                    else if (y1 > afterLength)
                    {
                        // Ran off the bottom of the graph.
                        k1start += 2;
                    }
                    else if (front)
                    {
                        int k2Offset = vOffset + delta - k1;
                        if (k2Offset >= 0 && k2Offset < vLength && v2[k2Offset] != -1)
                        {
                            // Mirror x2 onto top-left coordinate system.
                            int x2 = beforeLength - v2[k2Offset];
                            if (x1 >= x2)
                            {
                                // Overlap detected.
                                return BisectSplit(before, after, x1, y1);
                            }
                        }
                    }
                }

                // Walk the reverse path one step.
                for (int k2 = -d + k2start; k2 <= d - k2end; k2 += 2)
                {
                    int k2Offset = vOffset + k2;
                    int x2;
                    if (k2 == -d || k2 != d && v2[k2Offset - 1] < v2[k2Offset + 1])
                    {
                        x2 = v2[k2Offset + 1];
                    }
                    else
                    {
                        x2 = v2[k2Offset - 1] + 1;
                    }
                    int y2 = x2 - k2;
                    while (x2 < beforeLength && y2 < afterLength
                        && before[beforeLength - x2 - 1].CompareTo(after[afterLength - y2 - 1]) == 0)
                    {
                        x2++;
                        y2++;
                    }
                    v2[k2Offset] = x2;
                    if (x2 > beforeLength)
                    {
                        // Ran off the left of the graph.
                        k2end += 2;
                    }
                    else if (y2 > afterLength)
                    {
                        // Ran off the top of the graph.
                        k2start += 2;
                    }
                    else if (!front)
                    {
                        int k1Offset = vOffset + delta - k2;
                        if (k1Offset >= 0 && k1Offset < vLength && v1[k1Offset] != -1)
                        {
                            int x1 = v1[k1Offset];
                            int y1 = vOffset + x1 - k1Offset;
                            // Mirror x2 onto top-left coordinate system.
                            x2 = beforeLength - v2[k2Offset];
                            if (x1 >= x2)
                            {
                                // Overlap detected.
                                return BisectSplit(before, after, x1, y1);
                            }
                        }
                    }
                }
            }
            // Diff took too long and hit the deadline or
            // number of diffs equals number of characters, no commonality at all.
            var diffs = new List<Diff<T>>();
            diffs.AddRange(Diff<T>.Create(DiffType.Delete, before));
            diffs.AddRange(Diff<T>.Create(DiffType.Insert, after));
            return diffs;
        }
        private List<Diff<T>> BisectSplit(T[] before, T[] after, int x, int y)
        {
            T[] beforeA = ArrayExtensions<T>.Substring(before, 0, x);
            T[] afterA = ArrayExtensions<T>.Substring(after, 0, y);
            T[] beforeB = ArrayExtensions<T>.Substring(before, x);
            T[] afterB = ArrayExtensions<T>.Substring(after, y);

            // Compute both diffs serially.
            List<Diff<T>> diffs = ComputeDiff(beforeA, afterA);
            List<Diff<T>> diffsb = ComputeDiff(beforeB, afterB);

            diffs.AddRange(diffsb);
            return diffs;
        }


        private static List<Diff<T>> HalfMatch(T[] before, T[] after)
        {
            Debug.Assert(before != null);
            Debug.Assert(after != null);
            // TODO
            throw new NotImplementedException();
        }

        private static int GetCommonPrefixLength(T[] before, T[] after)
        {
            Debug.Assert(before != null);
            Debug.Assert(after != null);

            int n = Math.Min(before.Length, after.Length);
            for (int i = 0; i < n; ++i)
                if (before[i].CompareTo(after[i]) != 0)
                    return i;
            return n;
        }
        private static int GetCommonPostfixLength(T[] before, T[] after)
        {
            Debug.Assert(before != null);
            Debug.Assert(after != null);

            int beforeLength = before.Length;
            int afterLength = after.Length;
            int n = Math.Min(beforeLength, afterLength);

            for (int i = 1; i <= n; ++i)
                if (before[beforeLength - i].CompareTo(after[afterLength - i]) != 0)
                    return i - 1;
            return n;
        }
    }
}
