using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            var actual = fileSize.ToString(new ByteSizeFormatProvider());
            Assert.AreEqual(expected, actual);

        }
    }
}
