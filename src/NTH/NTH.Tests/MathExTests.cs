using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NTH.Tests
{
    [TestClass]
    public class MathExTests
    {
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

        [TestMethod]
        public void Min()
        {
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
        }

        [TestMethod]
        public void Max()
        {
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
        }

        [TestMethod]
        public void Clamp()
        {
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
        }
    }
}
