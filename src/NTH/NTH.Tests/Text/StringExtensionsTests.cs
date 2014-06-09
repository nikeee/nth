using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTH.Text;

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

        [TestMethod]
        public void LevenshteinDistanceTo()
        {
            // Grabbed from: http://awk.freeshell.org/LevenshteinEditDistance
            int dist;

            dist = "kitten".LevenshteinDistanceTo("sitting");
            Assert.AreEqual(3, dist);

            dist = "Saturday".LevenshteinDistanceTo("Sunday");
            Assert.AreEqual(3, dist);

            dist = "acc".LevenshteinDistanceTo("ac");
            Assert.AreEqual(1, dist);

            dist = "foo".LevenshteinDistanceTo("four");
            Assert.AreEqual(2, dist);

            dist = "foo".LevenshteinDistanceTo("foo");
            Assert.AreEqual(0, dist);

            dist = "cow".LevenshteinDistanceTo("cat");
            Assert.AreEqual(2, dist);

            dist = "cat".LevenshteinDistanceTo("moocow");
            Assert.AreEqual(5, dist);

            dist = "cat".LevenshteinDistanceTo("cowmoo");
            Assert.AreEqual(5, dist);

            dist = "sebastian".LevenshteinDistanceTo("sebastien");
            Assert.AreEqual(1, dist);

            dist = "more".LevenshteinDistanceTo("cowbell");
            Assert.AreEqual(5, dist);

            dist = "freshpack".LevenshteinDistanceTo("freshpak");
            Assert.AreEqual(1, dist);

            dist = "freshpak".LevenshteinDistanceTo("freshpack");
            Assert.AreEqual(1, dist);

            LevenshteinDistanceToExplicit(LevenshteinMethod.Damerau);
            LevenshteinDistanceToExplicit(LevenshteinMethod.Default);
            LevenshteinDistanceToExplicit(LevenshteinMethod.Matrix);
            LevenshteinDistanceToExplicit(LevenshteinMethod.Recursive);
            LevenshteinDistanceToExplicit(LevenshteinMethod.Vector);
        }

        private void LevenshteinDistanceToExplicit(LevenshteinMethod method)
        {
            int dist;

            dist = "kitten".LevenshteinDistanceTo("sitting", method);
            Assert.AreEqual(3, dist);

            dist = "Saturday".LevenshteinDistanceTo("Sunday", method);
            Assert.AreEqual(3, dist);

            dist = "acc".LevenshteinDistanceTo("ac", method);
            Assert.AreEqual(1, dist);

            dist = "foo".LevenshteinDistanceTo("four", method);
            Assert.AreEqual(2, dist);

            dist = "foo".LevenshteinDistanceTo("foo", method);
            Assert.AreEqual(0, dist);

            dist = "cow".LevenshteinDistanceTo("cat", method);
            Assert.AreEqual(2, dist);

            dist = "cat".LevenshteinDistanceTo("moocow", method);
            Assert.AreEqual(5, dist);

            dist = "cat".LevenshteinDistanceTo("cowmoo", method);
            Assert.AreEqual(5, dist);

            dist = "sebastian".LevenshteinDistanceTo("sebastien", method);
            Assert.AreEqual(1, dist);

            dist = "more".LevenshteinDistanceTo("cowbell", method);
            Assert.AreEqual(5, dist);

            dist = "freshpack".LevenshteinDistanceTo("freshpak", method);
            Assert.AreEqual(1, dist);

            dist = "freshpak".LevenshteinDistanceTo("freshpack", method);
            Assert.AreEqual(1, dist);
        }
    }
}
