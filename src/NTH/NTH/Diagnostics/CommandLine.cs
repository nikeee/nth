using System.Text;

namespace NTH.Diagnostics
{
    public class CommandLine
    {
        public string FilePath { get; set; }

        public ArgumentList Arguments { get; private set; }

        public CommandLine(string filePath)
            : this(filePath, null)
        { }
        public CommandLine(string filePath, ArgumentList arguments)
        {
            FilePath = filePath;
            Arguments = arguments ?? new ArgumentList();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.FormatItem(FilePath);
            if (Arguments != null && Arguments.Count > 0)
                sb.Append(' ').Append(Arguments);
            return sb.ToString();
        }

        public static CommandLine Parse(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return new CommandLine(string.Empty, null);

            string filePath;
            line = CommandLineUtil.ReadItem(line, out filePath);
            var arguments = ArgumentList.Parse(line);
            return new CommandLine(filePath, arguments);
        }

    }
}
