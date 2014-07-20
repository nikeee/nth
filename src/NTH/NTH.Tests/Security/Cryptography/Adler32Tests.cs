using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTH.Security.Cryptography;

namespace NTH.Tests.Security.Cryptography
{
    [TestClass]
    public class Adler32Tests
    {
        [TestMethod]
        public void Compute()
        {
            const uint expected = 0xF3B3481F;
            const string resource = "RSACryptoServiceProviderExtensionPublicKey.der";
            var data = Resources.GetResource(resource);

            var actual = Adler32.Compute(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Compute2()
        {
            const uint expected = 0x22D5A89A;
            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);

            var actual = Adler32.Compute(data);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ComputeHash()
        {
            var adler = new Adler32();
            var expected = BitConverter.GetBytes(0x22D5A89A);
            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);
            byte[] actual;

            using (var ms = new MemoryStream(data))
            {
                ms.Position = 0;
                actual = adler.ComputeHash(ms);
            }


            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ComputeHash2()
        {
            var adler = new Adler32();
            var expected = BitConverter.GetBytes(0x22D5A89A);
            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);
            byte[] actual;

            using (var fs = File.OpenRead(@"..\..\Resources\" + resource))
                actual = adler.ComputeHash(fs);

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ComputeHash3()
        {
            var adler = new Adler32();
            var expected = BitConverter.GetBytes(0xF3B3481F);
            const string resource = "RSACryptoServiceProviderExtensionPublicKey.der";
            var data = Resources.GetResource(resource);
            byte[] actual;

            using (var fs = File.OpenRead(@"..\..\Resources\" + resource))
                actual = adler.ComputeHash(fs);

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ComputeHash4()
        {
            var adler = new Adler32();
            var expected = BitConverter.GetBytes(0x22D5A89A);
            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);
            byte[] actual = adler.ComputeHash(data);

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void ComputeHash5()
        {
            var adler = new Adler32();
            var expected = BitConverter.GetBytes(0xF3B3481F);
            const string resource = "RSACryptoServiceProviderExtensionPublicKey.der";
            var data = Resources.GetResource(resource);
            byte[] actual = adler.ComputeHash(data);

            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; ++i)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
