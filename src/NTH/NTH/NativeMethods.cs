using NTH.NativeTypes;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NTH
{
    internal static class NativeMethods
    {
        private const string Shlwapi = "Shlwapi.dll";
        private const string Crypt32 = "Crypt32.dll";
        private const string Kernel32 = "Kernel32.dll";

        #region Shlwapi

        [DllImport(Shlwapi, CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
        internal static extern IntPtr StrFormatByteSize(
                long fileSize,
                [MarshalAs(UnmanagedType.LPWStr)] StringBuilder buffer,
                int bufferSize
            );

        #endregion
        #region Crypt32

        [DllImport(Crypt32, SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CryptStringToBinary(
                [MarshalAs(UnmanagedType.LPWStr)] string pszString,
                int stringLength,
                CryptStringFlags dwFlags,
                [In, Out] byte[] pbBinary,
                ref uint pcbBinary,
                out uint pdwSkip, out uint pdwFlags
            );

        [DllImport(Crypt32, SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CryptDecodeObjectEx(
                CryptEncodingFlags dwCertEncodingType,
                [MarshalAs(UnmanagedType.LPWStr)] string pszString,
                byte[] pbEncoded,
                uint cbEncoded,
                uint dwFlags,
                IntPtr decodeParam,
                out byte[] pvStructInfo,
                ref byte[] pcbStructInfo
            );

        [DllImport("crypt32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CryptDecodeObject(
                CryptEncodingFlags certEncodingType,
                IntPtr lpszStructType,
                byte[] pbEncoded,
                int cbEncoded,
                CryptDecodeFlags flags,
                [In, Out] byte[] pvStructInfo,
                ref uint cbStructInfo
            );
        #endregion
        #region Kernel32

        [DllImport(Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GlobalMemoryStatusEx([In, Out] NativeTypes.MemoryStatusEx data);
        //Used to use ref with comment below
        // but ref doesn't work.(Use of [In, Out] instead of ref
        //causes access violation exception on windows xp
        //comment: most probably caused by MEMORYSTATUSEX being declared as a class
        //(at least at pinvoke.net). On Win7, ref and struct work.

        [DllImport(Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GlobalMemoryStatus(ref NativeTypes.MemoryStatus lpBuffer);

        #endregion
    }
}
