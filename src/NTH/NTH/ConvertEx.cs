using System;
using System.Diagnostics;

namespace NTH
{
    public class ConvertEx
    {
        public static byte[] FromHexString(string data)
        {
            if (data == null)
                return null;

            data = data.Trim();
            if (data.Length == 0)
                return new byte[0];

            if ((data.Length & 1) != 0)
                throw new FormatException("The length of data, ignoring white-space characters, is not zero or a multiple of 2.");

            Debug.Assert(data != null);
            Debug.Assert(data.Length % 2 != 1);

            data = data.ToUpperInvariant();

            byte[] res = new byte[data.Length >> 1];

            for (int i = 0; i < data.Length >> 1; ++i)
            {
                res[i] = (byte)((GetHexValue(data[i << 1]) << 4) + (GetHexValue(data[(i << 1) + 1])));
            }

            return res;
        }

        public static int GetHexValue(char hex)
        {
            // See: http://stackoverflow.com/a/9995303/785210
            int val = hex;
            return val - (val < 58 ? 48 : 55);
        }
    }
}
