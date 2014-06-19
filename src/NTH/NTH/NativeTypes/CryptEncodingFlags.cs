using System;

namespace NTH.NativeTypes
{
    [Flags]
    internal enum CryptEncodingFlags : uint
    {
        Pkcs7AsnEncoding = 0x00010000,
        X509AsnEncoding = 0x00000001
    }
}
