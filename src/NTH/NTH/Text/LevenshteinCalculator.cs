using System;

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
                    int cost = a[i - 1] != b[j - 1] ? 1 : 0;
                    d[currentRow, j] = MathEx.Min(
                                                    d[previousRow, j] + 1,
                                                    d[currentRow, j - 1] + 1,
                                                    d[previousRow, j - 1] + cost
                                                );
                }
            }
            return d[currentRow, m];
        }

        internal static int CalculateRecursive(string a, string b)
        {
            if (a.IsNullOrEmpty())
                return b.IsNullOrEmpty() ? 0 : b.Length;
            else if (b.IsNullOrEmpty())
                return a.Length;
            return CalculateRecursive(a, b, a.Length, b.Length);
        }

        private static int CalculateRecursive(string a, string b, int aLength, int bLength)
        {
            if (aLength == 0)
                return bLength;
            if (bLength == 0)
                return aLength;

            int cost = a[aLength - 1] != b[bLength - 1] ? 1 : 0;

            return MathEx.Min(
                    CalculateRecursive(a, b, aLength - 1, bLength) + 1,
                    CalculateRecursive(a, b, aLength, bLength - 1) + 1,
                    CalculateRecursive(a, b, aLength - 1, bLength - 1) + cost
                );
        }
    }

    internal class DamerauLevensteinDistanceMetric
    {
        private const int DefaultLength = 255;

        private int[] _currentRow;
        private int[] _previousRow;
        private int[] _transpositionRow;

        public DamerauLevensteinDistanceMetric()
            : this(DefaultLength)
        { }
        public DamerauLevensteinDistanceMetric(int maxLength)
        {
            _currentRow = new int[maxLength + 1];
            _previousRow = new int[maxLength + 1];
            _transpositionRow = new int[maxLength + 1];
        }

        public int GetDistance(string a, string b, int max)
        {
            if (a.IsNullOrEmpty())
                return b.IsNullOrEmpty() ? 0 : b.Length;
            else if (b.IsNullOrEmpty())
                return a.Length;

            if (a.Length > b.Length)
            {
                string tmp = a;
                a = b;
                b = tmp;
            }

            int n = a.Length;
            int m = b.Length;

            if (max < 0)
                max = m;

            if (m - n > max)
                return max + 1;
            if (n > _currentRow.Length)
            {
                _currentRow = new int[n + 1];
                _previousRow = new int[n + 1];
                _transpositionRow = new int[n + 1];
            }

            for (int i = 0; i <= n; ++i)
                _previousRow[i] = i;

            char lastSecondChar = (char)0;
            for (int i = 1; i <= m; ++i)
            {
                char secondChar = b[i - 1];
                _currentRow[0] = i;

                int from = Math.Max(i - max - 1, 1);
                int to = Math.Min(i + max + 1, n);

                char lastFirstChar = (char)0;
                for (int j = from; j <= to; ++j)
                {
                    char firstChar = a[j - 1];
                    int cost = firstChar != secondChar ? 1 : 0;
                    int value = MathEx.Min(
                                    _currentRow[j - 1] + 1,
                                    _previousRow[j] + 1,
                                    _previousRow[j - 1] + cost
                                );
                    if (firstChar == lastSecondChar && secondChar == lastFirstChar)
                        value = Math.Min(value, _transpositionRow[j - 2] + cost);

                    _currentRow[j] = value;
                    lastFirstChar = firstChar;
                }

                lastSecondChar = secondChar;

                int[] tempRow = _transpositionRow;
                _transpositionRow = _previousRow;
                _previousRow = _currentRow;
                _currentRow = tempRow;
            }

            return _previousRow[n];
        }
    }
}
