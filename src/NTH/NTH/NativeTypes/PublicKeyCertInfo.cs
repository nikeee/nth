using System;
using System.Runtime.InteropServices;

namespace NTH.NativeTypes
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct PublicKeyCertInfo // CERT_PUBLIC_KEY_INFO
    {
        internal AlgorithmIdentifier Algorithm;
        internal BitBlob PublicKey;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AlgorithmIdentifier // CRYPT_ALGORITHM_IDENTIFIER
    {
        internal IntPtr ObjectId;
        internal ObjectIdBlob Parameters;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct BitBlob // CRYPT_BIT_BLOB
    {
        internal UInt32 cbData;
        internal IntPtr pbData;
        internal UInt32 cUnusedBits;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct ObjectIdBlob // CRYPT_OBJID_BLOB
    {
        internal UInt32 cbData;
        internal IntPtr pbData;
    }
}
