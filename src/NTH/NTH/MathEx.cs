using System;

namespace NTH
{
    public static class MathEx
    {
        #region Pow

        /// <summary>Returns a specified number raised to the specified power.</summary>
        /// <returns>The number <paramref name="x" /> raised to the power <paramref name="y" />.</returns>
        /// <param name="x">An integer to be raised to a power.</param>
        /// <param name="y">An integer that specifies a power.</param>
        /// <filterpriority>1</filterpriority>
        public static int Pow(int x, int y)
        {
            if (y < 0)
                throw new ArgumentException("Invalid y");
            if (y == 0)
                return 1;
            if (y == 1)
                return x;

            if (x == 2 && y < sizeof(int) * 8)
                return 1 << y;

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

        /// <summary>Returns a specified number raised to the specified power.</summary>
        /// <returns>The number <paramref name="x" /> raised to the power <paramref name="y" />.</returns>
        /// <param name="x">A long integer to be raised to a power.</param>
        /// <param name="y">A long integer that specifies a power.</param>
        /// <filterpriority>1</filterpriority>
        public static long Pow(long x, long y)
        {
            if (y < 0)
                throw new ArgumentException("Invalid y");
            if (y == 0)
                return 1;
            if (y == 1)
                return x;

            if (x == 2 && y < sizeof(long) * 8)
                return 1 << (int)y;

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

        #region Clamp

        public static byte Clamp(byte value, byte min, byte max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public static short Clamp(short value, short min, short max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public static long Clamp(long value, long min, long max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public static decimal Clamp(decimal value, decimal min, decimal max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        #endregion


        #region Min, 3 params

        /// <summary>Returns the smaller of three 32-bit signed integers.</summary>
        /// <returns>Parameter <paramref name="a" />, <paramref name="b" /> or <paramref name="c" />, whichever is smaller.</returns>
        /// <param name="a">The first of three 32-bit signed integers to compare.</param>
        /// <param name="b">The second of three 32-bit signed integers to compare.</param>
        /// <param name="c">The second of three 32-bit signed integers to compare.</param>
        /// <filterpriority>1</filterpriority>
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

        /// <summary>Returns the larger of three 32-bit signed integers.</summary>
        /// <returns>Parameter <paramref name="a" />, <paramref name="b" /> or <paramref name="c" />, whichever is larger.</returns>
        /// <param name="a">The first of three 32-bit signed integers to compare.</param>
        /// <param name="b">The second of three 32-bit signed integers to compare.</param>
        /// <param name="c">The second of three 32-bit signed integers to compare.</param>
        /// <filterpriority>1</filterpriority>
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
