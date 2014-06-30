using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NTH
{
    internal static class SecureStringExtensions
    {
        internal static void RemoveChar(this SecureString value)
        {
            if (value == null)
                throw new NullReferenceException();
            if (value.Length > 0)
                value.RemoveAt(value.Length - 1);
        }
        internal static string ToUnsecureString(this SecureString value)
        {
            if (value == null)
                throw new NullReferenceException();

            IntPtr bstr = Marshal.SecureStringToBSTR(value);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }
    }
}
