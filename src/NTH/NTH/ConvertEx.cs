using System;
using System.Diagnostics;

namespace NTH
{
    public class ConvertEx
    {
        public static string ToHexString(byte[] value)
        {
            return BitConverter.ToString(value).Replace("-", "");
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
                res[i] = (byte)((GetHexValue(value[i << 1]) << 4) + (GetHexValue(value[(i << 1) + 1])));
            }

            return res;
        }

        private static int GetHexValue(char hex)
        {
            // See: http://stackoverflow.com/a/9995303/785210
            return hex - (hex < 58 ? 48 : 55);
        }
    }
}
