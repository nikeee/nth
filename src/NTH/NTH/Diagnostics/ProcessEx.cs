using System.Diagnostics;

namespace NTH.Diagnostics
{
    public static class ProcessEx
    {
        public static Process Run(CommandLine commandLine)
        {
            return Process.Start(commandLine.FilePath, (string)commandLine.Arguments);
        }
    }
}
