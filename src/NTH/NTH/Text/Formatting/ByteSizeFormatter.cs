using System;
using System.Text;

namespace NTH.Text.Formatting
{
    public static class ByteSizeFormatter
    {
        public static string FormatBytes(long byteCount)
        {
            return FormatBytes(byteCount, false);
        }

        public static string FormatBytes(long byteCount, bool useBinaryPrefix)
        {
            var win = WindowsInternal(byteCount);
            if (useBinaryPrefix)
                FixDecimalPrefix(ref win);
            return win;
        }

        private static void FixDecimalPrefix(ref string str)
        {
            str = str
                .Replace("KB", "KiB")
                .Replace("MB", "MiB")
                .Replace("GB", "GiB")
                .Replace("TB", "TiB")
                .Replace("PB", "PiB")
                .Replace("EB", "EiB");
        }

        private static string WindowsInternal(long byteCount)
        {
            var buffer = new StringBuilder(20);
            NativeMethods.StrFormatByteSize(byteCount, buffer, buffer.Capacity);
            return buffer.ToString();
        }
    }
}
