using System;
using System.Runtime.InteropServices;
using System.Text;
using NTH.NativeTypes;

namespace NTH
{
    internal static class NativeMethods
    {
        private const string Shlwapi = "Shlwapi.dll";
        private const string Crypt32 = "Crypt32.dll";

        #region Shlwapi

        [DllImport(Shlwapi, CharSet = CharSet.Auto)]
        internal static extern IntPtr StrFormatByteSize(
                long fileSize,
                [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer,
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
    }
}
