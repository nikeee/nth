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
        }

        [TestMethod]
        public void LCM()
        {
            // Generated, lol

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
        }

        #endregion
    }
}
