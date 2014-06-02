using System;

namespace NTH
{
    public static class MathEx
    {
        public static int Min(int a, int b, int c)
        {
            var ab = a > b ? b : a;
            return ab > c ? c : ab;
        }
        public static int Max(int a, int b, int c)
        {
            var ab = a > b ? a : b;
            return ab > c ? ab : c;
        }

        public static int Min(params int[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            int minVal = values[values.Length - 1];
            for (int i = values.Length - 2; i >= 0; --i)
                if (values[i] < minVal)
                    minVal = values[i];
            return minVal;
        }
        public static int Max(params int[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            int maxVal = values[values.Length - 1];
            for (int i = values.Length - 2; i >= 0; --i)
                if (values[i] > maxVal)
                    maxVal = values[i];
            return maxVal;
        }
    }
}
