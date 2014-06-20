namespace NTH
{
    public static class Int32Extensions
    {
        private const string Prefix = "0x";

        public static string ToHexString(this int i)
        {
            return i.ToHexString(true);
        }

        public static string ToHexString(this int i, bool includePrefix)
        {
            return (includePrefix ? Prefix : string.Empty) + i.ToString("X").PadLeft(8, '0');
        }
    }
}
