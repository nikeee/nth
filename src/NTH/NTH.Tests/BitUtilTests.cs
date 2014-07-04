using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NTH.Tests
{
    [TestClass]
    public class BitUtilTests
    {
        [TestMethod]
        public void HiWord()
        {
            const int value = 0x12345678;
            const short expectedValue = 0x1234;

            int expected = value >> 16; // high = 0x1234
            int actual = BitUtil.HighWord(value);

            Assert.AreEqual(expected, expectedValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoWord()
        {
            const int value = 0x12345678;
            const short expectedValue = 0x5678;

            int expected = value & 0xFFFF; // low = 0x5678
            int actual = BitUtil.LowWord(value);

            Assert.AreEqual(expected, expectedValue);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void LoByte()
        {
            const short value = 0x1234;
            const byte expectedValue = 0x34;

            int expected = value & 0xFF; // low = 0x34
            int actual = BitUtil.LowByte(value);

            Assert.AreEqual(expected, expectedValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HiByte()
        {
            const short value = 0x1234;
            const byte expectedValue = 0x12;

            int expected = value >> 8; // low = 0x12
            int actual = BitUtil.HighByte(value);

            Assert.AreEqual(expected, expectedValue);
            Assert.AreEqual(expected, actual);
        }
    }
}
