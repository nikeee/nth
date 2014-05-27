using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTH.Text
{
    internal static class LevenshteinCalculator
    {
        internal static int CalculateMatrix(string a, string b)
        {
            if (a.IsNullOrEmpty())
                return b.IsNullOrEmpty() ? 0 : b.Length;
            else if (b.IsNullOrEmpty())
                return a.Length;

            int n = a.Length;
            int m = b.Length;

            var d = new int[n + 1, m + 1];

            var dUpperBound0 = d.GetUpperBound(0) + 1;
            var dUpperBound1 = d.GetUpperBound(1) + 1;

            for (int i = 0; i < dUpperBound0; ++i)
                d[i, 0] = i;

            for (int i = 0; i < dUpperBound1; ++i)
                d[0, i] = i;

            for (int i = 1; i < dUpperBound0; ++i)
            {
                for (int j = 1; j < dUpperBound1; ++j)
                {
                    int cost = a[i - 1] != b[j - 1] ? 1 : 0;
                    d[i, j] = MathEx.Min(
                                            d[i - 1, j] + 1,
                                            d[i, j - 1] + 1,
                                            d[i - 1, j - 1] + cost
                                        );
                }
            }

            return d[dUpperBound0 - 1, dUpperBound1 - 1];
        }
        internal static int CalculateVector(string a, string b)
        {
            if (a.IsNullOrEmpty())
                return b.IsNullOrEmpty() ? 0 : b.Length;
            else if (b.IsNullOrEmpty())
                return a.Length;

            if (a.Length > b.Length)
            {
                var tmp = b;
                b = a;
                a = tmp;
            }

            int n = a.Length;
            int m = b.Length;
            var d = new int[2, m + 1];

            for (int i = 1; i <= m; ++i)
                d[0, i] = i;

            int currentRow = 0;
            for (int i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                d[currentRow, 0] = i;
                int previousRow = currentRow ^ 1;
                for (int j = 1; j <= m; ++j)
                {
                    int cost = b[j - 1] != a[i - 1] ? 1 : 0;
                    d[currentRow, j] = MathEx.Min(
                                                    d[previousRow, j] + 1,
                                                    d[currentRow, j - 1] + 1,
                                                    d[previousRow, j - 1] + cost
                                                );
                }
            }
            return d[currentRow, m];
        }
    }
}
