using System;

namespace NTH
{
    public static class IntPtrExtensions
    {
        public static string ToHexString(this IntPtr ptr)
        {
            return ptr.ToHexString(true);
        }
        public static string ToHexString(this IntPtr ptr, bool prefix)
        {
            return ptr.ToHexString(prefix, IntPtr.Size);
        }
        public static string ToHexString(this IntPtr ptr, bool prefix, int pointerSize)
        {
            return (prefix ? "0x" : "") + ptr.ToString("X").PadLeft(2 * pointerSize, '0');
        }
    }
}
