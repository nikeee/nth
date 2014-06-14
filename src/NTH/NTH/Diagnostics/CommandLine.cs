using System;
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
        
        private static CommandLine _current;
        public static CommandLine Current
        {
            get
            {
                return _current ?? (_current = CreateCurrentCommandLine());
            }
        }
        
        private static CommandLine CreateCurrentCommandLine()
        {
            var currentArgs = Environment.GetCommandLineArgs();
            System.Diagnostics.Debug.Assert(currentArgs != null);
            System.Diagnostics.Debug.Assert(currentArgs.Length > 0);
            
            // first Argument is path to executable
            if(currentArgs.Length == 0)
                throw new Exception();
            if(currentArgs.Length == 1)
                return new CommandLine(currentArgs[0]);

            var filePath = currentArgs[0];
            var args = new ArgumentList();
            for(int i = 1; i < currentArgs.Length; ++i)
                args.Add(currentArgs[i]);
            return new CommandLine(filePath, args);
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
