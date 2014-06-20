using System;
using System.Diagnostics;

namespace NTH.Diagnostics
{
    public static class ProcessEx
    {
        public static Process Run(CommandLine commandLine)
        {
            if(commandLine == null)
                throw new ArgumentNullException("commandLine");
            return Process.Start(commandLine.FilePath, (string)commandLine.Arguments);
        }
    }
}
