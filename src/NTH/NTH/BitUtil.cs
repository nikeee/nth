
namespace NTH
{
    public class BitUtil
    {
        public static short HighWord(int dword)
        {
            return (short)(dword >> 16);
        }
        public static short LowWord(int dword)
        {
            return (short)(dword & 0x0000FFFF);
        }

        public static byte HighByte(short word)
        {
            return (byte)(word >> 8);
        }
        public static byte LowByte(short word)
        {
            return (byte)(word & 0x00FF);
        }
    }
}
