
namespace NTH
{
    public class BitUtil
    {
        public static short HiWord(int dword)
        {
            return (short)(dword >> 16);
        }
        public static short LoWord(int dword)
        {
            return (short)(dword & 0x0000FFFF);
        }

        public static byte HiByte(short word)
        {
            return (byte)(word >> 8);
        }
        public static byte LoByte(short word)
        {
            return (byte)(word & 0x00FF);
        }
    }
}
