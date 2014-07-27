using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NTH.Tests
{
    [TestClass]
    public class MathExTests
    {
        #region Pow

        [TestMethod]
        public void Pow()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Pow(10, 1);
            Assert.AreEqual(10, res);

            res = MathEx.Pow(10, 0);
            Assert.AreEqual(1, res);

            res = MathEx.Pow(10, 2);
            Assert.AreEqual(10 * 10, res);

            res = MathEx.Pow(10, 3);
            Assert.AreEqual(10 * 10 * 10, res);

            res = MathEx.Pow(10, 4);
            Assert.AreEqual(10 * 10 * 10 * 10, res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Pow2()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Pow((long)10, (long)1);
            Assert.AreEqual((long)10, res);

            res = MathEx.Pow((long)10, (long)0);
            Assert.AreEqual((long)1, res);

            res = MathEx.Pow((long)10, (long)2);
            Assert.AreEqual((long)10 * (long)10, res);

            res = MathEx.Pow((long)10, (long)3);
            Assert.AreEqual((long)10 * (long)10 * (long)10, res);

            res = MathEx.Pow((long)10, (long)4);
            Assert.AreEqual((long)10 * (long)10 * (long)10 * (long)10, res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void PowOptimization()
        {
            // Test bit shifting optimization

            var actual = MathEx.Pow(2, 1);
            var expected = (int)Math.Pow(2, 1);
            Assert.AreEqual(expected, actual);

            for (int i = 0; i < 31; ++i)
            {
                actual = MathEx.Pow(2, i);
                expected = (int)Math.Pow(2, i);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PowOptimization2()
        {
            // Test bit shifting optimization

            var actual = MathEx.Pow((long)2, (long)1);
            var expected = (long)Math.Pow((long)2, (long)1);
            Assert.AreEqual(expected, actual);

            for (long i = 0; i < 63; ++i)
            {
                actual = MathEx.Pow((long)2, i);
                expected = (long)Math.Pow((long)2, i);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PowExceptions()
        {
            // ReSharper disable RedundantCast
            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow(1, -1));
            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow(1, -2));

            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow(234, -1));
            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow(564, -2));

            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow(234, -24));
            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow(564, -256));
            // ReSharper restore RedundantCast
        }


        [TestMethod]
        public void PowExceptions2()
        {
            // ReSharper disable RedundantCast
            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow((long)1, (long)-1));
            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow((long)1, (long)-2));

            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow((long)234, (long)-1));
            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow((long)564, (long)-2));

            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow((long)234, (long)-24));
            TestHelper.AssertException<ArgumentException>(() => MathEx.Pow((long)564, (long)-256));
            // ReSharper restore RedundantCast
        }

        #endregion

        #region Min

        [TestMethod]
        public void Min()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Min(-1, 0, 1);
            Assert.AreEqual(-1, res);

            res = MathEx.Min(1, 0, -1);
            Assert.AreEqual(-1, res);

            res = MathEx.Min(1, -1, 0);
            Assert.AreEqual(-1, res);

            res = MathEx.Min(1, -1, 0, -2);
            Assert.AreEqual(-2, res);

            res = MathEx.Min(-3, -1, 0, 4, 13, 39, 42, 23, -4);
            Assert.AreEqual(-4, res);

            res = MathEx.Min(-300, -1, 0, 4, 13, 39, 42, 23, -4);
            Assert.AreEqual(-300, res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Min2()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Min((long)-1, (long)0, (long)1);
            Assert.AreEqual((long)-1, (long)res);

            res = MathEx.Min((long)1, (long)0, (long)-1);
            Assert.AreEqual((long)-1, (long)res);

            res = MathEx.Min((long)1, (long)-1, (long)0);
            Assert.AreEqual((long)-1, (long)res);

            res = MathEx.Min((long)1, (long)-1, (long)0, (long)-2);
            Assert.AreEqual((long)-2, (long)res);

            res = MathEx.Min((long)-3, (long)-1, (long)0, (long)4, (long)13, (long)39, (long)42, (long)23, (long)-4);
            Assert.AreEqual((long)-4, (long)res);

            res = MathEx.Min((long)-300, (long)-1, (long)0, (long)4, (long)13, (long)39, (long)42, (long)23, (long)-4);
            Assert.AreEqual((long)-300, (long)res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Min3()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Min((float)-1, (float)0, (float)1);
            Assert.AreEqual((float)-1, (float)res);

            res = MathEx.Min((float)1, (float)0, (float)-1);
            Assert.AreEqual((float)-1, (float)res);

            res = MathEx.Min((float)1, (float)-1, (float)0);
            Assert.AreEqual((float)-1, (float)res);

            res = MathEx.Min((float)1, (float)-1, (float)0, (float)-2);
            Assert.AreEqual((float)-2, (float)res);

            res = MathEx.Min((float)-3, (float)-1, (float)0, (float)4, (float)13, (float)39, (float)42, (float)23, (float)-4);
            Assert.AreEqual((float)-4, (float)res);

            res = MathEx.Min((float)-300, (float)-1, (float)0, (float)4, (float)13, (float)39, (float)42, (float)23, (float)-4);
            Assert.AreEqual((float)-300, (float)res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Min4()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Min((double)-1, (double)0, (double)1);
            Assert.AreEqual((double)-1, (double)res);

            res = MathEx.Min((double)1, (double)0, (double)-1);
            Assert.AreEqual((double)-1, (double)res);

            res = MathEx.Min((double)1, (double)-1, (double)0);
            Assert.AreEqual((double)-1, (double)res);

            res = MathEx.Min((double)1, (double)-1, (double)0, (double)-2);
            Assert.AreEqual((double)-2, (double)res);

            res = MathEx.Min((double)-3, (double)-1, (double)0, (double)4, (double)13, (double)39, (double)42, (double)23, (double)-4);
            Assert.AreEqual((double)-4, (double)res);

            res = MathEx.Min((double)-300, (double)-1, (double)0, (double)4, (double)13, (double)39, (double)42, (double)23, (double)-4);
            Assert.AreEqual((double)-300, (double)res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void MinExceptions()
        {
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Min((int[])null));
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Min(new int[0]));

            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Min((long[])null));
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Min(new long[0]));

            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Min((float[])null));
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Min(new float[0]));

            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Min((double[])null));
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Min(new double[0]));
        }

        #endregion

        #region Max

        [TestMethod]
        public void Max()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Max(-1, 0, 1);
            Assert.AreEqual(1, res);

            res = MathEx.Max(1, 0, -1);
            Assert.AreEqual(1, res);

            res = MathEx.Max(1, -1, 0);
            Assert.AreEqual(1, res);

            res = MathEx.Max(1, -1, 0, -2);
            Assert.AreEqual(1, res);

            res = MathEx.Max(-3, -1, 0, 4, 13, 39, 42, 23, -4);
            Assert.AreEqual(42, res);

            res = MathEx.Max(300, -1, 0, 4, 13, 39, 42, 23, -4);
            Assert.AreEqual(300, res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Max2()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Max((long)-1, (long)0, (long)1);
            Assert.AreEqual((long)1, (long)res);

            res = MathEx.Max((long)1, (long)0, (long)-1);
            Assert.AreEqual((long)1, (long)res);

            res = MathEx.Max((long)1, (long)-1, (long)0);
            Assert.AreEqual((long)1, (long)res);

            res = MathEx.Max((long)1, (long)-1, (long)0, (long)-2);
            Assert.AreEqual((long)1, (long)res);

            res = MathEx.Max((long)-3, (long)-1, (long)0, (long)4, (long)13, (long)39, (long)42, (long)23, (long)-4);
            Assert.AreEqual((long)42, (long)res);

            res = MathEx.Max((long)300, (long)-1, (long)0, (long)4, (long)13, (long)39, (long)42, (long)23, (long)-4);
            Assert.AreEqual((long)300, (long)res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Max3()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Max((float)-1, (float)0, (float)1);
            Assert.AreEqual((float)1, (float)res);

            res = MathEx.Max((float)1, (float)0, (float)-1);
            Assert.AreEqual((float)1, (float)res);

            res = MathEx.Max((float)1, (float)-1, (float)0);
            Assert.AreEqual((float)1, (float)res);

            res = MathEx.Max((float)1, (float)-1, (float)0, (float)-2);
            Assert.AreEqual((float)1, (float)res);

            res = MathEx.Max((float)-3, (float)-1, (float)0, (float)4, (float)13, (float)39, (float)42, (float)23, (float)-4);
            Assert.AreEqual((float)42, (float)res);

            res = MathEx.Max((float)300, (float)-1, (float)0, (float)4, (float)13, (float)39, (float)42, (float)23, (float)-4);
            Assert.AreEqual((float)300, (float)res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Max4()
        {
            // ReSharper disable RedundantCast
            var res = MathEx.Max((double)-1, (double)0, (double)1);
            Assert.AreEqual((double)1, (double)res);

            res = MathEx.Max((double)1, (double)0, (double)-1);
            Assert.AreEqual((double)1, (double)res);

            res = MathEx.Max((double)1, (double)-1, (double)0);
            Assert.AreEqual((double)1, (double)res);

            res = MathEx.Max((double)1, (double)-1, (double)0, (double)-2);
            Assert.AreEqual((double)1, (double)res);

            res = MathEx.Max((double)-3, (double)-1, (double)0, (double)4, (double)13, (double)39, (double)42, (double)23, (double)-4);
            Assert.AreEqual((double)42, (double)res);

            res = MathEx.Max((double)300, (double)-1, (double)0, (double)4, (double)13, (double)39, (double)42, (double)23, (double)-4);
            Assert.AreEqual((double)300, (double)res);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void MaxExceptions()
        {
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Max((int[])null));
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Max(new int[0]));

            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Max((long[])null));
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Max(new long[0]));

            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Max((float[])null));
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Max(new float[0]));

            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Max((double[])null));
            TestHelper.AssertException<ArgumentNullException>(() => MathEx.Max(new double[0]));
        }

        #endregion

        #region Clamp

        [TestMethod]
        public void Clamp()
        {
            // ReSharper disable RedundantCast
            var actual = MathEx.Clamp(1, 2, 3);
            var expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp(2, 1, 3);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp(3, 1, 2);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp(3, 1, 1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp(1, 1, 1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp(2, 4, 6);
            expected = 4;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp(6, 0, 4);
            expected = 4;
            Assert.AreEqual(expected, actual);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Clamp2()
        {
            // ReSharper disable RedundantCast
            var actual = MathEx.Clamp((long)1, (long)2, (long)3);
            var expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((long)2, (long)1, (long)3);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((long)3, (long)1, (long)2);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((long)3, (long)1, (long)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((long)1, (long)1, (long)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((long)2, (long)4, (long)6);
            expected = 4;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((long)6, (long)0, (long)4);
            expected = 4;
            Assert.AreEqual(expected, actual);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Clamp3()
        {
            // ReSharper disable RedundantCast
            var actual = MathEx.Clamp((double)1, (double)2, (double)3);
            var expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((double)2, (double)1, (double)3);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((double)3, (double)1, (double)2);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((double)3, (double)1, (double)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((double)1, (double)1, (double)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((double)2, (double)4, (double)6);
            expected = 4;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((double)6, (double)0, (double)4);
            expected = 4;
            Assert.AreEqual(expected, actual);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Clamp4()
        {
            // ReSharper disable RedundantCast
            var actual = MathEx.Clamp((decimal)1, (decimal)2, (decimal)3);
            var expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((decimal)2, (decimal)1, (decimal)3);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((decimal)3, (decimal)1, (decimal)2);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((decimal)3, (decimal)1, (decimal)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((decimal)1, (decimal)1, (decimal)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((decimal)2, (decimal)4, (decimal)6);
            expected = 4;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((decimal)6, (decimal)0, (decimal)4);
            expected = 4;
            Assert.AreEqual(expected, actual);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Clamp5()
        {
            // ReSharper disable RedundantCast
            var actual = MathEx.Clamp((float)1, (float)2, (float)3);
            var expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((float)2, (float)1, (float)3);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((float)3, (float)1, (float)2);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((float)3, (float)1, (float)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((float)1, (float)1, (float)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((float)2, (float)4, (float)6);
            expected = 4;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((float)6, (float)0, (float)4);
            expected = 4;
            Assert.AreEqual(expected, actual);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Clamp6()
        {
            // ReSharper disable RedundantCast
            var actual = MathEx.Clamp((byte)1, (byte)2, (byte)3);
            var expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((byte)2, (byte)1, (byte)3);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((byte)3, (byte)1, (byte)2);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((byte)3, (byte)1, (byte)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((byte)1, (byte)1, (byte)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((byte)2, (byte)4, (byte)6);
            expected = 4;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((byte)6, (byte)0, (byte)4);
            expected = 4;
            Assert.AreEqual(expected, actual);
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void Clamp7()
        {
            // ReSharper disable RedundantCast
            var actual = MathEx.Clamp((short)1, (short)2, (short)3);
            var expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((short)2, (short)1, (short)3);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((short)3, (short)1, (short)2);
            expected = 2;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((short)3, (short)1, (short)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((short)1, (short)1, (short)1);
            expected = 1;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((short)2, (short)4, (short)6);
            expected = 4;
            Assert.AreEqual(expected, actual);

            actual = MathEx.Clamp((short)6, (short)0, (short)4);
            expected = 4;
            Assert.AreEqual(expected, actual);
            // ReSharper restore RedundantCast
        }

        #endregion

        #region GCD

        [TestMethod]
        public void GCD()
        {
            // Generated, lol

            // ReSharper disable RedundantCast
            Assert.AreEqual(8, MathEx.GCD(24, 16));
            Assert.AreEqual(8, MathEx.GCD(16, 24));
            Assert.AreEqual(16, MathEx.GCD(16, 16));
            Assert.AreEqual(1, MathEx.GCD(13, 29));

            Assert.AreEqual(41, MathEx.GCD(0, 41));
            Assert.AreEqual(1, MathEx.GCD(1, 55));
            Assert.AreEqual(1, MathEx.GCD(2, 129));
            Assert.AreEqual(1, MathEx.GCD(3, 95));
            Assert.AreEqual(1, MathEx.GCD(4, 125));
            Assert.AreEqual(5, MathEx.GCD(5, 75));
            Assert.AreEqual(6, MathEx.GCD(6, 6));
            Assert.AreEqual(1, MathEx.GCD(7, 94));
            Assert.AreEqual(2, MathEx.GCD(8, 130));
            Assert.AreEqual(9, MathEx.GCD(9, 36));
            Assert.AreEqual(1, MathEx.GCD(10, 61));
            Assert.AreEqual(1, MathEx.GCD(11, 15));
            Assert.AreEqual(2, MathEx.GCD(12, 38));
            Assert.AreEqual(1, MathEx.GCD(13, 47));
            Assert.AreEqual(7, MathEx.GCD(14, 133));
            Assert.AreEqual(3, MathEx.GCD(15, 12));
            Assert.AreEqual(4, MathEx.GCD(16, 100));
            Assert.AreEqual(1, MathEx.GCD(17, 53));
            Assert.AreEqual(6, MathEx.GCD(18, 96));
            Assert.AreEqual(1, MathEx.GCD(19, 90));
            Assert.AreEqual(20, MathEx.GCD(20, 60));
            Assert.AreEqual(3, MathEx.GCD(21, 57));
            Assert.AreEqual(2, MathEx.GCD(22, 78));
            Assert.AreEqual(1, MathEx.GCD(23, 49));
            Assert.AreEqual(1, MathEx.GCD(24, 73));
            Assert.AreEqual(1, MathEx.GCD(25, 117));
            Assert.AreEqual(1, MathEx.GCD(26, 59));
            Assert.AreEqual(3, MathEx.GCD(27, 69));
            Assert.AreEqual(4, MathEx.GCD(28, 120));
            Assert.AreEqual(1, MathEx.GCD(29, 63));
            Assert.AreEqual(6, MathEx.GCD(30, 114));
            Assert.AreEqual(1, MathEx.GCD(31, 79));
            Assert.AreEqual(1, MathEx.GCD(32, 135));
            Assert.AreEqual(3, MathEx.GCD(33, 72));
            Assert.AreEqual(1, MathEx.GCD(34, 137));
            Assert.AreEqual(7, MathEx.GCD(35, 14));
            Assert.AreEqual(1, MathEx.GCD(36, 131));
            Assert.AreEqual(1, MathEx.GCD(37, 140));
            Assert.AreEqual(2, MathEx.GCD(38, 56));
            Assert.AreEqual(1, MathEx.GCD(39, 67));
            Assert.AreEqual(8, MathEx.GCD(40, 104));
            Assert.AreEqual(1, MathEx.GCD(41, 4));
            Assert.AreEqual(2, MathEx.GCD(42, 64));
            Assert.AreEqual(1, MathEx.GCD(43, 81));
            Assert.AreEqual(1, MathEx.GCD(44, 93));
            Assert.AreEqual(3, MathEx.GCD(45, 24));
            Assert.AreEqual(1, MathEx.GCD(46, 71));
            Assert.AreEqual(1, MathEx.GCD(47, 97));
            Assert.AreEqual(2, MathEx.GCD(48, 10));
            Assert.AreEqual(1, MathEx.GCD(49, 136));
            Assert.AreEqual(2, MathEx.GCD(50, 84));
            Assert.AreEqual(1, MathEx.GCD(51, 50));
            Assert.AreEqual(1, MathEx.GCD(52, 127));
            Assert.AreEqual(1, MathEx.GCD(53, 116));
            Assert.AreEqual(1, MathEx.GCD(54, 23));
            Assert.AreEqual(5, MathEx.GCD(55, 70));
            Assert.AreEqual(1, MathEx.GCD(56, 145));
            Assert.AreEqual(1, MathEx.GCD(57, 17));
            Assert.AreEqual(2, MathEx.GCD(58, 138));
            Assert.AreEqual(1, MathEx.GCD(59, 39));
            Assert.AreEqual(4, MathEx.GCD(60, 112));
            Assert.AreEqual(1, MathEx.GCD(61, 139));
            Assert.AreEqual(1, MathEx.GCD(62, 3));
            Assert.AreEqual(9, MathEx.GCD(63, 108));
            Assert.AreEqual(1, MathEx.GCD(64, 111));
            Assert.AreEqual(1, MathEx.GCD(65, 88));
            Assert.AreEqual(11, MathEx.GCD(66, 143));
            Assert.AreEqual(1, MathEx.GCD(67, 101));
            Assert.AreEqual(1, MathEx.GCD(68, 77));
            Assert.AreEqual(1, MathEx.GCD(69, 58));
            Assert.AreEqual(1, MathEx.GCD(70, 103));
            Assert.AreEqual(1, MathEx.GCD(71, 32));
            Assert.AreEqual(12, MathEx.GCD(72, 132));
            Assert.AreEqual(1, MathEx.GCD(73, 31));
            Assert.AreEqual(1, MathEx.GCD(74, 83));
            Assert.AreEqual(1, MathEx.GCD(75, 91));
            Assert.AreEqual(1, MathEx.GCD(76, 65));
            Assert.AreEqual(1, MathEx.GCD(77, 128));
            Assert.AreEqual(1, MathEx.GCD(78, 115));
            Assert.AreEqual(1, MathEx.GCD(79, 22));
            Assert.AreEqual(1, MathEx.GCD(80, 33));
            Assert.AreEqual(1, MathEx.GCD(81, 74));
            Assert.AreEqual(1, MathEx.GCD(82, 113));
            Assert.AreEqual(1, MathEx.GCD(83, 110));
            Assert.AreEqual(12, MathEx.GCD(84, 48));
            Assert.AreEqual(5, MathEx.GCD(85, 30));
            Assert.AreEqual(1, MathEx.GCD(86, 13));
            Assert.AreEqual(1, MathEx.GCD(87, 121));
            Assert.AreEqual(2, MathEx.GCD(88, 118));
            Assert.AreEqual(1, MathEx.GCD(89, 148));
            Assert.AreEqual(18, MathEx.GCD(90, 126));
            Assert.AreEqual(7, MathEx.GCD(91, 147));
            Assert.AreEqual(1, MathEx.GCD(92, 85));
            Assert.AreEqual(93, MathEx.GCD(93, 0));
            Assert.AreEqual(1, MathEx.GCD(94, 105));
            Assert.AreEqual(1, MathEx.GCD(95, 7));
            Assert.AreEqual(2, MathEx.GCD(96, 26));
            Assert.AreEqual(1, MathEx.GCD(97, 51));
            Assert.AreEqual(2, MathEx.GCD(98, 92));
            Assert.AreEqual(1, MathEx.GCD(99, 98));
            Assert.AreEqual(5, MathEx.GCD(100, 35));
            Assert.AreEqual(1, MathEx.GCD(101, 46));
            Assert.AreEqual(1, MathEx.GCD(102, 109));
            Assert.AreEqual(1, MathEx.GCD(103, 76));
            Assert.AreEqual(2, MathEx.GCD(104, 134));
            Assert.AreEqual(1, MathEx.GCD(105, 62));
            Assert.AreEqual(1, MathEx.GCD(106, 27));
            Assert.AreEqual(1, MathEx.GCD(107, 141));
            Assert.AreEqual(4, MathEx.GCD(108, 16));
            Assert.AreEqual(1, MathEx.GCD(109, 43));
            Assert.AreEqual(11, MathEx.GCD(110, 99));
            Assert.AreEqual(1, MathEx.GCD(111, 34));
            Assert.AreEqual(28, MathEx.GCD(112, 28));
            Assert.AreEqual(1, MathEx.GCD(113, 37));
            Assert.AreEqual(6, MathEx.GCD(114, 144));
            Assert.AreEqual(1, MathEx.GCD(115, 124));
            Assert.AreEqual(1, MathEx.GCD(116, 119));
            Assert.AreEqual(1, MathEx.GCD(117, 80));
            Assert.AreEqual(1, MathEx.GCD(118, 9));
            Assert.AreEqual(1, MathEx.GCD(119, 2));
            Assert.AreEqual(40, MathEx.GCD(120, 40));
            Assert.AreEqual(1, MathEx.GCD(121, 89));
            Assert.AreEqual(2, MathEx.GCD(122, 102));
            Assert.AreEqual(1, MathEx.GCD(123, 11));
            Assert.AreEqual(1, MathEx.GCD(124, 19));
            Assert.AreEqual(1, MathEx.GCD(125, 42));
            Assert.AreEqual(2, MathEx.GCD(126, 52));
            Assert.AreEqual(1, MathEx.GCD(127, 20));
            Assert.AreEqual(2, MathEx.GCD(128, 142));
            Assert.AreEqual(1, MathEx.GCD(129, 25));
            Assert.AreEqual(5, MathEx.GCD(130, 45));
            Assert.AreEqual(1, MathEx.GCD(131, 107));
            Assert.AreEqual(2, MathEx.GCD(132, 82));
            Assert.AreEqual(1, MathEx.GCD(133, 54));
            Assert.AreEqual(1, MathEx.GCD(134, 21));
            Assert.AreEqual(1, MathEx.GCD(135, 68));
            Assert.AreEqual(1, MathEx.GCD(136, 87));
            Assert.AreEqual(1, MathEx.GCD(137, 29));
            Assert.AreEqual(2, MathEx.GCD(138, 86));
            Assert.AreEqual(1, MathEx.GCD(139, 106));
            Assert.AreEqual(2, MathEx.GCD(140, 122));
            Assert.AreEqual(1, MathEx.GCD(141, 44));
            Assert.AreEqual(1, MathEx.GCD(142, 123));
            Assert.AreEqual(1, MathEx.GCD(143, 5));
            Assert.AreEqual(1, MathEx.GCD(144, 149));
            Assert.AreEqual(1, MathEx.GCD(145, 146));
            Assert.AreEqual(2, MathEx.GCD(146, 66));
            Assert.AreEqual(1, MathEx.GCD(147, 1));
            Assert.AreEqual(2, MathEx.GCD(148, 18));
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void GCD2()
        {
            // ReSharper disable RedundantCast
            Assert.AreEqual((long)8, MathEx.GCD((long)24, (long)16));
            Assert.AreEqual((long)8, MathEx.GCD((long)16, (long)24));
            Assert.AreEqual((long)16, MathEx.GCD((long)16, (long)16));
            Assert.AreEqual((long)1, MathEx.GCD((long)13, (long)29));

            Assert.AreEqual((long)41, MathEx.GCD((long)0, (long)41));
            Assert.AreEqual((long)1, MathEx.GCD((long)1, (long)55));
            Assert.AreEqual((long)1, MathEx.GCD((long)2, (long)129));
            Assert.AreEqual((long)1, MathEx.GCD((long)3, (long)95));
            Assert.AreEqual((long)1, MathEx.GCD((long)4, (long)125));
            Assert.AreEqual((long)5, MathEx.GCD((long)5, (long)75));
            Assert.AreEqual((long)6, MathEx.GCD((long)6, (long)6));
            Assert.AreEqual((long)1, MathEx.GCD((long)7, (long)94));
            Assert.AreEqual((long)2, MathEx.GCD((long)8, (long)130));
            Assert.AreEqual((long)9, MathEx.GCD((long)9, (long)36));
            Assert.AreEqual((long)1, MathEx.GCD((long)10, (long)61));
            Assert.AreEqual((long)1, MathEx.GCD((long)11, (long)15));
            Assert.AreEqual((long)2, MathEx.GCD((long)12, (long)38));
            Assert.AreEqual((long)1, MathEx.GCD((long)13, (long)47));
            Assert.AreEqual((long)7, MathEx.GCD((long)14, (long)133));
            Assert.AreEqual((long)3, MathEx.GCD((long)15, (long)12));
            Assert.AreEqual((long)4, MathEx.GCD((long)16, (long)100));
            Assert.AreEqual((long)1, MathEx.GCD((long)17, (long)53));
            Assert.AreEqual((long)6, MathEx.GCD((long)18, (long)96));
            Assert.AreEqual((long)1, MathEx.GCD((long)19, (long)90));
            Assert.AreEqual((long)20, MathEx.GCD((long)20, (long)60));
            Assert.AreEqual((long)3, MathEx.GCD((long)21, (long)57));
            Assert.AreEqual((long)2, MathEx.GCD((long)22, (long)78));
            Assert.AreEqual((long)1, MathEx.GCD((long)23, (long)49));
            Assert.AreEqual((long)1, MathEx.GCD((long)24, (long)73));
            Assert.AreEqual((long)1, MathEx.GCD((long)25, (long)117));
            Assert.AreEqual((long)1, MathEx.GCD((long)26, (long)59));
            Assert.AreEqual((long)3, MathEx.GCD((long)27, (long)69));
            Assert.AreEqual((long)4, MathEx.GCD((long)28, (long)120));
            Assert.AreEqual((long)1, MathEx.GCD((long)29, (long)63));
            Assert.AreEqual((long)6, MathEx.GCD((long)30, (long)114));
            Assert.AreEqual((long)1, MathEx.GCD((long)31, (long)79));
            Assert.AreEqual((long)1, MathEx.GCD((long)32, (long)135));
            Assert.AreEqual((long)3, MathEx.GCD((long)33, (long)72));
            Assert.AreEqual((long)1, MathEx.GCD((long)34, (long)137));
            Assert.AreEqual((long)7, MathEx.GCD((long)35, (long)14));
            Assert.AreEqual((long)1, MathEx.GCD((long)36, (long)131));
            Assert.AreEqual((long)1, MathEx.GCD((long)37, (long)140));
            Assert.AreEqual((long)2, MathEx.GCD((long)38, (long)56));
            Assert.AreEqual((long)1, MathEx.GCD((long)39, (long)67));
            Assert.AreEqual((long)8, MathEx.GCD((long)40, (long)104));
            Assert.AreEqual((long)1, MathEx.GCD((long)41, (long)4));
            Assert.AreEqual((long)2, MathEx.GCD((long)42, (long)64));
            Assert.AreEqual((long)1, MathEx.GCD((long)43, (long)81));
            Assert.AreEqual((long)1, MathEx.GCD((long)44, (long)93));
            Assert.AreEqual((long)3, MathEx.GCD((long)45, (long)24));
            Assert.AreEqual((long)1, MathEx.GCD((long)46, (long)71));
            Assert.AreEqual((long)1, MathEx.GCD((long)47, (long)97));
            Assert.AreEqual((long)2, MathEx.GCD((long)48, (long)10));
            Assert.AreEqual((long)1, MathEx.GCD((long)49, (long)136));
            Assert.AreEqual((long)2, MathEx.GCD((long)50, (long)84));
            Assert.AreEqual((long)1, MathEx.GCD((long)51, (long)50));
            Assert.AreEqual((long)1, MathEx.GCD((long)52, (long)127));
            Assert.AreEqual((long)1, MathEx.GCD((long)53, (long)116));
            Assert.AreEqual((long)1, MathEx.GCD((long)54, (long)23));
            Assert.AreEqual((long)5, MathEx.GCD((long)55, (long)70));
            Assert.AreEqual((long)1, MathEx.GCD((long)56, (long)145));
            Assert.AreEqual((long)1, MathEx.GCD((long)57, (long)17));
            Assert.AreEqual((long)2, MathEx.GCD((long)58, (long)138));
            Assert.AreEqual((long)1, MathEx.GCD((long)59, (long)39));
            Assert.AreEqual((long)4, MathEx.GCD((long)60, (long)112));
            Assert.AreEqual((long)1, MathEx.GCD((long)61, (long)139));
            Assert.AreEqual((long)1, MathEx.GCD((long)62, (long)3));
            Assert.AreEqual((long)9, MathEx.GCD((long)63, (long)108));
            Assert.AreEqual((long)1, MathEx.GCD((long)64, (long)111));
            Assert.AreEqual((long)1, MathEx.GCD((long)65, (long)88));
            Assert.AreEqual((long)11, MathEx.GCD((long)66, (long)143));
            Assert.AreEqual((long)1, MathEx.GCD((long)67, (long)101));
            Assert.AreEqual((long)1, MathEx.GCD((long)68, (long)77));
            Assert.AreEqual((long)1, MathEx.GCD((long)69, (long)58));
            Assert.AreEqual((long)1, MathEx.GCD((long)70, (long)103));
            Assert.AreEqual((long)1, MathEx.GCD((long)71, (long)32));
            Assert.AreEqual((long)12, MathEx.GCD((long)72, (long)132));
            Assert.AreEqual((long)1, MathEx.GCD((long)73, (long)31));
            Assert.AreEqual((long)1, MathEx.GCD((long)74, (long)83));
            Assert.AreEqual((long)1, MathEx.GCD((long)75, (long)91));
            Assert.AreEqual((long)1, MathEx.GCD((long)76, (long)65));
            Assert.AreEqual((long)1, MathEx.GCD((long)77, (long)128));
            Assert.AreEqual((long)1, MathEx.GCD((long)78, (long)115));
            Assert.AreEqual((long)1, MathEx.GCD((long)79, (long)22));
            Assert.AreEqual((long)1, MathEx.GCD((long)80, (long)33));
            Assert.AreEqual((long)1, MathEx.GCD((long)81, (long)74));
            Assert.AreEqual((long)1, MathEx.GCD((long)82, (long)113));
            Assert.AreEqual((long)1, MathEx.GCD((long)83, (long)110));
            Assert.AreEqual((long)12, MathEx.GCD((long)84, (long)48));
            Assert.AreEqual((long)5, MathEx.GCD((long)85, (long)30));
            Assert.AreEqual((long)1, MathEx.GCD((long)86, (long)13));
            Assert.AreEqual((long)1, MathEx.GCD((long)87, (long)121));
            Assert.AreEqual((long)2, MathEx.GCD((long)88, (long)118));
            Assert.AreEqual((long)1, MathEx.GCD((long)89, (long)148));
            Assert.AreEqual((long)18, MathEx.GCD((long)90, (long)126));
            Assert.AreEqual((long)7, MathEx.GCD((long)91, (long)147));
            Assert.AreEqual((long)1, MathEx.GCD((long)92, (long)85));
            Assert.AreEqual((long)93, MathEx.GCD((long)93, (long)0));
            Assert.AreEqual((long)1, MathEx.GCD((long)94, (long)105));
            Assert.AreEqual((long)1, MathEx.GCD((long)95, (long)7));
            Assert.AreEqual((long)2, MathEx.GCD((long)96, (long)26));
            Assert.AreEqual((long)1, MathEx.GCD((long)97, (long)51));
            Assert.AreEqual((long)2, MathEx.GCD((long)98, (long)92));
            Assert.AreEqual((long)1, MathEx.GCD((long)99, (long)98));
            Assert.AreEqual((long)5, MathEx.GCD((long)100, (long)35));
            Assert.AreEqual((long)1, MathEx.GCD((long)101, (long)46));
            Assert.AreEqual((long)1, MathEx.GCD((long)102, (long)109));
            Assert.AreEqual((long)1, MathEx.GCD((long)103, (long)76));
            Assert.AreEqual((long)2, MathEx.GCD((long)104, (long)134));
            Assert.AreEqual((long)1, MathEx.GCD((long)105, (long)62));
            Assert.AreEqual((long)1, MathEx.GCD((long)106, (long)27));
            Assert.AreEqual((long)1, MathEx.GCD((long)107, (long)141));
            Assert.AreEqual((long)4, MathEx.GCD((long)108, (long)16));
            Assert.AreEqual((long)1, MathEx.GCD((long)109, (long)43));
            Assert.AreEqual((long)11, MathEx.GCD((long)110, (long)99));
            Assert.AreEqual((long)1, MathEx.GCD((long)111, (long)34));
            Assert.AreEqual((long)28, MathEx.GCD((long)112, (long)28));
            Assert.AreEqual((long)1, MathEx.GCD((long)113, (long)37));
            Assert.AreEqual((long)6, MathEx.GCD((long)114, (long)144));
            Assert.AreEqual((long)1, MathEx.GCD((long)115, (long)124));
            Assert.AreEqual((long)1, MathEx.GCD((long)116, (long)119));
            Assert.AreEqual((long)1, MathEx.GCD((long)117, (long)80));
            Assert.AreEqual((long)1, MathEx.GCD((long)118, (long)9));
            Assert.AreEqual((long)1, MathEx.GCD((long)119, (long)2));
            Assert.AreEqual((long)40, MathEx.GCD((long)120, (long)40));
            Assert.AreEqual((long)1, MathEx.GCD((long)121, (long)89));
            Assert.AreEqual((long)2, MathEx.GCD((long)122, (long)102));
            Assert.AreEqual((long)1, MathEx.GCD((long)123, (long)11));
            Assert.AreEqual((long)1, MathEx.GCD((long)124, (long)19));
            Assert.AreEqual((long)1, MathEx.GCD((long)125, (long)42));
            Assert.AreEqual((long)2, MathEx.GCD((long)126, (long)52));
            Assert.AreEqual((long)1, MathEx.GCD((long)127, (long)20));
            Assert.AreEqual((long)2, MathEx.GCD((long)128, (long)142));
            Assert.AreEqual((long)1, MathEx.GCD((long)129, (long)25));
            Assert.AreEqual((long)5, MathEx.GCD((long)130, (long)45));
            Assert.AreEqual((long)1, MathEx.GCD((long)131, (long)107));
            Assert.AreEqual((long)2, MathEx.GCD((long)132, (long)82));
            Assert.AreEqual((long)1, MathEx.GCD((long)133, (long)54));
            Assert.AreEqual((long)1, MathEx.GCD((long)134, (long)21));
            Assert.AreEqual((long)1, MathEx.GCD((long)135, (long)68));
            Assert.AreEqual((long)1, MathEx.GCD((long)136, (long)87));
            Assert.AreEqual((long)1, MathEx.GCD((long)137, (long)29));
            Assert.AreEqual((long)2, MathEx.GCD((long)138, (long)86));
            Assert.AreEqual((long)1, MathEx.GCD((long)139, (long)106));
            Assert.AreEqual((long)2, MathEx.GCD((long)140, (long)122));
            Assert.AreEqual((long)1, MathEx.GCD((long)141, (long)44));
            Assert.AreEqual((long)1, MathEx.GCD((long)142, (long)123));
            Assert.AreEqual((long)1, MathEx.GCD((long)143, (long)5));
            Assert.AreEqual((long)1, MathEx.GCD((long)144, (long)149));
            Assert.AreEqual((long)1, MathEx.GCD((long)145, (long)146));
            Assert.AreEqual((long)2, MathEx.GCD((long)146, (long)66));
            Assert.AreEqual((long)1, MathEx.GCD((long)147, (long)1));
            Assert.AreEqual((long)2, MathEx.GCD((long)148, (long)18));
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void GCD3()
        {
            Assert.AreEqual(8, MathEx.GCD(new int[] { 24, 16 }));
            Assert.AreEqual(8, MathEx.GCD(new int[] { 16, 24 }));
            Assert.AreEqual(16, MathEx.GCD(new int[] { 16, 16 }));
            Assert.AreEqual(1, MathEx.GCD(new int[] { 13, 29 }));

            Assert.AreEqual(41, MathEx.GCD(new int[] { 0, 41 }));
            Assert.AreEqual(1, MathEx.GCD(new int[] { 1, 55 }));
            Assert.AreEqual(1, MathEx.GCD(new int[] { 2, 129 }));
            Assert.AreEqual(1, MathEx.GCD(new int[] { 3, 95 }));
            Assert.AreEqual(1, MathEx.GCD(new int[] { 4, 125 }));
        }
        [TestMethod]
        public void GCD4()
        {
            Assert.AreEqual(8, MathEx.GCD(new long[] { 24, 16 }));
            Assert.AreEqual(8, MathEx.GCD(new long[] { 16, 24 }));
            Assert.AreEqual(16, MathEx.GCD(new long[] { 16, 16 }));
            Assert.AreEqual(1, MathEx.GCD(new long[] { 13, 29 }));

            Assert.AreEqual(41, MathEx.GCD(new long[] { 0, 41 }));
            Assert.AreEqual(1, MathEx.GCD(new long[] { 1, 55 }));
            Assert.AreEqual(1, MathEx.GCD(new long[] { 2, 129 }));
            Assert.AreEqual(1, MathEx.GCD(new long[] { 3, 95 }));
            Assert.AreEqual(1, MathEx.GCD(new long[] { 4, 125 }));
        }

        [TestMethod]
        public void GCDExceptions()
        {
            TestHelper.AssertException<ArgumentException>(() => MathEx.GCD(new int[0]));
            TestHelper.AssertException<ArgumentException>(() => MathEx.GCD(new long[0]));
        }

        #endregion
        #region LCM

        [TestMethod]
        public void LCM()
        {
            // Generated, lol

            // ReSharper disable RedundantCast
            Assert.AreEqual(0, MathEx.LCM(0, 27));
            Assert.AreEqual(25, MathEx.LCM(1, 25));
            Assert.AreEqual(0, MathEx.LCM(2, 0));
            Assert.AreEqual(30, MathEx.LCM(3, 30));
            Assert.AreEqual(20, MathEx.LCM(4, 10));
            Assert.AreEqual(30, MathEx.LCM(5, 6));
            Assert.AreEqual(120, MathEx.LCM(6, 40));
            Assert.AreEqual(84, MathEx.LCM(7, 12));
            Assert.AreEqual(184, MathEx.LCM(8, 46));
            Assert.AreEqual(99, MathEx.LCM(9, 11));
            Assert.AreEqual(410, MathEx.LCM(10, 41));
            Assert.AreEqual(176, MathEx.LCM(11, 16));
            Assert.AreEqual(132, MathEx.LCM(12, 33));
            Assert.AreEqual(494, MathEx.LCM(13, 38));
            Assert.AreEqual(126, MathEx.LCM(14, 9));
            Assert.AreEqual(105, MathEx.LCM(15, 35));
            Assert.AreEqual(48, MathEx.LCM(16, 3));
            Assert.AreEqual(476, MathEx.LCM(17, 28));
            Assert.AreEqual(90, MathEx.LCM(18, 15));
            Assert.AreEqual(418, MathEx.LCM(19, 22));
            Assert.AreEqual(140, MathEx.LCM(20, 14));
            Assert.AreEqual(105, MathEx.LCM(21, 5));
            Assert.AreEqual(814, MathEx.LCM(22, 37));
            Assert.AreEqual(1012, MathEx.LCM(23, 44));
            Assert.AreEqual(24, MathEx.LCM(24, 8));
            Assert.AreEqual(475, MathEx.LCM(25, 19));
            Assert.AreEqual(312, MathEx.LCM(26, 24));
            Assert.AreEqual(918, MathEx.LCM(27, 34));
            Assert.AreEqual(28, MathEx.LCM(28, 7));
            Assert.AreEqual(1305, MathEx.LCM(29, 45));
            Assert.AreEqual(930, MathEx.LCM(30, 31));
            Assert.AreEqual(527, MathEx.LCM(31, 17));
            Assert.AreEqual(672, MathEx.LCM(32, 42));
            Assert.AreEqual(429, MathEx.LCM(33, 13));
            Assert.AreEqual(442, MathEx.LCM(34, 26));
            Assert.AreEqual(105, MathEx.LCM(35, 21));
            Assert.AreEqual(36, MathEx.LCM(36, 18));
            Assert.AreEqual(74, MathEx.LCM(37, 2));
            Assert.AreEqual(76, MathEx.LCM(38, 4));
            Assert.AreEqual(1911, MathEx.LCM(39, 49));
            Assert.AreEqual(160, MathEx.LCM(40, 32));
            Assert.AreEqual(943, MathEx.LCM(41, 23));
            Assert.AreEqual(546, MathEx.LCM(42, 39));
            Assert.AreEqual(860, MathEx.LCM(43, 20));
            Assert.AreEqual(396, MathEx.LCM(44, 36));
            Assert.AreEqual(45, MathEx.LCM(45, 1));
            Assert.AreEqual(1104, MathEx.LCM(46, 48));
            Assert.AreEqual(47, MathEx.LCM(47, 47));
            Assert.AreEqual(1392, MathEx.LCM(48, 29));
            Assert.AreEqual(0, MathEx.LCM(0, 6));
            Assert.AreEqual(93, MathEx.LCM(1, 93));
            Assert.AreEqual(8, MathEx.LCM(2, 8));
            Assert.AreEqual(129, MathEx.LCM(3, 43));
            Assert.AreEqual(180, MathEx.LCM(4, 90));
            Assert.AreEqual(110, MathEx.LCM(5, 110));
            Assert.AreEqual(510, MathEx.LCM(6, 85));
            Assert.AreEqual(42, MathEx.LCM(7, 42));
            Assert.AreEqual(120, MathEx.LCM(8, 30));
            Assert.AreEqual(342, MathEx.LCM(9, 114));
            Assert.AreEqual(910, MathEx.LCM(10, 91));
            Assert.AreEqual(352, MathEx.LCM(11, 32));
            Assert.AreEqual(60, MathEx.LCM(12, 5));
            Assert.AreEqual(1339, MathEx.LCM(13, 103));
            Assert.AreEqual(14, MathEx.LCM(14, 14));
            Assert.AreEqual(1965, MathEx.LCM(15, 131));
            Assert.AreEqual(496, MathEx.LCM(16, 31));
            Assert.AreEqual(2295, MathEx.LCM(17, 135));
            Assert.AreEqual(1278, MathEx.LCM(18, 71));
            Assert.AreEqual(1102, MathEx.LCM(19, 58));
            Assert.AreEqual(20, MathEx.LCM(20, 20));
            Assert.AreEqual(714, MathEx.LCM(21, 102));
            Assert.AreEqual(66, MathEx.LCM(22, 66));
            Assert.AreEqual(805, MathEx.LCM(23, 35));
            Assert.AreEqual(72, MathEx.LCM(24, 72));
            Assert.AreEqual(2300, MathEx.LCM(25, 92));
            Assert.AreEqual(1118, MathEx.LCM(26, 86));
            Assert.AreEqual(1836, MathEx.LCM(27, 68));
            Assert.AreEqual(1260, MathEx.LCM(28, 45));
            Assert.AreEqual(3944, MathEx.LCM(29, 136));
            Assert.AreEqual(570, MathEx.LCM(30, 38));
            Assert.AreEqual(4557, MathEx.LCM(31, 147));
            Assert.AreEqual(416, MathEx.LCM(32, 52));
            Assert.AreEqual(1221, MathEx.LCM(33, 111));
            Assert.AreEqual(4658, MathEx.LCM(34, 137));
            Assert.AreEqual(595, MathEx.LCM(35, 17));
            Assert.AreEqual(3924, MathEx.LCM(36, 109));
            Assert.AreEqual(74, MathEx.LCM(37, 2));
            Assert.AreEqual(874, MathEx.LCM(38, 23));
            Assert.AreEqual(1833, MathEx.LCM(39, 141));
            Assert.AreEqual(1080, MathEx.LCM(40, 27));
            Assert.AreEqual(3444, MathEx.LCM(41, 84));
            Assert.AreEqual(966, MathEx.LCM(42, 46));
            Assert.AreEqual(946, MathEx.LCM(43, 22));
            Assert.AreEqual(1540, MathEx.LCM(44, 140));
            Assert.AreEqual(3420, MathEx.LCM(45, 76));
            Assert.AreEqual(1518, MathEx.LCM(46, 33));
            Assert.AreEqual(3525, MathEx.LCM(47, 75));
            Assert.AreEqual(5424, MathEx.LCM(48, 113));
            Assert.AreEqual(0, MathEx.LCM(0, 55));
            Assert.AreEqual(67, MathEx.LCM(1, 67));
            Assert.AreEqual(138, MathEx.LCM(2, 138));
            Assert.AreEqual(390, MathEx.LCM(3, 130));
            Assert.AreEqual(540, MathEx.LCM(4, 135));
            Assert.AreEqual(740, MathEx.LCM(5, 148));
            Assert.AreEqual(120, MathEx.LCM(6, 40));
            Assert.AreEqual(0, MathEx.LCM(7, 0));
            Assert.AreEqual(80, MathEx.LCM(8, 80));
            Assert.AreEqual(72, MathEx.LCM(9, 24));
            Assert.AreEqual(110, MathEx.LCM(10, 22));
            Assert.AreEqual(1045, MathEx.LCM(11, 95));
            Assert.AreEqual(444, MathEx.LCM(12, 74));
            Assert.AreEqual(1612, MathEx.LCM(13, 124));
            Assert.AreEqual(182, MathEx.LCM(14, 26));
            Assert.AreEqual(240, MathEx.LCM(15, 16));
            Assert.AreEqual(2352, MathEx.LCM(16, 147));
            Assert.AreEqual(816, MathEx.LCM(17, 48));
            Assert.AreEqual(90, MathEx.LCM(18, 5));
            Assert.AreEqual(2831, MathEx.LCM(19, 149));
            Assert.AreEqual(100, MathEx.LCM(20, 25));
            Assert.AreEqual(651, MathEx.LCM(21, 93));
            Assert.AreEqual(66, MathEx.LCM(22, 3));
            Assert.AreEqual(1311, MathEx.LCM(23, 57));
            Assert.AreEqual(744, MathEx.LCM(24, 31));
            Assert.AreEqual(50, MathEx.LCM(25, 50));
            Assert.AreEqual(3770, MathEx.LCM(26, 145));
            Assert.AreEqual(2808, MathEx.LCM(27, 104));
            Assert.AreEqual(1204, MathEx.LCM(28, 43));
            Assert.AreEqual(2117, MathEx.LCM(29, 73));
            Assert.AreEqual(3630, MathEx.LCM(30, 121));
            Assert.AreEqual(2728, MathEx.LCM(31, 88));
            Assert.AreEqual(864, MathEx.LCM(32, 54));
            Assert.AreEqual(1716, MathEx.LCM(33, 52));
            Assert.AreEqual(714, MathEx.LCM(34, 42));
            Assert.AreEqual(2030, MathEx.LCM(35, 58));
            Assert.AreEqual(36, MathEx.LCM(36, 2));
            Assert.AreEqual(4514, MathEx.LCM(37, 122));
            Assert.AreEqual(3002, MathEx.LCM(38, 79));
            Assert.AreEqual(1482, MathEx.LCM(39, 38));
            Assert.AreEqual(680, MathEx.LCM(40, 34));
            Assert.AreEqual(5289, MathEx.LCM(41, 129));
            Assert.AreEqual(966, MathEx.LCM(42, 46));
            Assert.AreEqual(4988, MathEx.LCM(43, 116));
            Assert.AreEqual(924, MathEx.LCM(44, 84));
            Assert.AreEqual(4635, MathEx.LCM(45, 103));
            Assert.AreEqual(2760, MathEx.LCM(46, 120));
            Assert.AreEqual(4042, MathEx.LCM(47, 86));
            Assert.AreEqual(6672, MathEx.LCM(48, 139));
            Assert.AreEqual(539, MathEx.LCM(49, 77));
            Assert.AreEqual(650, MathEx.LCM(50, 13));
            Assert.AreEqual(102, MathEx.LCM(51, 6));
            Assert.AreEqual(1716, MathEx.LCM(52, 33));
            Assert.AreEqual(2067, MathEx.LCM(53, 39));
            Assert.AreEqual(702, MathEx.LCM(54, 78));
            Assert.AreEqual(55, MathEx.LCM(55, 11));
            Assert.AreEqual(2968, MathEx.LCM(56, 106));
            Assert.AreEqual(1311, MathEx.LCM(57, 69));
            Assert.AreEqual(4930, MathEx.LCM(58, 85));
            Assert.AreEqual(1888, MathEx.LCM(59, 32));
            Assert.AreEqual(660, MathEx.LCM(60, 66));
            Assert.AreEqual(4331, MathEx.LCM(61, 71));
            Assert.AreEqual(3906, MathEx.LCM(62, 126));
            Assert.AreEqual(8631, MathEx.LCM(63, 137));
            Assert.AreEqual(3904, MathEx.LCM(64, 61));
            Assert.AreEqual(6240, MathEx.LCM(65, 96));
            Assert.AreEqual(462, MathEx.LCM(66, 14));
            Assert.AreEqual(2010, MathEx.LCM(67, 30));
            Assert.AreEqual(1836, MathEx.LCM(68, 108));
            Assert.AreEqual(8763, MathEx.LCM(69, 127));
            Assert.AreEqual(2660, MathEx.LCM(70, 76));
            Assert.AreEqual(3763, MathEx.LCM(71, 53));
            Assert.AreEqual(2520, MathEx.LCM(72, 70));
            Assert.AreEqual(2117, MathEx.LCM(73, 29));
            Assert.AreEqual(3478, MathEx.LCM(74, 47));
            Assert.AreEqual(4425, MathEx.LCM(75, 59));
            Assert.AreEqual(6612, MathEx.LCM(76, 87));
            Assert.AreEqual(6930, MathEx.LCM(77, 90));
            Assert.AreEqual(4992, MathEx.LCM(78, 128));
            Assert.AreEqual(948, MathEx.LCM(79, 12));
            Assert.AreEqual(2480, MathEx.LCM(80, 62));
            Assert.AreEqual(3078, MathEx.LCM(81, 114));
            Assert.AreEqual(2952, MathEx.LCM(82, 72));
            Assert.AreEqual(3403, MathEx.LCM(83, 41));
            Assert.AreEqual(9660, MathEx.LCM(84, 115));
            Assert.AreEqual(170, MathEx.LCM(85, 10));
            Assert.AreEqual(9546, MathEx.LCM(86, 111));
            Assert.AreEqual(12354, MathEx.LCM(87, 142));
            Assert.AreEqual(6600, MathEx.LCM(88, 75));
            Assert.AreEqual(3293, MathEx.LCM(89, 37));
            Assert.AreEqual(630, MathEx.LCM(90, 63));
            Assert.AreEqual(9919, MathEx.LCM(91, 109));
            Assert.AreEqual(12236, MathEx.LCM(92, 133));
            Assert.AreEqual(1767, MathEx.LCM(93, 19));
            Assert.AreEqual(9870, MathEx.LCM(94, 105));
            Assert.AreEqual(8455, MathEx.LCM(95, 89));
            Assert.AreEqual(96, MathEx.LCM(96, 8));
            Assert.AreEqual(4268, MathEx.LCM(97, 44));
            Assert.AreEqual(12838, MathEx.LCM(98, 131));
            Assert.AreEqual(99, MathEx.LCM(99, 99));
            Assert.AreEqual(900, MathEx.LCM(100, 18));
            Assert.AreEqual(4545, MathEx.LCM(101, 45));
            Assert.AreEqual(2448, MathEx.LCM(102, 144));
            Assert.AreEqual(14008, MathEx.LCM(103, 136));
            Assert.AreEqual(12792, MathEx.LCM(104, 123));
            Assert.AreEqual(12390, MathEx.LCM(105, 118));
            Assert.AreEqual(14946, MathEx.LCM(106, 141));
            Assert.AreEqual(14338, MathEx.LCM(107, 134));
            Assert.AreEqual(1404, MathEx.LCM(108, 117));
            Assert.AreEqual(10682, MathEx.LCM(109, 98));
            Assert.AreEqual(10670, MathEx.LCM(110, 97));
            Assert.AreEqual(13209, MathEx.LCM(111, 119));
            Assert.AreEqual(1680, MathEx.LCM(112, 60));
            Assert.AreEqual(5537, MathEx.LCM(113, 49));
            Assert.AreEqual(228, MathEx.LCM(114, 4));
            Assert.AreEqual(1495, MathEx.LCM(115, 65));
            Assert.AreEqual(812, MathEx.LCM(116, 28));
            Assert.AreEqual(12870, MathEx.LCM(117, 110));
            Assert.AreEqual(13334, MathEx.LCM(118, 113));
            Assert.AreEqual(1785, MathEx.LCM(119, 15));
            Assert.AreEqual(3240, MathEx.LCM(120, 81));
            Assert.AreEqual(12947, MathEx.LCM(121, 107));
            Assert.AreEqual(1220, MathEx.LCM(122, 20));
            Assert.AreEqual(369, MathEx.LCM(123, 9));
            Assert.AreEqual(11284, MathEx.LCM(124, 91));
            Assert.AreEqual(4500, MathEx.LCM(125, 36));
            Assert.AreEqual(9198, MathEx.LCM(126, 146));
            Assert.AreEqual(2921, MathEx.LCM(127, 23));
            Assert.AreEqual(896, MathEx.LCM(128, 112));
            Assert.AreEqual(2193, MathEx.LCM(129, 17));
            Assert.AreEqual(1820, MathEx.LCM(130, 140));
            Assert.AreEqual(16375, MathEx.LCM(131, 125));
            Assert.AreEqual(13332, MathEx.LCM(132, 101));
            Assert.AreEqual(665, MathEx.LCM(133, 35));
            Assert.AreEqual(4556, MathEx.LCM(134, 68));
            Assert.AreEqual(19305, MathEx.LCM(135, 143));
            Assert.AreEqual(1088, MathEx.LCM(136, 64));
            Assert.AreEqual(7672, MathEx.LCM(137, 56));
            Assert.AreEqual(3036, MathEx.LCM(138, 132));
            Assert.AreEqual(7089, MathEx.LCM(139, 51));
            Assert.AreEqual(7140, MathEx.LCM(140, 102));
            Assert.AreEqual(11703, MathEx.LCM(141, 83));
            Assert.AreEqual(5822, MathEx.LCM(142, 82));
            Assert.AreEqual(13442, MathEx.LCM(143, 94));
            Assert.AreEqual(3600, MathEx.LCM(144, 100));
            Assert.AreEqual(1015, MathEx.LCM(145, 7));
            Assert.AreEqual(3942, MathEx.LCM(146, 27));
            Assert.AreEqual(147, MathEx.LCM(147, 21));
            Assert.AreEqual(3404, MathEx.LCM(148, 92));
            // ReSharper restore RedundantCast
        }

        [TestMethod]
        public void LCM2()
        {
            // Generated, lol

            // ReSharper disable RedundantCast
            Assert.AreEqual((long)0, MathEx.LCM((long)0, (long)27));
            Assert.AreEqual((long)25, MathEx.LCM((long)1, (long)25));
            Assert.AreEqual((long)0, MathEx.LCM((long)2, (long)0));
            Assert.AreEqual((long)30, MathEx.LCM((long)3, (long)30));
            Assert.AreEqual((long)20, MathEx.LCM((long)4, (long)10));
            Assert.AreEqual((long)30, MathEx.LCM((long)5, (long)6));
            Assert.AreEqual((long)120, MathEx.LCM((long)6, (long)40));
            Assert.AreEqual((long)84, MathEx.LCM((long)7, (long)12));
            Assert.AreEqual((long)184, MathEx.LCM((long)8, (long)46));
            Assert.AreEqual((long)99, MathEx.LCM((long)9, (long)11));
            Assert.AreEqual((long)410, MathEx.LCM((long)10, (long)41));
            Assert.AreEqual((long)176, MathEx.LCM((long)11, (long)16));
            Assert.AreEqual((long)132, MathEx.LCM((long)12, (long)33));
            Assert.AreEqual((long)494, MathEx.LCM((long)13, (long)38));
            Assert.AreEqual((long)126, MathEx.LCM((long)14, (long)9));
            Assert.AreEqual((long)105, MathEx.LCM((long)15, (long)35));
            Assert.AreEqual((long)48, MathEx.LCM((long)16, (long)3));
            Assert.AreEqual((long)476, MathEx.LCM((long)17, (long)28));
            Assert.AreEqual((long)90, MathEx.LCM((long)18, (long)15));
            Assert.AreEqual((long)418, MathEx.LCM((long)19, (long)22));
            Assert.AreEqual((long)140, MathEx.LCM((long)20, (long)14));
            Assert.AreEqual((long)105, MathEx.LCM((long)21, (long)5));
            Assert.AreEqual((long)814, MathEx.LCM((long)22, (long)37));
            Assert.AreEqual((long)1012, MathEx.LCM((long)23, (long)44));
            Assert.AreEqual((long)24, MathEx.LCM((long)24, (long)8));
            Assert.AreEqual((long)475, MathEx.LCM((long)25, (long)19));
            Assert.AreEqual((long)312, MathEx.LCM((long)26, (long)24));
            Assert.AreEqual((long)918, MathEx.LCM((long)27, (long)34));
            Assert.AreEqual((long)28, MathEx.LCM((long)28, (long)7));
            Assert.AreEqual((long)1305, MathEx.LCM((long)29, (long)45));
            Assert.AreEqual((long)930, MathEx.LCM((long)30, (long)31));
            Assert.AreEqual((long)527, MathEx.LCM((long)31, (long)17));
            Assert.AreEqual((long)672, MathEx.LCM((long)32, (long)42));
            Assert.AreEqual((long)429, MathEx.LCM((long)33, (long)13));
            Assert.AreEqual((long)442, MathEx.LCM((long)34, (long)26));
            Assert.AreEqual((long)105, MathEx.LCM((long)35, (long)21));
            Assert.AreEqual((long)36, MathEx.LCM((long)36, (long)18));
            Assert.AreEqual((long)74, MathEx.LCM((long)37, (long)2));
            Assert.AreEqual((long)76, MathEx.LCM((long)38, (long)4));
            Assert.AreEqual((long)1911, MathEx.LCM((long)39, (long)49));
            Assert.AreEqual((long)160, MathEx.LCM((long)40, (long)32));
            Assert.AreEqual((long)943, MathEx.LCM((long)41, (long)23));
            Assert.AreEqual((long)546, MathEx.LCM((long)42, (long)39));
            Assert.AreEqual((long)860, MathEx.LCM((long)43, (long)20));
            Assert.AreEqual((long)396, MathEx.LCM((long)44, (long)36));
            Assert.AreEqual((long)45, MathEx.LCM((long)45, (long)1));
            Assert.AreEqual((long)1104, MathEx.LCM((long)46, (long)48));
            Assert.AreEqual((long)47, MathEx.LCM((long)47, (long)47));
            Assert.AreEqual((long)1392, MathEx.LCM((long)48, (long)29));
            Assert.AreEqual((long)0, MathEx.LCM((long)0, (long)6));
            Assert.AreEqual((long)93, MathEx.LCM((long)1, (long)93));
            Assert.AreEqual((long)8, MathEx.LCM((long)2, (long)8));
            Assert.AreEqual((long)129, MathEx.LCM((long)3, (long)43));
            Assert.AreEqual((long)180, MathEx.LCM((long)4, (long)90));
            Assert.AreEqual((long)110, MathEx.LCM((long)5, (long)110));
            Assert.AreEqual((long)510, MathEx.LCM((long)6, (long)85));
            Assert.AreEqual((long)42, MathEx.LCM((long)7, (long)42));
            Assert.AreEqual((long)120, MathEx.LCM((long)8, (long)30));
            Assert.AreEqual((long)342, MathEx.LCM((long)9, (long)114));
            Assert.AreEqual((long)910, MathEx.LCM((long)10, (long)91));
            Assert.AreEqual((long)352, MathEx.LCM((long)11, (long)32));
            Assert.AreEqual((long)60, MathEx.LCM((long)12, (long)5));
            Assert.AreEqual((long)1339, MathEx.LCM((long)13, (long)103));
            Assert.AreEqual((long)14, MathEx.LCM((long)14, (long)14));
            Assert.AreEqual((long)1965, MathEx.LCM((long)15, (long)131));
            Assert.AreEqual((long)496, MathEx.LCM((long)16, (long)31));
            Assert.AreEqual((long)2295, MathEx.LCM((long)17, (long)135));
            Assert.AreEqual((long)1278, MathEx.LCM((long)18, (long)71));
            Assert.AreEqual((long)1102, MathEx.LCM((long)19, (long)58));
            Assert.AreEqual((long)20, MathEx.LCM((long)20, (long)20));
            Assert.AreEqual((long)714, MathEx.LCM((long)21, (long)102));
            Assert.AreEqual((long)66, MathEx.LCM((long)22, (long)66));
            Assert.AreEqual((long)805, MathEx.LCM((long)23, (long)35));
            Assert.AreEqual((long)72, MathEx.LCM((long)24, (long)72));
            Assert.AreEqual((long)2300, MathEx.LCM((long)25, (long)92));
            Assert.AreEqual((long)1118, MathEx.LCM((long)26, (long)86));
            Assert.AreEqual((long)1836, MathEx.LCM((long)27, (long)68));
            Assert.AreEqual((long)1260, MathEx.LCM((long)28, (long)45));
            Assert.AreEqual((long)3944, MathEx.LCM((long)29, (long)136));
            Assert.AreEqual((long)570, MathEx.LCM((long)30, (long)38));
            Assert.AreEqual((long)4557, MathEx.LCM((long)31, (long)147));
            Assert.AreEqual((long)416, MathEx.LCM((long)32, (long)52));
            Assert.AreEqual((long)1221, MathEx.LCM((long)33, (long)111));
            Assert.AreEqual((long)4658, MathEx.LCM((long)34, (long)137));
            Assert.AreEqual((long)595, MathEx.LCM((long)35, (long)17));
            Assert.AreEqual((long)3924, MathEx.LCM((long)36, (long)109));
            Assert.AreEqual((long)74, MathEx.LCM((long)37, (long)2));
            Assert.AreEqual((long)874, MathEx.LCM((long)38, (long)23));
            Assert.AreEqual((long)1833, MathEx.LCM((long)39, (long)141));
            Assert.AreEqual((long)1080, MathEx.LCM((long)40, (long)27));
            Assert.AreEqual((long)3444, MathEx.LCM((long)41, (long)84));
            Assert.AreEqual((long)966, MathEx.LCM((long)42, (long)46));
            Assert.AreEqual((long)946, MathEx.LCM((long)43, (long)22));
            Assert.AreEqual((long)1540, MathEx.LCM((long)44, (long)140));
            Assert.AreEqual((long)3420, MathEx.LCM((long)45, (long)76));
            Assert.AreEqual((long)1518, MathEx.LCM((long)46, (long)33));
            Assert.AreEqual((long)3525, MathEx.LCM((long)47, (long)75));
            Assert.AreEqual((long)5424, MathEx.LCM((long)48, (long)113));
            Assert.AreEqual((long)0, MathEx.LCM((long)0, (long)55));
            Assert.AreEqual((long)67, MathEx.LCM((long)1, (long)67));
            Assert.AreEqual((long)138, MathEx.LCM((long)2, (long)138));
            Assert.AreEqual((long)390, MathEx.LCM((long)3, (long)130));
            Assert.AreEqual((long)540, MathEx.LCM((long)4, (long)135));
            Assert.AreEqual((long)740, MathEx.LCM((long)5, (long)148));
            Assert.AreEqual((long)120, MathEx.LCM((long)6, (long)40));
            Assert.AreEqual((long)0, MathEx.LCM((long)7, (long)0));
            Assert.AreEqual((long)80, MathEx.LCM((long)8, (long)80));
            Assert.AreEqual((long)72, MathEx.LCM((long)9, (long)24));
            Assert.AreEqual((long)110, MathEx.LCM((long)10, (long)22));
            Assert.AreEqual((long)1045, MathEx.LCM((long)11, (long)95));
            Assert.AreEqual((long)444, MathEx.LCM((long)12, (long)74));
            Assert.AreEqual((long)1612, MathEx.LCM((long)13, (long)124));
            Assert.AreEqual((long)182, MathEx.LCM((long)14, (long)26));
            Assert.AreEqual((long)240, MathEx.LCM((long)15, (long)16));
            Assert.AreEqual((long)2352, MathEx.LCM((long)16, (long)147));
            Assert.AreEqual((long)816, MathEx.LCM((long)17, (long)48));
            Assert.AreEqual((long)90, MathEx.LCM((long)18, (long)5));
            Assert.AreEqual((long)2831, MathEx.LCM((long)19, (long)149));
            Assert.AreEqual((long)100, MathEx.LCM((long)20, (long)25));
            Assert.AreEqual((long)651, MathEx.LCM((long)21, (long)93));
            Assert.AreEqual((long)66, MathEx.LCM((long)22, (long)3));
            Assert.AreEqual((long)1311, MathEx.LCM((long)23, (long)57));
            Assert.AreEqual((long)744, MathEx.LCM((long)24, (long)31));
            Assert.AreEqual((long)50, MathEx.LCM((long)25, (long)50));
            Assert.AreEqual((long)3770, MathEx.LCM((long)26, (long)145));
            Assert.AreEqual((long)2808, MathEx.LCM((long)27, (long)104));
            Assert.AreEqual((long)1204, MathEx.LCM((long)28, (long)43));
            Assert.AreEqual((long)2117, MathEx.LCM((long)29, (long)73));
            Assert.AreEqual((long)3630, MathEx.LCM((long)30, (long)121));
            Assert.AreEqual((long)2728, MathEx.LCM((long)31, (long)88));
            Assert.AreEqual((long)864, MathEx.LCM((long)32, (long)54));
            Assert.AreEqual((long)1716, MathEx.LCM((long)33, (long)52));
            Assert.AreEqual((long)714, MathEx.LCM((long)34, (long)42));
            Assert.AreEqual((long)2030, MathEx.LCM((long)35, (long)58));
            Assert.AreEqual((long)36, MathEx.LCM((long)36, (long)2));
            Assert.AreEqual((long)4514, MathEx.LCM((long)37, (long)122));
            Assert.AreEqual((long)3002, MathEx.LCM((long)38, (long)79));
            Assert.AreEqual((long)1482, MathEx.LCM((long)39, (long)38));
            Assert.AreEqual((long)680, MathEx.LCM((long)40, (long)34));
            Assert.AreEqual((long)5289, MathEx.LCM((long)41, (long)129));
            Assert.AreEqual((long)966, MathEx.LCM((long)42, (long)46));
            Assert.AreEqual((long)4988, MathEx.LCM((long)43, (long)116));
            Assert.AreEqual((long)924, MathEx.LCM((long)44, (long)84));
            Assert.AreEqual((long)4635, MathEx.LCM((long)45, (long)103));
            Assert.AreEqual((long)2760, MathEx.LCM((long)46, (long)120));
            Assert.AreEqual((long)4042, MathEx.LCM((long)47, (long)86));
            Assert.AreEqual((long)6672, MathEx.LCM((long)48, (long)139));
            Assert.AreEqual((long)539, MathEx.LCM((long)49, (long)77));
            Assert.AreEqual((long)650, MathEx.LCM((long)50, (long)13));
            Assert.AreEqual((long)102, MathEx.LCM((long)51, (long)6));
            Assert.AreEqual((long)1716, MathEx.LCM((long)52, (long)33));
            Assert.AreEqual((long)2067, MathEx.LCM((long)53, (long)39));
            Assert.AreEqual((long)702, MathEx.LCM((long)54, (long)78));
            Assert.AreEqual((long)55, MathEx.LCM((long)55, (long)11));
            Assert.AreEqual((long)2968, MathEx.LCM((long)56, (long)106));
            Assert.AreEqual((long)1311, MathEx.LCM((long)57, (long)69));
            Assert.AreEqual((long)4930, MathEx.LCM((long)58, (long)85));
            Assert.AreEqual((long)1888, MathEx.LCM((long)59, (long)32));
            Assert.AreEqual((long)660, MathEx.LCM((long)60, (long)66));
            Assert.AreEqual((long)4331, MathEx.LCM((long)61, (long)71));
            Assert.AreEqual((long)3906, MathEx.LCM((long)62, (long)126));
            Assert.AreEqual((long)8631, MathEx.LCM((long)63, (long)137));
            Assert.AreEqual((long)3904, MathEx.LCM((long)64, (long)61));
            Assert.AreEqual((long)6240, MathEx.LCM((long)65, (long)96));
            Assert.AreEqual((long)462, MathEx.LCM((long)66, (long)14));
            Assert.AreEqual((long)2010, MathEx.LCM((long)67, (long)30));
            Assert.AreEqual((long)1836, MathEx.LCM((long)68, (long)108));
            Assert.AreEqual((long)8763, MathEx.LCM((long)69, (long)127));
            Assert.AreEqual((long)2660, MathEx.LCM((long)70, (long)76));
            Assert.AreEqual((long)3763, MathEx.LCM((long)71, (long)53));
            Assert.AreEqual((long)2520, MathEx.LCM((long)72, (long)70));
            Assert.AreEqual((long)2117, MathEx.LCM((long)73, (long)29));
            Assert.AreEqual((long)3478, MathEx.LCM((long)74, (long)47));
            Assert.AreEqual((long)4425, MathEx.LCM((long)75, (long)59));
            Assert.AreEqual((long)6612, MathEx.LCM((long)76, (long)87));
            Assert.AreEqual((long)6930, MathEx.LCM((long)77, (long)90));
            Assert.AreEqual((long)4992, MathEx.LCM((long)78, (long)128));
            Assert.AreEqual((long)948, MathEx.LCM((long)79, (long)12));
            Assert.AreEqual((long)2480, MathEx.LCM((long)80, (long)62));
            Assert.AreEqual((long)3078, MathEx.LCM((long)81, (long)114));
            Assert.AreEqual((long)2952, MathEx.LCM((long)82, (long)72));
            Assert.AreEqual((long)3403, MathEx.LCM((long)83, (long)41));
            Assert.AreEqual((long)9660, MathEx.LCM((long)84, (long)115));
            Assert.AreEqual((long)170, MathEx.LCM((long)85, (long)10));
            Assert.AreEqual((long)9546, MathEx.LCM((long)86, (long)111));
            Assert.AreEqual((long)12354, MathEx.LCM((long)87, (long)142));
            Assert.AreEqual((long)6600, MathEx.LCM((long)88, (long)75));
            Assert.AreEqual((long)3293, MathEx.LCM((long)89, (long)37));
            Assert.AreEqual((long)630, MathEx.LCM((long)90, (long)63));
            Assert.AreEqual((long)9919, MathEx.LCM((long)91, (long)109));
            Assert.AreEqual((long)12236, MathEx.LCM((long)92, (long)133));
            Assert.AreEqual((long)1767, MathEx.LCM((long)93, (long)19));
            Assert.AreEqual((long)9870, MathEx.LCM((long)94, (long)105));
            Assert.AreEqual((long)8455, MathEx.LCM((long)95, (long)89));
            Assert.AreEqual((long)96, MathEx.LCM((long)96, (long)8));
            Assert.AreEqual((long)4268, MathEx.LCM((long)97, (long)44));
            Assert.AreEqual((long)12838, MathEx.LCM((long)98, (long)131));
            Assert.AreEqual((long)99, MathEx.LCM((long)99, (long)99));
            Assert.AreEqual((long)900, MathEx.LCM((long)100, (long)18));
            Assert.AreEqual((long)4545, MathEx.LCM((long)101, (long)45));
            Assert.AreEqual((long)2448, MathEx.LCM((long)102, (long)144));
            Assert.AreEqual((long)14008, MathEx.LCM((long)103, (long)136));
            Assert.AreEqual((long)12792, MathEx.LCM((long)104, (long)123));
            Assert.AreEqual((long)12390, MathEx.LCM((long)105, (long)118));
            Assert.AreEqual((long)14946, MathEx.LCM((long)106, (long)141));
            Assert.AreEqual((long)14338, MathEx.LCM((long)107, (long)134));
            Assert.AreEqual((long)1404, MathEx.LCM((long)108, (long)117));
            Assert.AreEqual((long)10682, MathEx.LCM((long)109, (long)98));
            Assert.AreEqual((long)10670, MathEx.LCM((long)110, (long)97));
            Assert.AreEqual((long)13209, MathEx.LCM((long)111, (long)119));
            Assert.AreEqual((long)1680, MathEx.LCM((long)112, (long)60));
            Assert.AreEqual((long)5537, MathEx.LCM((long)113, (long)49));
            Assert.AreEqual((long)228, MathEx.LCM((long)114, (long)4));
            Assert.AreEqual((long)1495, MathEx.LCM((long)115, (long)65));
            Assert.AreEqual((long)812, MathEx.LCM((long)116, (long)28));
            Assert.AreEqual((long)12870, MathEx.LCM((long)117, (long)110));
            Assert.AreEqual((long)13334, MathEx.LCM((long)118, (long)113));
            Assert.AreEqual((long)1785, MathEx.LCM((long)119, (long)15));
            Assert.AreEqual((long)3240, MathEx.LCM((long)120, (long)81));
            Assert.AreEqual((long)12947, MathEx.LCM((long)121, (long)107));
            Assert.AreEqual((long)1220, MathEx.LCM((long)122, (long)20));
            Assert.AreEqual((long)369, MathEx.LCM((long)123, (long)9));
            Assert.AreEqual((long)11284, MathEx.LCM((long)124, (long)91));
            Assert.AreEqual((long)4500, MathEx.LCM((long)125, (long)36));
            Assert.AreEqual((long)9198, MathEx.LCM((long)126, (long)146));
            Assert.AreEqual((long)2921, MathEx.LCM((long)127, (long)23));
            Assert.AreEqual((long)896, MathEx.LCM((long)128, (long)112));
            Assert.AreEqual((long)2193, MathEx.LCM((long)129, (long)17));
            Assert.AreEqual((long)1820, MathEx.LCM((long)130, (long)140));
            Assert.AreEqual((long)16375, MathEx.LCM((long)131, (long)125));
            Assert.AreEqual((long)13332, MathEx.LCM((long)132, (long)101));
            Assert.AreEqual((long)665, MathEx.LCM((long)133, (long)35));
            Assert.AreEqual((long)4556, MathEx.LCM((long)134, (long)68));
            Assert.AreEqual((long)19305, MathEx.LCM((long)135, (long)143));
            Assert.AreEqual((long)1088, MathEx.LCM((long)136, (long)64));
            Assert.AreEqual((long)7672, MathEx.LCM((long)137, (long)56));
            Assert.AreEqual((long)3036, MathEx.LCM((long)138, (long)132));
            Assert.AreEqual((long)7089, MathEx.LCM((long)139, (long)51));
            Assert.AreEqual((long)7140, MathEx.LCM((long)140, (long)102));
            Assert.AreEqual((long)11703, MathEx.LCM((long)141, (long)83));
            Assert.AreEqual((long)5822, MathEx.LCM((long)142, (long)82));
            Assert.AreEqual((long)13442, MathEx.LCM((long)143, (long)94));
            Assert.AreEqual((long)3600, MathEx.LCM((long)144, (long)100));
            Assert.AreEqual((long)1015, MathEx.LCM((long)145, (long)7));
            Assert.AreEqual((long)3942, MathEx.LCM((long)146, (long)27));
            Assert.AreEqual((long)147, MathEx.LCM((long)147, (long)21));
            Assert.AreEqual((long)3404, MathEx.LCM((long)148, (long)92));
            // ReSharper restore RedundantCast
        }

        #endregion

        #region Constants

        [TestMethod]
        public void TwoPI()
        {
            Assert.AreEqual(Math.PI * 2, MathEx.TwoPI);
        }

        [TestMethod]
        public void PIOverTwo()
        {
            Assert.AreEqual(Math.PI / 2, MathEx.PIOverTwo);
        }

        #endregion
    }
}
