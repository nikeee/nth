
namespace NTH
{
    public class BitUtil
    {
        /// <summary>Returns the higher 16 bit of an Int32 as a short value.</summary>
        /// <param name="dword">The signed Int32 value from which to extract the higher significant 16 bit.</param>
        /// <returns>The higher 16 bit of an Int32 as a short value.</returns>
        public static short HighWord(int dword) => (short)(dword >> 16);
        /// <summary>Returns the lower 16 bit of an Int32 as a short value.</summary>
        /// <param name="dword">The Int32 value from which to extract the lower significant 16 bit.</param>
        /// <returns>The lower 16 bit of an Int32 as a short value.</returns>
        public static short LowWord(int dword) => (short)(dword & 0x0000FFFF);

        /// <summary>Returns the higher 8 bit of an Int16 as a byte value.</summary>
        /// <param name="word">The Int16 value from which to extract the higher significant 8 bit.</param>
        /// <returns>The higher 8 bit of an Int16 as a byte value.</returns>
        public static byte HighByte(short word) => (byte)(word >> 8);
        /// <summary>Returns the lower 8 bit of an Int16 as a byte value.</summary>
        /// <param name="word">The Int16 value from which to extract the lower significant 8 bit.</param>
        /// <returns>The lower 8 bit of an Int16 as a byte value.</returns>
        public static byte LowByte(short word) => (byte)(word & 0x00FF);
    }
}
