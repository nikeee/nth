namespace NTH
{
    /// <summary>Some utility extensions on <typeparam name="Int32"/>.</summary>
    public static class Int32Extensions
    {
        private const string Prefix = "0x";

        public static string ToHexString(this int value)
        {
            return value.ToHexString(true);
        }

        public static string ToHexString(this int value, bool includePrefix)
        {
            return (includePrefix ? Prefix : string.Empty) + value.ToString("X").PadLeft(8, '0');
        }
    }
}
