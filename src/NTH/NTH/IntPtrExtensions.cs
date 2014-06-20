using System;

namespace NTH
{
    public static class IntPtrExtensions
    {
        private const string Prefix = "0x";

        public static string ToHexString(this IntPtr ptr)
        {
            return ptr.ToHexString(true);
        }
        public static string ToHexString(this IntPtr ptr, bool includePrefix)
        {
            return ptr.ToHexString(includePrefix, IntPtr.Size);
        }
        public static string ToHexString(this IntPtr ptr, bool includePrefix, int pointerSize)
        {
            return (includePrefix ? Prefix : "") + ptr.ToString("X").PadLeft(2 * pointerSize, '0');
        }
    }
}
