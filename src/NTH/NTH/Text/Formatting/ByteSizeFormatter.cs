using System.Text;

namespace NTH.Text.Formatting
{
    /// <summary>Format a byte size long to a human readable format.</summary>
    public static class ByteSizeFormatter
    {
        /// <summary>
        /// Formats a long representing a byte size to a human readable format. Uses the Windows API.
        /// Because it uses the Windows API, it always calculates using the binary power (1024), but returns the decimal prefix (e.g. KB).
        /// </summary>
        /// <param name="byteCount">The number of bytes</param>
        /// <returns>Formatted string.</returns>
        public static string FormatBytes(long byteCount)
        {
            return FormatBytes(byteCount, false);
        }
        /// <summary>
        /// Formats a long representing a byte size to a human readable format. Uses the Windows API.
        /// Because it uses the Windows API, it always calculates using the binary power (1024), but returns the decimal prefix (e.g. KB).
        /// </summary>
        /// <param name="byteCount">The number of bytes</param>
        /// <param name="useBinaryPrefix">If this parameter is true, it returns a binary prefixed value. If not the return value is using a decimal prefix. Note that the value always calculates with binary powers.</param>
        /// <returns>Formatted string.</returns>
        public static string FormatBytes(long byteCount, bool useBinaryPrefix)
        {
            // TODO: Conditional compilation for mono compability
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
