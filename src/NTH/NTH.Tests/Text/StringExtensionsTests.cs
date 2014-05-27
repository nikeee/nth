using System;
using NTH.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NTH.Tests.Text
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void IsNullOrEmpty()
        {
            string s = null;
            Assert.AreEqual(string.IsNullOrEmpty(s), s.IsNullOrEmpty());
            s = "";
            Assert.AreEqual(string.IsNullOrEmpty(s), s.IsNullOrEmpty());
            s = string.Empty;
            Assert.AreEqual(string.IsNullOrEmpty(s), s.IsNullOrEmpty());
            s = " ";
            Assert.AreEqual(string.IsNullOrEmpty(s), s.IsNullOrEmpty());
            s = "a";
            Assert.AreEqual(string.IsNullOrEmpty(s), s.IsNullOrEmpty());
            s = "null";
            Assert.AreEqual(string.IsNullOrEmpty(s), s.IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNullOrWhiteSpace()
        {
            string s = null;
            Assert.AreEqual(string.IsNullOrWhiteSpace(s), s.IsNullOrWhiteSpace());
            s = "";
            Assert.AreEqual(string.IsNullOrWhiteSpace(s), s.IsNullOrWhiteSpace());
            s = string.Empty;
            Assert.AreEqual(string.IsNullOrWhiteSpace(s), s.IsNullOrWhiteSpace());
            s = " ";
            Assert.AreEqual(string.IsNullOrWhiteSpace(s), s.IsNullOrWhiteSpace());
            s = "a";
            Assert.AreEqual(string.IsNullOrWhiteSpace(s), s.IsNullOrWhiteSpace());
            s = "null";
            Assert.AreEqual(string.IsNullOrWhiteSpace(s), s.IsNullOrWhiteSpace());
        }
    }
}
