using NUnit.Framework;

namespace NTH.Tests
{
    [TestFixture]
    public class ByteSizeTests
    {
        #region Ctor

        [Test]
        public void Constructor()
        {
            var bs = new ByteSize();
            Assert.AreEqual(0, bs.ByteCount);
        }

        [Test]
        public void Constructor2()
        {
            var bs = new ByteSize(10);
            Assert.AreEqual(10, bs.ByteCount);

            bs = new ByteSize(1000);
            Assert.AreEqual(1000, bs.ByteCount);

            bs = new ByteSize(1024);
            Assert.AreEqual(1024, bs.ByteCount);
        }

        [Test]
        public void Constructor3Decimal()
        {
            var bs = new ByteSize(1024, ByteSizeUnit.Bytes);
            Assert.AreEqual(1024, bs.ByteCount);

            bs = new ByteSize(0, ByteSizeUnit.KiloByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, ByteSizeUnit.KiloByte);
            Assert.AreEqual(1000, bs.ByteCount);

            bs = new ByteSize(2, ByteSizeUnit.KiloByte);
            Assert.AreEqual(1000 * 2, bs.ByteCount);

            bs = new ByteSize(3, ByteSizeUnit.KiloByte);
            Assert.AreEqual(1000 * 3, bs.ByteCount);


            bs = new ByteSize(0, ByteSizeUnit.MegaByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, ByteSizeUnit.MegaByte);
            Assert.AreEqual(1000 * 1000, bs.ByteCount);

            bs = new ByteSize(2, ByteSizeUnit.MegaByte);
            Assert.AreEqual(1000 * 1000 * 2, bs.ByteCount);

            bs = new ByteSize(3, ByteSizeUnit.MegaByte);
            Assert.AreEqual(1000 * 1000 * 3, bs.ByteCount);


            bs = new ByteSize(0, ByteSizeUnit.GigaByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, ByteSizeUnit.GigaByte);
            Assert.AreEqual(1000 * 1000 * 1000, bs.ByteCount);

            bs = new ByteSize(2, ByteSizeUnit.GigaByte);
            Assert.AreEqual(1000 * 1000 * 1000 * 2, bs.ByteCount);

            bs = new ByteSize(3, ByteSizeUnit.GigaByte);
            Assert.AreEqual(1000L * 1000L * 1000L * 3L, bs.ByteCount);
        }

        [Test]
        public void Constructor3Binary()
        {
            var bs = new ByteSize(1024, ByteSizeUnit.Bytes);
            Assert.AreEqual(1024, bs.ByteCount);

            bs = new ByteSize(0, ByteSizeUnit.KibiByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, ByteSizeUnit.KibiByte);
            Assert.AreEqual(1024, bs.ByteCount);

            bs = new ByteSize(2, ByteSizeUnit.KibiByte);
            Assert.AreEqual(1024 * 2, bs.ByteCount);

            bs = new ByteSize(3, ByteSizeUnit.KibiByte);
            Assert.AreEqual(1024 * 3, bs.ByteCount);


            bs = new ByteSize(0, ByteSizeUnit.MibiByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, ByteSizeUnit.MibiByte);
            Assert.AreEqual(1024 * 1024, bs.ByteCount);

            bs = new ByteSize(2, ByteSizeUnit.MibiByte);
            Assert.AreEqual(1024 * 1024 * 2, bs.ByteCount);

            bs = new ByteSize(3, ByteSizeUnit.MibiByte);
            Assert.AreEqual(1024 * 1024 * 3, bs.ByteCount);


            bs = new ByteSize(0, ByteSizeUnit.GibiByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, ByteSizeUnit.GibiByte);
            Assert.AreEqual(1024 * 1024 * 1024, bs.ByteCount);

            bs = new ByteSize(2, ByteSizeUnit.GibiByte);
            Assert.AreEqual(1024L * 1024L * 1024L * 2L, bs.ByteCount);

            bs = new ByteSize(3, ByteSizeUnit.GibiByte);
            Assert.AreEqual(1024L * 1024L * 1024L * 3L, bs.ByteCount);
        }

        #endregion
        #region ToString

        [Test]
        public new void ToString()
        {
            var bs = new ByteSize(1024, ByteSizeUnit.Bytes);
            Assert.AreEqual("1 KiB", bs.ToString());

            bs = new ByteSize(0, ByteSizeUnit.KibiByte);
            Assert.AreEqual("0 bytes", bs.ToString());

            bs = new ByteSize(1, ByteSizeUnit.KibiByte);
            Assert.AreEqual("1 KiB", bs.ToString());

            bs = new ByteSize(2, ByteSizeUnit.KibiByte);
            Assert.AreEqual("2 KiB", bs.ToString());

            bs = new ByteSize(3, ByteSizeUnit.KibiByte);
            Assert.AreEqual("3 KiB", bs.ToString());


            bs = new ByteSize(0, ByteSizeUnit.MibiByte);
            Assert.AreEqual("0 bytes", bs.ToString());

            bs = new ByteSize(1, ByteSizeUnit.MibiByte);
            Assert.AreEqual("1 MiB", bs.ToString());

            bs = new ByteSize(2, ByteSizeUnit.MibiByte);
            Assert.AreEqual("2 MiB", bs.ToString());

            bs = new ByteSize(3, ByteSizeUnit.MibiByte);
            Assert.AreEqual("3 MiB", bs.ToString());


            bs = new ByteSize(0, ByteSizeUnit.GibiByte);
            Assert.AreEqual("0 bytes", bs.ToString());

            bs = new ByteSize(1, ByteSizeUnit.GibiByte);
            Assert.AreEqual("1 GiB", bs.ToString());

            bs = new ByteSize(2, ByteSizeUnit.GibiByte);
            Assert.AreEqual("2 GiB", bs.ToString());

            bs = new ByteSize(3, ByteSizeUnit.GibiByte);
            Assert.AreEqual("3 GiB", bs.ToString());
        }

        #endregion
        #region Operators

        [Test]
        public void OperatorAdd()
        {
            var bs1 = new ByteSize();
            var bs2 = new ByteSize();
            var expected = new ByteSize();
            var actual = bs1 + bs2;

            Assert.AreEqual(expected.ToString(), actual.ToString());

            bs1 = new ByteSize(1);
            bs2 = new ByteSize(2);
            expected = new ByteSize(3);
            actual = bs1 + bs2;
            Assert.AreEqual(expected.ToString(), actual.ToString());


            bs1 = new ByteSize(1024);
            bs2 = new ByteSize(2);
            expected = new ByteSize(1026);
            actual = bs1 + bs2;
            Assert.AreEqual(expected.ToString(), actual.ToString());

            bs1 = new ByteSize(1, ByteSizeUnit.KibiByte);
            bs2 = new ByteSize(2);
            expected = new ByteSize(1026);
            actual = bs1 + bs2;
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [Test]
        public void OperatorSubtract()
        {
            var bs1 = new ByteSize();
            var bs2 = new ByteSize();
            var expected = new ByteSize();
            var actual = bs1 - bs2;

            Assert.AreEqual(expected.ToString(), actual.ToString());

            bs1 = new ByteSize(2);
            bs2 = new ByteSize(1);
            expected = new ByteSize(1);
            actual = bs1 - bs2;
            Assert.AreEqual(expected.ToString(), actual.ToString());


            bs1 = new ByteSize(1024);
            bs2 = new ByteSize(2);
            expected = new ByteSize(1022);
            actual = bs1 - bs2;
            Assert.AreEqual(expected.ToString(), actual.ToString());

            bs1 = new ByteSize(1, ByteSizeUnit.KibiByte);
            bs2 = new ByteSize(2);
            expected = new ByteSize(1022);
            actual = bs1 - bs2;
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        #endregion
    }
}
