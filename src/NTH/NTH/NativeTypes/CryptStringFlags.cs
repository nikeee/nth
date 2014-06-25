using System;

namespace NTH.NativeTypes
{
    [Flags]
    internal enum CryptStringFlags : uint
    {
        Base64Header = 0,
        Base64 = 1,
        Binary = 2,
        Base64RequestHeader = 3,
        Hex = 4,
        HexAscii = 5,
        Base64Any = 6,
        Any = 7,
        HexAny = 8,
        Base64X509CRLHeader = 9,
        HexAddr = 10,
        HexAsciiAddr = 11,
        HexRaw = 12,
        NoCrLf = 0x40000000,
        NoCr = 0x80000000
    }
}
