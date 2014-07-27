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
                return 1L;
            if (y == 1L)
                return x;

            if (x == 2 && y < sizeof(long) * 8)
                return 1L << (int)y;

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

        /*
        public static T Clamp<T>(T value, T min, T max)
            where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                return min;
            if (value.CompareTo(max) > 0)
                return max;
            return value;
        }
        */

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

        // The functions in this region are elevated from:
        // https://github.com/ThuCommix/Sharpex2D/blob/1cbb70d97f6e1a3c506145f163b1f5fd3901fc91/Sharpex2D/Framework/Math/MathHelper.cs

        /// <summary> π * 2 </summary>
        public const double TwoPI = Math.PI * 2;

        /// <summary> π / 2 </summary>
        public const double PIOverTwo = Math.PI / 2;

        #region Missing Tests #0

        /// <summary>Returns the Cartesian coordinate for one axis of a point that is defined by a given triangle and two normalized barycentric (areal) coordinates.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="value3">The value3.</param>
        /// <param name="amount1">The amount1.</param>
        /// <param name="amount2">The amount2.</param>
        public static float Barycentric(float value1, float value2, float value3, float amount1, float amount2)
        {
            return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
        }

        /// <summary>Returns the Cartesian coordinate for one axis of a point that is defined by a given triangle and two normalized barycentric (areal) coordinates.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="value3">The value3.</param>
        /// <param name="amount1">The amount1.</param>
        /// <param name="amount2">The amount2.</param>
        public static double Barycentric(double value1, double value2, double value3, double amount1, double amount2)
        {
            return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
        }

        /// <summary>Performs a Catmull-Rom interpolation using the specified positions.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="value3">The value3.</param>
        /// <param name="value4">The value4.</param>
        /// <param name="amount">The amount.</param>
        public static float CatmullRom(float value1, float value2, float value3, float value4, float amount)
        {
            // Using formula from http://www.mvps.org/directx/articles/catmull/

            double amountSquared = amount * amount;
            double amountCubed = amountSquared * amount;

            return (float)(0.5 * (2.0 * value2 + (value3 - value1) * amount +
                (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
                (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
        }

        /// <summary>Performs a Catmull-Rom interpolation using the specified positions.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="value3">The value3.</param>
        /// <param name="value4">The value4.</param>
        /// <param name="amount">The amount.</param>
        public static double CatmullRom(double value1, double value2, double value3, double value4, double amount)
        {
            // Using formula from http://www.mvps.org/directx/articles/catmull/

            double amountSquared = amount * amount;
            double amountCubed = amountSquared * amount;

            return (double)(0.5 * (2.0 * value2 + (value3 - value1) * amount +
                (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
                (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
        }

        /// <summary>Performs a Hermite spline interpolation.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="tangent1">The tangent1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="tangent2">The tangent2.</param>
        /// <param name="amount">The amount.</param>
        public static float Hermite(float value1, float tangent1, float value2, float tangent2, float amount)
        {
            float a2 = amount * amount;
            float asqr3 = amount * a2;
            float a3 = a2 + a2 + a2;

            return (value1 * (((asqr3 + asqr3) - a3) + 1f)) +
                   (value2 * ((-2f * asqr3) + a3)) +
                   (tangent1 * ((asqr3 - (a2 + a2)) + amount)) +
                   (tangent2 * (asqr3 - a2));
        }

        /// <summary>Performs a Hermite spline interpolation.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="tangent1">The tangent1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="tangent2">The tangent2.</param>
        /// <param name="amount">The amount.</param>
        public static double Hermite(double value1, double tangent1, double value2, double tangent2, double amount)
        {
            double a2 = amount * amount;
            double asqr3 = amount * a2;
            double a3 = a2 + a2 + a2;

            return (value1 * (((asqr3 + asqr3) - a3) + 1.0)) +
                   (value2 * ((-2.0 * asqr3) + a3)) +
                   (tangent1 * ((asqr3 - (a2 + a2)) + amount)) +
                   (tangent2 * (asqr3 - a2));
        }

        /// <summary>Calculates the greatest common divisor of a set of integer values.</summary>
        /// <param name="values">The set of values.</param>
        /// <returns>Returns the greatest common divisor of the integer value set.</returns>
        public static int GCD(params int[] values)
        {
            if (values.Length <= 1)
                throw new ArgumentException("There mus be at least two values for a GCD calculation.");

            if (values.Length == 2)
                return GCD(values[0], values[1]);

            int gcd = 0;
            int a = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                gcd = GCD(a, values[i]);
                a = values[i];
            }
            return gcd;
        }

        /// <summary>Calculates the greatest common divisor of a set of integer values.</summary>
        /// <param name="values">The set of values.</param>
        /// <returns>Returns the greatest common divisor of the integer value set.</returns>
        public static long GCD(params long[] values)
        {
            if (values.Length <= 1)
                throw new ArgumentException("There mus be at least two values for a GCD calculation.");

            if (values.Length == 2)
                return GCD(values[0], values[1]);

            long gcd = 0;
            long a = values[0];
            for (long i = 1; i < values.Length; i++)
            {
                gcd = GCD(a, values[i]);
                a = values[i];
            }
            return gcd;
        }

        #endregion

        #region Lerp

        /// <summary>Linearly interpolates between two values.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="amount">The amount.</param>
        /// <remarks>
        /// No Unit Tests necessary. See MSDN for XNA's Lerp: http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.mathhelper.lerp.aspx
        /// Formula:
        /// value1 + (value2 - value1) * amount
        /// </remarks>
        public static float Lerp(float value1, float value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        /// <summary>Linearly interpolates between two values.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="amount">The amount.</param>
        /// <remarks>
        /// No Unit Tests necessary. See MSDN for XNA's Lerp: http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.mathhelper.lerp.aspx
        /// Formula:
        /// value1 + (value2 - value1) * amount
        /// </remarks>
        public static double Lerp(double value1, double value2, double amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        #endregion

        #region GCD

        /// <summary>Calculates the greatest common divisor of two values.</summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>Returns the greatest common divisor of the two values.</returns>
        public static int GCD(int a, int b)
        {
#if FEATURE_GCD_RECURSIVE
            return b == 0 ? a : GreatestCommonDivisor(b, a % b);
#else
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
#endif
        }

        /// <summary>Calculates the greatest common divisor of two values.</summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>Returns the greatest common divisor of the two values.</returns>
        public static long GCD(long a, long b)
        {
#if FEATURE_GCD_RECURSIVE
            return b == 0 ? a : GreatestCommonDivisor(b, a % b);
#else
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
#endif
        }

        #endregion
        #region LCM

        /// <summary>Calculates the least common multiple of two values.</summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>Returns the least common multiple of the two values.</returns>
        public static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        /// <summary>Calculates the least common multiple of two values.</summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>Returns the least common multiple of the two values.</returns>
        public static long LCM(long a, long b)
        {
            return (a / GCD(a, b)) * b;
        }

        #endregion

        #region Angles

        #region WrapAngle

        /// <summary>Reduces a given angle to a value between π and -π.</summary>
        /// <param name="angle">The angle (radian).</param>
        public static float WrapAngle(float angle)
        {
            angle = (float)Math.IEEERemainder(angle, TwoPI);
            if (angle <= -Math.PI)
                angle += (float)TwoPI;
            else if (angle > Math.PI)
                angle -= (float)TwoPI;
            return angle;
        }

        /// <summary>Reduces a given angle to a value between π and -π.</summary>
        /// <param name="angle">The angle (radian).</param>
        public static double WrapAngle(double angle)
        {
            angle = Math.IEEERemainder(angle, TwoPI);
            if (angle <= -Math.PI)
                angle += TwoPI;
            else if (angle > Math.PI)
                angle -= TwoPI;
            return angle;
        }

        #endregion
        #region ToDegrees

        /// <summary>Converts radians to degrees.</summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static double ToDegrees(double radians)
        {
            return radians * (180 / Math.PI);
        }

        /// <summary>Converts radians to degrees.</summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static float ToDegrees(float radians)
        {
            return radians * (180 / (float)Math.PI);
        }

        #endregion
        #region ToRadians

        /// <summary>Converts degrees to radians.</summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        /// <summary>Converts degrees to radians.</summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static float ToRadians(float degrees)
        {
            return degrees * ((float)Math.PI / 180);
        }

        #endregion

        #endregion
    }
}
