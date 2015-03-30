using System.Text;

namespace NTH.Diagnostics
{
    internal static class CommandLineUtil
    {
        internal static string ReadItem(string line, out string quotedString)
        {
            if (line.StartsWith("\""))
            {
                line = line.Remove(0, 1);
                var index = line.IndexOf('"');
                // TODO: Escaping using \"?
                quotedString = line.Remove(index);
                return line.Remove(0, quotedString.Length + 1).TrimStart();
            }
            var from = line.IndexOf(' ');
            if (from < 0)
            {
                quotedString = line;
                return string.Empty;
            }
            quotedString = line.Remove(from);
            return line.Remove(0, quotedString.Length + 1).TrimStart();
        }

        internal static StringBuilder FormatItem(this StringBuilder sb, string item)
        {
            // TODO: Chars that need escaping using a backslash:
            // { ' ', '\t', '\n', '\v', '"' }
            // Check whether this is needed.

            if (item.Contains(" "))
                sb.Append('"').Append(item).Append('"');
            else
                sb.Append(item);
            return sb;
        }
    }
}
