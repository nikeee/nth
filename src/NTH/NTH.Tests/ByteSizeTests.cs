using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NTH.Tests
{
    [TestClass]
    public class ByteSizeTests
    {
        #region Ctor

        [TestMethod]
        public void Constructor()
        {
            var bs = new ByteSize();
            Assert.AreEqual(0, bs.ByteCount);
        }

        [TestMethod]
        public void Constructor2()
        {
            var bs = new ByteSize(10);
            Assert.AreEqual(10, bs.ByteCount);

            bs = new ByteSize(1000);
            Assert.AreEqual(1000, bs.ByteCount);

            bs = new ByteSize(1024);
            Assert.AreEqual(1024, bs.ByteCount);
        }

        [TestMethod]
        public void Constructor3Decimal()
        {
            var bs = new ByteSize(1024, BytePrefix.Bytes);
            Assert.AreEqual(1024, bs.ByteCount);

            bs = new ByteSize(0, BytePrefix.KiloByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, BytePrefix.KiloByte);
            Assert.AreEqual(1000, bs.ByteCount);

            bs = new ByteSize(2, BytePrefix.KiloByte);
            Assert.AreEqual(1000 * 2, bs.ByteCount);

            bs = new ByteSize(3, BytePrefix.KiloByte);
            Assert.AreEqual(1000 * 3, bs.ByteCount);


            bs = new ByteSize(0, BytePrefix.MegaByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, BytePrefix.MegaByte);
            Assert.AreEqual(1000 * 1000, bs.ByteCount);

            bs = new ByteSize(2, BytePrefix.MegaByte);
            Assert.AreEqual(1000 * 1000 * 2, bs.ByteCount);

            bs = new ByteSize(3, BytePrefix.MegaByte);
            Assert.AreEqual(1000 * 1000 * 3, bs.ByteCount);


            bs = new ByteSize(0, BytePrefix.GigaByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, BytePrefix.GigaByte);
            Assert.AreEqual(1000 * 1000 * 1000, bs.ByteCount);

            bs = new ByteSize(2, BytePrefix.GigaByte);
            Assert.AreEqual(1000 * 1000 * 1000 * 2, bs.ByteCount);

            bs = new ByteSize(3, BytePrefix.GigaByte);
            Assert.AreEqual(1000L * 1000L * 1000L * 3L, bs.ByteCount);
        }

        [TestMethod]
        public void Constructor3Binary()
        {
            var bs = new ByteSize(1024, BytePrefix.Bytes);
            Assert.AreEqual(1024, bs.ByteCount);

            bs = new ByteSize(0, BytePrefix.KibiByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, BytePrefix.KibiByte);
            Assert.AreEqual(1024, bs.ByteCount);

            bs = new ByteSize(2, BytePrefix.KibiByte);
            Assert.AreEqual(1024 * 2, bs.ByteCount);

            bs = new ByteSize(3, BytePrefix.KibiByte);
            Assert.AreEqual(1024 * 3, bs.ByteCount);


            bs = new ByteSize(0, BytePrefix.MibiByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, BytePrefix.MibiByte);
            Assert.AreEqual(1024 * 1024, bs.ByteCount);

            bs = new ByteSize(2, BytePrefix.MibiByte);
            Assert.AreEqual(1024 * 1024 * 2, bs.ByteCount);

            bs = new ByteSize(3, BytePrefix.MibiByte);
            Assert.AreEqual(1024 * 1024 * 3, bs.ByteCount);


            bs = new ByteSize(0, BytePrefix.GibiByte);
            Assert.AreEqual(0, bs.ByteCount);

            bs = new ByteSize(1, BytePrefix.GibiByte);
            Assert.AreEqual(1024 * 1024 * 1024, bs.ByteCount);

            bs = new ByteSize(2, BytePrefix.GibiByte);
            Assert.AreEqual(1024L * 1024L * 1024L * 2L, bs.ByteCount);

            bs = new ByteSize(3, BytePrefix.GibiByte);
            Assert.AreEqual(1024L * 1024L * 1024L * 3L, bs.ByteCount);
        }

        #endregion
        #region ToString

        [TestMethod]
        public new void ToString()
        {
            var bs = new ByteSize(1024, BytePrefix.Bytes);
            Assert.AreEqual("1 KiB", bs.ToString());

            bs = new ByteSize(0, BytePrefix.KibiByte);
            Assert.AreEqual("0 bytes", bs.ToString());

            bs = new ByteSize(1, BytePrefix.KibiByte);
            Assert.AreEqual("1 KiB", bs.ToString());

            bs = new ByteSize(2, BytePrefix.KibiByte);
            Assert.AreEqual("2 KiB", bs.ToString());

            bs = new ByteSize(3, BytePrefix.KibiByte);
            Assert.AreEqual("3 KiB", bs.ToString());


            bs = new ByteSize(0, BytePrefix.MibiByte);
            Assert.AreEqual("0 bytes", bs.ToString());

            bs = new ByteSize(1, BytePrefix.MibiByte);
            Assert.AreEqual("1 MiB", bs.ToString());

            bs = new ByteSize(2, BytePrefix.MibiByte);
            Assert.AreEqual("2 MiB", bs.ToString());

            bs = new ByteSize(3, BytePrefix.MibiByte);
            Assert.AreEqual("3 MiB", bs.ToString());


            bs = new ByteSize(0, BytePrefix.GibiByte);
            Assert.AreEqual("0 bytes", bs.ToString());

            bs = new ByteSize(1, BytePrefix.GibiByte);
            Assert.AreEqual("1 GiB", bs.ToString());

            bs = new ByteSize(2, BytePrefix.GibiByte);
            Assert.AreEqual("2 GiB", bs.ToString());

            bs = new ByteSize(3, BytePrefix.GibiByte);
            Assert.AreEqual("3 GiB", bs.ToString());
        }

        #endregion
    }
}
