using System;

namespace NTH.NativeTypes
{
    [Flags]
    internal enum CryptDecodeFlags // CRYPT_DECODE_FLAGS
    {
        None = 0,
        Alloc = 0x8000
    }
}
