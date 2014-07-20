using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTH.Security.Cryptography;

namespace NTH.Tests.Security.Cryptography
{
    [TestClass]
    public class Crc32Tests
    {
        [TestMethod]
        public void Compute()
        {
            const uint expected = 0x99C4571D;
            const string resource = "RSACryptoServiceProviderExtensionPublicKey.der";
            var data = Resources.GetResource(resource);

            var actual = Crc32.Compute(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Compute2()
        {
            const uint expected = 0x3E05CFC9;
            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);

            var actual = Crc32.Compute(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ComputeHash()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x3E05CFC9);
            const string resource = "5MB.bin";

            Array.Reverse(expected); // Big endian?

            var data = Resources.GetResource(resource);
            byte[] actual;

            using (var ms = new MemoryStream(data))
            {
                ms.Position = 0;
                actual = crc.ComputeHash(ms);
            }


            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ComputeHash2()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x3E05CFC9);

            Array.Reverse(expected); // Big endian?

            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);
            byte[] actual;

            using (var fs = File.OpenRead(@"..\..\Resources\" + resource))
                actual = crc.ComputeHash(fs);

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ComputeHash3()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x99C4571D);

            Array.Reverse(expected); // Big endian?

            const string resource = "RSACryptoServiceProviderExtensionPublicKey.der";
            var data = Resources.GetResource(resource);
            byte[] actual;

            using (var fs = File.OpenRead(@"..\..\Resources\" + resource))
                actual = crc.ComputeHash(fs);

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ComputeHash4()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x3E05CFC9);

            Array.Reverse(expected); // Big endian?

            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);
            byte[] actual = crc.ComputeHash(data);

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ComputeHash5()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x99C4571D);

            Array.Reverse(expected); // Big endian?

            const string resource = "RSACryptoServiceProviderExtensionPublicKey.der";
            var data = Resources.GetResource(resource);
            byte[] actual = crc.ComputeHash(data);

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
