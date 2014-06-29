﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void Comparison()
        {
            // From: https://github.com/mojombo/semver/blob/master/semver.md
            // "Example: 1.0.0-alpha < 1.0.0-alpha.1 < 1.0.0-alpha.beta < 1.0.0-beta < 1.0.0-beta.2 < 1.0.0-beta.11 < 1.0.0-rc.1 < 1.0.0."

            var alpha = SemanticVersion.Parse("1.0.0-alpha");
            var alpha1 = SemanticVersion.Parse("1.0.0-alpha.1");
            Assert.IsTrue(alpha < alpha1);

            var alphabeta = SemanticVersion.Parse("1.0.0-alpha.beta");
            Assert.IsTrue(alpha1 < alphabeta);

            var beta = SemanticVersion.Parse("1.0.0-beta");
            Assert.IsTrue(alphabeta < beta);

            var beta2 = SemanticVersion.Parse("1.0.0-beta.2");
            Assert.IsTrue(beta < beta2);

            var beta11 = SemanticVersion.Parse("1.0.0-beta.11");
            Assert.IsTrue(beta2 < beta11);

            var rc1 = SemanticVersion.Parse("1.0.0-rc.1");
            Assert.IsTrue(beta11 < rc1);

            var final = SemanticVersion.Parse("1.0.0");
            Assert.IsTrue(rc1 < final);
        }
    }
}
