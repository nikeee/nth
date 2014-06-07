using System.Text;

namespace NTH.Text.Formatting
{
    public static class ByteSizeFormatter
    {
        public static string FormatBytes(long byteCount)
        {
            var buffer = new StringBuilder(10);
            var res = NativeMethods.StrFormatByteSize(byteCount, buffer, buffer.Capacity);
            return res != null ? buffer.ToString() : string.Empty;
        }
    }
}
