namespace NTH.Text
{
    /// <summary>Some utility extensions on <typeparam name="Char"/>.</summary>
    public static class CharExtensions
    {
        public static bool IsWhiteSpace(this char value)
        {
            return char.IsWhiteSpace(value);
        }
    }
}
