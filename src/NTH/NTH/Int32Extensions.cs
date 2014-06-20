namespace NTH
{
    public static class Int32Extensions
    {
        public static string ToHexString(this int i)
        {
            return i.ToHexString(true);
        }

        public static string ToHexString(this int i, bool prefix)
        {
            return (prefix ? "0x" : "") + i.ToString("X").PadLeft(8, '0');
        }
    }
}
