using System;

namespace NTH
{
    public static class MathEx
    {
        #region Pow

        public static int Pow(int x, int y)
        {
            if (y < 0)
                throw new ArgumentException("Invalid y");
            if (y == 0)
                return 1;
            if (y == 1)
                return x;

            // TODO: Add optimization using shifting
            // if (x == 1 && y < sizeof(int) * 8)
            //  return x << y;

            var res = 1;
            while (y != 0)
            {
                if ((y & 1) == 1)
                    res *= x;
                x *= x;
                y >>= 1;
            }
            return res;
        }
        public static long Pow(long x, long y)
        {
            if (y < 0)
                throw new ArgumentException("Invalid y");
            if (y == 0)
                return 1;
            if (y == 1)
                return x;

            // TODO: Add optimization using shifting
            // if (x == 1 && y < sizeof(int) * 8)
            //  return x << y;

            var res = 1L;
            while (y != 0)
            {
                if ((y & 1) == 1)
                    res = res * x;
                x *= x;
                y >>= 1;
            }
            return res;
        }

        #endregion

        #region Min, 3 params

        public static int Min(int a, int b, int c)
        {
            var ab = a > b ? b : a;
            return ab > c ? c : ab;
        }
        public static long Min(long a, long b, long c)
        {
            var ab = a > b ? b : a;
            return ab > c ? c : ab;
        }
        public static float Min(float a, float b, float c)
        {
            var ab = a > b ? b : a;
            return ab > c ? c : ab;
        }
        public static double Min(double a, double b, double c)
        {
            var ab = a > b ? b : a;
            return ab > c ? c : ab;
        }

        #endregion
        #region Max, 3 params

        public static int Max(int a, int b, int c)
        {
            var ab = a > b ? a : b;
            return ab > c ? ab : c;
        }
        public static long Max(long a, long b, long c)
        {
            var ab = a > b ? a : b;
            return ab > c ? ab : c;
        }
        public static float Max(float a, float b, float c)
        {
            var ab = a > b ? a : b;
            return ab > c ? ab : c;
        }
        public static double Max(double a, double b, double c)
        {
            var ab = a > b ? a : b;
            return ab > c ? ab : c;
        }

        #endregion

        #region Min, rest params

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
        public static long Min(params long[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            long minVal = values[values.Length - 1];
            for (int i = values.Length - 2; i >= 0; --i)
                if (values[i] < minVal)
                    minVal = values[i];
            return minVal;
        }
        public static float Min(params float[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            float minVal = values[values.Length - 1];
            for (int i = values.Length - 2; i >= 0; --i)
                if (values[i] < minVal)
                    minVal = values[i];
            return minVal;
        }
        public static double Min(params double[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            double minVal = values[values.Length - 1];
            for (int i = values.Length - 2; i >= 0; --i)
                if (values[i] < minVal)
                    minVal = values[i];
            return minVal;
        }

        #endregion
        #region Max, rest params

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
        public static long Max(params long[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            long maxVal = values[values.Length - 1];
            for (int i = values.Length - 2; i >= 0; --i)
                if (values[i] > maxVal)
                    maxVal = values[i];
            return maxVal;
        }
        public static float Max(params float[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            float maxVal = values[values.Length - 1];
            for (int i = values.Length - 2; i >= 0; --i)
                if (values[i] > maxVal)
                    maxVal = values[i];
            return maxVal;
        }
        public static double Max(params double[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            double maxVal = values[values.Length - 1];
            for (int i = values.Length - 2; i >= 0; --i)
                if (values[i] > maxVal)
                    maxVal = values[i];
            return maxVal;
        }

        #endregion
    }
}
