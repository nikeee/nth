using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTH.Text.Formatting;

namespace NTH.Tests.Text.Formatting
{
    [TestClass]
    public class ByteSizeFormatProviderTests
    {
        [TestMethod]
        public void Format()
        {
            long fileSize = 1337;
            var expected = ByteSizeFormatter.FormatBytes(fileSize);
            var actual = string.Format(new ByteSizeFormatProvider(), "{0}", fileSize);
            Assert.AreEqual(expected, actual);

        }
    }
}
