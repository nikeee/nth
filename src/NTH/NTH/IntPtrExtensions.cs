using System;

namespace NTH
{
    /// <summary>Some utility extensions on <typeparam name="IntPtr"/>.</summary>
    public static class IntPtrExtensions
    {
        private const string Prefix = "0x";

        public static string ToHexString(this IntPtr value) => value.ToHexString(true);
        public static string ToHexString(this IntPtr value, bool includePrefix) => value.ToHexString(includePrefix, IntPtr.Size);
        public static string ToHexString(this IntPtr value, bool includePrefix, int pointerSize)
        {
            return (includePrefix ? Prefix : string.Empty) + value.ToString("X").PadLeft(2 * pointerSize, '0');
        }
    }
}
