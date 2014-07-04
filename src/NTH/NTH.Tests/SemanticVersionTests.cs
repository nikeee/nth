using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        public void ToStringTests()
        {
            var expected = "1.2.3";
            var actual = SemanticVersion.Parse(expected);
            Assert.AreEqual(expected, actual.ToString());

            expected = "1.2.4";
            actual = SemanticVersion.Parse(expected);
            Assert.AreEqual(expected, actual.ToString());

            expected = "1.2.4";
            actual = SemanticVersion.Parse(expected);
            Assert.AreEqual(expected, actual.ToString());

            expected = "1.2.4-ap";
            actual = SemanticVersion.Parse(expected);
            Assert.AreEqual(expected, actual.ToString());

            expected = "1.2.4-ap+aa";
            actual = SemanticVersion.Parse(expected);
            Assert.AreEqual(expected, actual.ToString());

            expected = "1.2.4-ap.1+asdas.2";
            actual = SemanticVersion.Parse(expected);
            Assert.AreEqual(expected, actual.ToString());
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

            var actualReleases = new List<PreReleaseIdentifier> { new PreReleaseIdentifier("alpha") };
            expected = new SemanticVersion(1, 2, 3, actualReleases, null);
            t = "1.2.3-alpha";
            actual = SemanticVersion.Parse(t);

            Assert.AreEqual(expected.Major, actual.Major);
            Assert.AreEqual(expected.Minor, actual.Minor);
            Assert.AreEqual(expected.Patch, actual.Patch);
            Assert.AreEqual(actualReleases.Count, actual.PreReleaseIdentifier.Count);
            Assert.AreEqual(expected.PreReleaseIdentifier[0].Value, actual.PreReleaseIdentifier[0].Value);


            actualReleases = new List<PreReleaseIdentifier> { new PreReleaseIdentifier("4") };
            expected = new SemanticVersion(1, 2, 3, actualReleases, null);
            t = "1.2.3-4";
            actual = SemanticVersion.Parse(t);

            Assert.AreEqual(expected.Major, actual.Major);
            Assert.AreEqual(expected.Minor, actual.Minor);
            Assert.AreEqual(expected.Patch, actual.Patch);
            Assert.AreEqual(actualReleases.Count, actual.PreReleaseIdentifier.Count);
            Assert.AreEqual(expected.PreReleaseIdentifier[0].Value, actual.PreReleaseIdentifier[0].Value);
        }

        [TestMethod]
        public void Comparison1()
        {
            var t1 = SemanticVersion.Parse("1.0.0");
            var t2 = SemanticVersion.Parse("2.0.0");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("1.0.0");
            t2 = SemanticVersion.Parse("1.1.0");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("1.0.0");
            t2 = SemanticVersion.Parse("1.0.1");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("1.0.0");
            t2 = SemanticVersion.Parse("1.1.0");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("1.0.0");
            t2 = SemanticVersion.Parse("1.1.1");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("1.1.0");
            t2 = SemanticVersion.Parse("1.1.1");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("1.0.1");
            t2 = SemanticVersion.Parse("1.1.1");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("1.0.1");
            t2 = SemanticVersion.Parse("1.0.10");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("1.0.0");
            t2 = SemanticVersion.Parse("2.0.0");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("2.0.0");
            t2 = SemanticVersion.Parse("2.1.0");
            Assert.IsTrue(t1 < t2);

            t1 = SemanticVersion.Parse("2.1.0");
            t2 = SemanticVersion.Parse("2.1.1");
            Assert.IsTrue(t1 < t2);
        }

        [TestMethod]
        public void Comparison2()
        {
            // From: https://github.com/mojombo/semver/blob/master/semver.md
            // "Example: 1.0.0-alpha < 1.0.0-alpha.1 < 1.0.0-alpha.beta < 1.0.0-beta < 1.0.0-beta.2 < 1.0.0-beta.11 < 1.0.0-rc.1 < 1.0.0."

            var t1 = SemanticVersion.Parse("1.0.0-1");
            var t2 = SemanticVersion.Parse("1.0.0-2");
            Assert.IsTrue(t1 < t2);

            var alpha = SemanticVersion.Parse("1.0.0-alpha");
            var alpha1 = SemanticVersion.Parse("1.0.0-alpha.1");
            Assert.IsTrue(alpha < alpha1, "alpha < alpha1");

            var alphabeta = SemanticVersion.Parse("1.0.0-alpha.beta");
            Assert.IsTrue(alpha1 < alphabeta, "alpha1 < alphabeta");

            var beta = SemanticVersion.Parse("1.0.0-beta");
            Assert.IsTrue(alphabeta < beta, "alphabeta < beta");

            var beta2 = SemanticVersion.Parse("1.0.0-beta.2");
            Assert.IsTrue(beta < beta2, "beta < beta2");

            var beta11 = SemanticVersion.Parse("1.0.0-beta.11");
            Assert.IsTrue(beta2 < beta11, "beta2 < beta11");

            var rc1 = SemanticVersion.Parse("1.0.0-rc.1");
            Assert.IsTrue(beta11 < rc1, "beta11 < rc1");

            var final = SemanticVersion.Parse("1.0.0");
            Assert.IsTrue(rc1 < final, "rc1 < final");
        }

        [TestMethod]
        public void Comparison3()
        {
            // From: https://github.com/mojombo/semver/blob/master/semver.md
            // "Example: 1.0.0-alpha < 1.0.0-alpha.1 < 1.0.0-alpha.beta < 1.0.0-beta < 1.0.0-beta.2 < 1.0.0-beta.11 < 1.0.0-rc.1 < 1.0.0."

            var t1 = SemanticVersion.Parse("1.0.0-1");
            var t2 = SemanticVersion.Parse("1.0.0-2");
            Assert.IsTrue(t2 > t1);

            var alpha = SemanticVersion.Parse("1.0.0-alpha");
            var alpha1 = SemanticVersion.Parse("1.0.0-alpha.1");
            Assert.IsTrue(alpha1 > alpha, "alpha1 > alpha");

            var alphabeta = SemanticVersion.Parse("1.0.0-alpha.beta");
            Assert.IsTrue(alphabeta > alpha1, "alpha1 < alphabeta");

            var beta = SemanticVersion.Parse("1.0.0-beta");
            Assert.IsTrue(beta > alphabeta, "beta > alphabeta");

            var beta2 = SemanticVersion.Parse("1.0.0-beta.2");
            Assert.IsTrue(beta2 > beta, "beta2 > beta");

            var beta11 = SemanticVersion.Parse("1.0.0-beta.11");
            Assert.IsTrue(beta11 > beta2, "beta11 > beta2");

            var rc1 = SemanticVersion.Parse("1.0.0-rc.1");
            Assert.IsTrue(rc1 > beta11, "rc1 > beta11");

            var final = SemanticVersion.Parse("1.0.0");
            Assert.IsTrue(final > rc1, "final > rc1");
        }

        [TestMethod]
        public void Comparison4()
        {
            var t1 = SemanticVersion.Parse("1.0.0-1");
            var t2 = SemanticVersion.Parse("1.0.0-2");
            const int expected = -1;

            Assert.AreEqual(expected, t1.CompareTo(t2));

            var alpha = SemanticVersion.Parse("1.0.0-alpha");
            var alpha1 = SemanticVersion.Parse("1.0.0-alpha.1");
            Assert.AreEqual(expected, alpha.CompareTo(alpha1));

            var alphabeta = SemanticVersion.Parse("1.0.0-alpha.beta");
            Assert.AreEqual(expected, alpha1.CompareTo(alphabeta));

            var beta = SemanticVersion.Parse("1.0.0-beta");
            Assert.AreEqual(expected, alphabeta.CompareTo(beta));

            var beta2 = SemanticVersion.Parse("1.0.0-beta.2");
            Assert.AreEqual(expected, beta.CompareTo(beta2));

            var beta11 = SemanticVersion.Parse("1.0.0-beta.11");
            Assert.AreEqual(expected, beta2.CompareTo(beta11));

            var rc1 = SemanticVersion.Parse("1.0.0-rc.1");
            Assert.AreEqual(expected, beta11.CompareTo(rc1));

            var final = SemanticVersion.Parse("1.0.0");
            Assert.AreEqual(expected, rc1.CompareTo(final));
        }

        [TestMethod]
        public void Comparison5()
        {
            var t1 = SemanticVersion.Parse("1.0.0-1");
            var t2 = SemanticVersion.Parse("1.0.0-2");
            const int expected = 1;

            Assert.AreEqual(expected, t2.CompareTo(t1));

            var alpha = SemanticVersion.Parse("1.0.0-alpha");
            var alpha1 = SemanticVersion.Parse("1.0.0-alpha.1");
            Assert.AreEqual(expected, alpha1.CompareTo(alpha));

            var alphabeta = SemanticVersion.Parse("1.0.0-alpha.beta");
            Assert.AreEqual(expected, alphabeta.CompareTo(alpha1));

            var beta = SemanticVersion.Parse("1.0.0-beta");
            Assert.AreEqual(expected, beta.CompareTo(alphabeta));

            var beta2 = SemanticVersion.Parse("1.0.0-beta.2");
            Assert.AreEqual(expected, beta2.CompareTo(beta));

            var beta11 = SemanticVersion.Parse("1.0.0-beta.11");
            Assert.AreEqual(expected, beta11.CompareTo(beta2));

            var rc1 = SemanticVersion.Parse("1.0.0-rc.1");
            Assert.AreEqual(expected, rc1.CompareTo(beta11));

            var final = SemanticVersion.Parse("1.0.0");
            Assert.AreEqual(expected, final.CompareTo(rc1));
        }

        [TestMethod]
        public void Comparison6()
        {
            var t1 = SemanticVersion.Parse("1.0.0-1");
            var t2 = SemanticVersion.Parse("1.0.0-1");
            const int expected = 0;

            Assert.AreEqual(expected, t2.CompareTo(t1));

            var alpha = SemanticVersion.Parse("1.0.0-alpha.1");
            var alpha2 = SemanticVersion.Parse("1.0.0-alpha.1");
            Assert.AreEqual(expected, alpha.CompareTo(alpha2));

            var alphabeta = SemanticVersion.Parse("1.0.0-alpha.beta");
            var alphabeta2 = SemanticVersion.Parse("1.0.0-alpha.beta");
            Assert.AreEqual(expected, alphabeta.CompareTo(alphabeta2));
        }

        [TestMethod]
        public void Serializable()
        {
            const bool expected = true;

            bool actual = TestHelper.IsSerializable(new SemanticVersion(1, 2, 3));
            Assert.AreEqual(expected, actual);

            actual = TestHelper.IsSerializable(new SemanticVersion(1, 2, 3, null));
            Assert.AreEqual(expected, actual);

            actual = TestHelper.IsSerializable(new SemanticVersion(1, 2, 3, null, null));
            Assert.AreEqual(expected, actual);

            actual = TestHelper.IsSerializable(new SemanticVersion(1, 2, 3, null, new List<BuildMetadata>()));
            Assert.AreEqual(expected, actual);

            actual = TestHelper.IsSerializable(new SemanticVersion(1, 2, 3, new List<PreReleaseIdentifier>(), new List<BuildMetadata>()));
            Assert.AreEqual(expected, actual);

            actual = TestHelper.IsSerializable(new SemanticVersion(1, 2, 3, new List<PreReleaseIdentifier>(), null));
            Assert.AreEqual(expected, actual);

            actual = TestHelper.IsSerializable(SemanticVersion.Parse("1.2.3-pre.1+build.id.12"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerializableAttribute()
        {
            TestHelper.HasAttribute<SemanticVersion, SerializableAttribute>();
        }
    }
}
