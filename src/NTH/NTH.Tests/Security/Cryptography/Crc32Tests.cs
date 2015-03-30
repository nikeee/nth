using System;
using System.IO;
using NTH.Security.Cryptography;
using NUnit.Framework;

namespace NTH.Tests.Security.Cryptography
{
    [TestFixture]
    public class Crc32Tests
    {
        [Test]
        public void Compute()
        {
            const uint expected = 0x99C4571D;
            const string resource = "RSACryptoServiceProviderExtensionPublicKey.der";
            var data = Resources.GetResource(resource);

            var actual = Crc32.Compute(data);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compute2()
        {
            const uint expected = 0x80961D89; // Computed by 7-zip
            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);

            var actual = Crc32.Compute(data);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ComputeHash()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x80961D89); // Computed by 7-zip
            const string resource = "5MB.bin";

            Array.Reverse(expected); // Big endian?

            var data = Resources.GetResource(resource);
            byte[] actual;

            using (var ms = new MemoryStream(data))
            {
                ms.Position = 0;
                actual = crc.ComputeHash(ms);
            }

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);

            Assert.That(actual.Length, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void ComputeHash2()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x80961D89); // Computed by 7-zip

            Array.Reverse(expected); // Big endian?

            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);
            byte[] actual;

            using (var fs = File.OpenRead(@"..\..\Resources\" + resource))
                actual = crc.ComputeHash(fs);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);

            Assert.That(actual.Length, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
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

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);

            Assert.That(actual.Length, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void ComputeHash4()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x80961D89); // Computed by 7-zip

            Array.Reverse(expected); // Big endian?

            const string resource = "5MB.bin";
            var data = Resources.GetResource(resource);
            byte[] actual = crc.ComputeHash(data);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);

            Assert.That(actual.Length, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void ComputeHash5()
        {
            var crc = new Crc32();
            var expected = BitConverter.GetBytes(0x99C4571D);

            Array.Reverse(expected); // Big endian?

            const string resource = "RSACryptoServiceProviderExtensionPublicKey.der";
            var data = Resources.GetResource(resource);
            byte[] actual = crc.ComputeHash(data);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);

            Assert.That(actual.Length, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EquivalentTo(expected));
        }
    }
}
