using NTH.Text;
using NUnit.Framework;
using System;

namespace NTH.Tests.Text
{
    [TestFixture]
    public class StringExtensionsTests
    {
        #region is-something

        public void IsNewLine()
        {
            Assert.IsFalse("".IsNewLine());
            Assert.IsFalse("\t".IsNewLine());
            Assert.IsFalse(" ".IsNewLine());
            Assert.IsTrue("\n".IsNewLine());
            Assert.IsTrue("\r".IsNewLine());
            Assert.IsTrue("\r\n".IsNewLine());
            Assert.IsFalse("\n\r".IsNewLine());
        }

        #endregion
        #region levenshtein

        [Test]
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

        [Test]
        public void LevenshteinDistanceToExceptions()
        {
            TestHelper.AssertException<ArgumentException>(() => "nope".LevenshteinDistanceTo("nope2", (LevenshteinMethod)900));
        }

        #endregion
        #region StripWhiteSpace

        [Test]
        public void StripWhiteSpace()
        {
            const string input = " this is\n some text containing white space       \t ";
            var actual = input.StripWhiteSpace();
            const string expected = "thisissometextcontainingwhitespace";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StripWhiteSpace2()
        {
            const string input = null;
            Assert.AreEqual(null, input.StripWhiteSpace());
        }

        [Test]
        public void StripWhiteSpace3()
        {
            const string input = "";
            Assert.AreEqual(string.Empty, input.StripWhiteSpace());
        }

        [Test]
        public void StripWhiteSpace4()
        {
            const string input = "\n";
            Assert.AreEqual(string.Empty, input.StripWhiteSpace());
        }

        #endregion
        #region contains

        [Test]
        public void Contains()
        {
            const string input = "hAll0";
            const string input2 = "hall0";
            Assert.IsTrue(input.Contains(input2, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        #region ensure-something

        [Test]
        public void EnsureQuotes()
        {
            const string expected = "\"some string\"";
            string input = "\"some string";
            var actual = input.EnsureQuotes();
            Assert.AreEqual(expected, actual);

            input = "some string";
            actual = input.EnsureQuotes();
            Assert.AreEqual(expected, actual);

            input = "\"some string\"";
            actual = input.EnsureQuotes();
            Assert.AreEqual(expected, actual);

            input = "\"some string\"";
            actual = input.EnsureQuotes();
            Assert.AreEqual(expected, actual);

            input = "some string\"";
            actual = input.EnsureQuotes();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnsureWrappingStrings()
        {
            const string expected = "\"some string'";
            string input = "\"some string";
            var actual = input.EnsureWrappingStrings("\"", "'");
            Assert.AreEqual(expected, actual);

            input = "some string";
            actual = input.EnsureWrappingStrings("\"", "'");
            Assert.AreEqual(expected, actual);

            input = "\"some string";
            actual = input.EnsureWrappingStrings("\"", "'");
            Assert.AreEqual(expected, actual);

            input = "some string'";
            actual = input.EnsureWrappingStrings("\"", "'");
            Assert.AreEqual(expected, actual);

            input = "\"some string'";
            actual = input.EnsureWrappingStrings("\"", "'");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnsureSuffix()
        {
            const string expected = "some stringlol";
            var input = "some string";
            var actual = input.EnsureSuffix("lol");
            Assert.AreEqual(expected, actual);

            input = "some stringlol";
            actual = input.EnsureSuffix("lol");
            Assert.AreEqual(expected, actual);

            Assert.AreEqual("lol", string.Empty.EnsureSuffix("lol"));
            Assert.AreEqual("lol", ((string)null).EnsureSuffix("lol")); // type safe null. ;)
        }

        [Test]
        public void EnsurePrefix()
        {
            const string expected = "lolsome string";
            var input = "some string";
            var actual = input.EnsurePrefix("lol");
            Assert.AreEqual(expected, actual);

            input = "lolsome string";
            actual = input.EnsurePrefix("lol");
            Assert.AreEqual(expected, actual);

            Assert.AreEqual("lol", string.Empty.EnsurePrefix("lol"));
            Assert.AreEqual("lol", ((string)null).EnsurePrefix("lol")); // type safe null. ;)
        }

        #endregion

        #region normalize

        [Test]
        public void NormalizeLines()
        {
            var nl = Environment.NewLine;
            var data = "a\r\nc\nd";
            var expected = string.Format("a{0}c{0}d", nl);
            var actual = data.NormalizeNewLines(nl);
            Assert.AreEqual(expected, actual);

            data = "a\rb\rc";
            expected = string.Format("a{0}b{0}c", nl);
            actual = data.NormalizeNewLines(nl);
            Assert.AreEqual(expected, actual);

            data = "a\nb\r";
            expected = string.Format("a{0}b{0}", nl);
            actual = data.NormalizeNewLines(nl);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
