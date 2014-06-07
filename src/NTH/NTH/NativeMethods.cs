using System.Runtime.InteropServices;
using System.Text;

namespace NTH
{
    internal static class NativeMethods
    {
        private const string Shlwapi = "Shlwapi.dll";

        [DllImport(Shlwapi, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        internal static extern string StrFormatByteSize(long fileSize, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer, int bufferSize);
    }
}
