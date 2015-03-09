using System.IO;
using System.Linq;

namespace NTH.IO
{
    public class PathEx
    {
        private static readonly char[] InvalidPathChars = Path.GetInvalidPathChars();
        private static readonly char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();
        private static readonly char[] PathTrimChars = {
            '\t',
            '\n',
            '\v',
            '\f',
            '\r',
            ' ',
            '\u0085',
            '\u00a0'
        };

        public static bool ContainsInvalidPathChars(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            for (int i = 0; i < path.Length; ++i)
                if (InvalidPathChars.Contains(path[i]))
                    return true;
            return false;
        }

        public static bool ContainsInvalidFileNameChars(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            for (int i = 0; i < fileName.Length; ++i)
                if (InvalidFileNameChars.Contains(fileName[i]))
                    return true;
            return false;
        }

        internal static bool IsUnixHiddenFileName(string fileName)
        {
            var fileNameOnly = Path.GetFileName(fileName);
            if (string.IsNullOrEmpty(fileNameOnly))
                return false;

            return fileNameOnly[0] == '.';
        }

        public static string TrimEnd(string path)
        {
            return string.IsNullOrWhiteSpace(path) ? string.Empty : path.TrimEnd(PathTrimChars);
        }
    }
}
