using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTH.Tests
{
    [TestClass]
    public class SemanticVersionTests
    {

        [TestMethod]
        public void Constructor()
        {
            var actual = new SemanticVersion(1, 2, 3);

            var expectedMajor = 1;
            var expectedMinor = 2;
            var expectedPatch = 3;

            Assert.AreEqual(expectedMajor, actual.Major);
            Assert.AreEqual(expectedMinor, actual.Minor);
            Assert.AreEqual(expectedPatch, actual.Patch);
        }

        [TestMethod]
        public void Parse()
        {
            var expected = new SemanticVersion(1, 2, 3);
            var t = "1.2.3";
            var actual = SemanticVersion.Parse(t);

            Assert.AreEqual(expected.Major, actual.Major);
            Assert.AreEqual(expected.Minor, actual.Minor);
            Assert.AreEqual(expected.Patch, actual.Patch);
        }
    }
}
