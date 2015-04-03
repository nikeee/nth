using System;
using System.Diagnostics;

namespace NTH
{
    public class BitConverterEx
    {
        public static string ToHexString(byte[] value)
        {
            if (value == null)
                return null;
            var len = value.Length * 2;
            var chars = new char[len];
            for (int i = 0, index = 0; i < len; i += 2)
            {
                var currentByte = value[index++];
                chars[i] = GetHexCharForInt(currentByte / 0x10);
                chars[i + 1] = GetHexCharForInt(currentByte % 0x10);
            }
            return new string(chars, 0, len);
        }

        public static byte[] FromHexString(string value)
        {
            if (value == null)
                return null;

            value = value.Trim();
            if (value.Length == 0)
                return new byte[0];

            if ((value.Length & 1) != 0)
                throw new FormatException("The length of data, ignoring white-space characters, is not zero or a multiple of 2.");

            Debug.Assert(value != null);
            Debug.Assert(value.Length % 2 != 1);

            value = value.ToUpperInvariant();

            byte[] res = new byte[value.Length >> 1];

            for (int i = 0; i < value.Length >> 1; ++i)
            {
                res[i] = (byte)((GetIntForHexChar(value[i << 1]) << 4) + (GetIntForHexChar(value[(i << 1) + 1])));
            }

            return res;
        }

        private static int GetIntForHexChar(char hex)
        {
            // See: http://stackoverflow.com/a/9995303/785210
            return hex - (hex < 58 ? 48 : 55);
        }

        private static char GetHexCharForInt(int i)
        {
            Debug.Assert(i >= 0 && i < 16, "i is out of range.");
            if (i < 10)
                return (char)(i + '0');
            return (char)(i - 10 + 'A');
        }
    }
}
