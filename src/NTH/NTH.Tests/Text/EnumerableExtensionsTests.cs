using NUnit.Framework;
using NTH.Text;
using System.Collections.Generic;
using System.Linq;

namespace NTH.Tests.Text
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void OrderByLevenshteinDistanceTo()
        {
            var l = new List<string>
            {
                "abdd",
                "abc",
                "a",
                "abd"
            };
            var expected = new List<string>
            {
                "abc",
                "abd",
                "abdd",
                "a",
            };

            var res = l.OrderByLevenshteinDistanceTo("abc").ToList();
            Assert.IsTrue(res.SequenceEqual(expected));

            res = l.OrderByLevenshteinDistanceTo("abc", LevenshteinMethod.Vector).ToList();
            Assert.IsTrue(res.SequenceEqual(expected));
        }
    }
}
