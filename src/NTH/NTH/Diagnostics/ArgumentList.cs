using System.Collections.Generic;
using System.Text;

namespace NTH.Diagnostics
{
    public class ArgumentList : List<string>
    {
        public static explicit operator string (ArgumentList args)
        {
            if (args == null || args.Count == 0)
                return string.Empty;
            return args.ToString();
        }

        internal string GetFormattedArguments()
        {
            if (Count == 0)
                return string.Empty;
            var sb = new StringBuilder();
            for (int i = 0; i < Count; ++i)
                sb.Append(' ').FormatItem(this[i]);
            return sb.Remove(0, 1).ToString();
        }

        public override string ToString()
        {
            return GetFormattedArguments();
        }

        public static ArgumentList Parse(string fullArguments)
        {
            if (string.IsNullOrWhiteSpace(fullArguments))
                return new ArgumentList();

            var arguments = new ArgumentList();
            string arg;
            fullArguments = CommandLineUtil.ReadItem(fullArguments, out arg);
            do
            {
                arguments.Add(arg);
                fullArguments = CommandLineUtil.ReadItem(fullArguments, out arg);
            } while (fullArguments != string.Empty);
            arguments.Add(arg);

            return arguments;
        }

    }
}
