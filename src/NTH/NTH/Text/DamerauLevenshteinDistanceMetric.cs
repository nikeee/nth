using System;

namespace NTH.Text
{
    internal class DamerauLevenshteinDistanceMetric
    {
        private const int DefaultLength = 255;

        private int[] _currentRow;
        private int[] _previousRow;
        private int[] _transpositionRow;

        public DamerauLevenshteinDistanceMetric()
            : this(DefaultLength)
        { }
        public DamerauLevenshteinDistanceMetric(int maxLength)
        {
            _currentRow = new int[maxLength + 1];
            _previousRow = new int[maxLength + 1];
            _transpositionRow = new int[maxLength + 1];
        }

        public int GetDistance(string a, string b, int max)
        {
            if (string.IsNullOrEmpty(a))
                return string.IsNullOrEmpty(b) ? 0 : b.Length;
            if (string.IsNullOrEmpty(b))
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
