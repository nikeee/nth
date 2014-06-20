using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NTH
{
    internal static class NativeMethods
    {
        private const string Shlwapi = "Shlwapi.dll";

        [DllImport(Shlwapi, ThrowOnUnmappableChar=true)]
        internal static extern IntPtr StrFormatByteSize(long fileSize, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder buffer, int bufferSize);
    }
}
