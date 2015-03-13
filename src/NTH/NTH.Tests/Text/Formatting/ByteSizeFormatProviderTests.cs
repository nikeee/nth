using System;
using NUnit.Framework;
using NTH.Text.Formatting;

namespace NTH.Tests.Text.Formatting
{
    [TestFixture]
    public class ByteSizeFormatProviderTests
    {
        [Test]
        public void Format()
        {
            long fileSize = 1337;
            var expected = ByteSizeFormatter.FormatBytes(fileSize);
            var actual = string.Format(new ByteSizeFormatProvider(), "{0}", fileSize);
            Assert.AreEqual(expected, actual);

        }
    }
}
