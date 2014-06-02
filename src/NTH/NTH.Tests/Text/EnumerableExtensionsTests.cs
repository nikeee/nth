using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTH.Text;

namespace NTH.Tests.Text
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        [TestMethod]
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
