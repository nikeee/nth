using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using NTH.IO;
using NTH.NativeTypes;

namespace NTH.Security.Cryptography
{
    public static class RSACryptoServiceProviderExtensions
    {
        public static void ImportPublicKeyPem(this RSACryptoServiceProvider provider, string pemString)
        {
            if (provider == null)
                throw new NullReferenceException();
            if (string.IsNullOrWhiteSpace(pemString))
                throw new ArgumentNullException("pemString");
            var der = ConvertPemToDer(pemString);

            provider.ImportPublicKeyDer(der);
        }

        public static void ImportPublicKeyDer(this RSACryptoServiceProvider provider, byte[] derData)
        {
            if (provider == null)
                throw new NullReferenceException();
            if (derData == null)
                throw new ArgumentNullException();

            byte[] rsaData = ConvertDerToRsa(derData);
            byte[] publicKeyBlob = GetPublicKeyBlobFromRsa(rsaData);

            provider.ImportCspBlob(publicKeyBlob);
        }


        private static byte[] ConvertDerToRsa(byte[] derData)
        {
            Debug.Assert(derData != null);

            byte[] data = null;

            UInt32 dwCertPublicKeyInfoSize = 0;
            //var pCertPublicKeyInfo = IntPtr.Zero;

            bool success = NativeMethods.CryptDecodeObject(
                    CryptEncodingFlags.X509AsnEncoding | CryptEncodingFlags.Pkcs7AsnEncoding,
                    new IntPtr((int)CryptOutputTypes.X509PublicKeyInfo),
                    derData, derData.Length, CryptDecodeFlags.None, data, ref dwCertPublicKeyInfoSize);

            if (!success)
                throw new Win32Exception();

            data = new byte[dwCertPublicKeyInfoSize];
            success = NativeMethods.CryptDecodeObject(
                CryptEncodingFlags.X509AsnEncoding | CryptEncodingFlags.Pkcs7AsnEncoding,
                new IntPtr((int)CryptOutputTypes.X509PublicKeyInfo),
                derData, derData.Length,
                CryptDecodeFlags.None,
                data, ref dwCertPublicKeyInfoSize);

            if (!success)
                throw new Win32Exception();

            var info = data.ConvertToStruct<PublicKeyCertInfo>();
            var publicKey = new byte[info.PublicKey.cbData];
            Marshal.Copy(info.PublicKey.pbData, publicKey, 0, publicKey.Length);

            /*
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                info = (PublicKeyCertInfo)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PublicKeyCertInfo));
                publicKey = new byte[info.PublicKey.cbData];
                Marshal.Copy(info.PublicKey.pbData, publicKey, 0, publicKey.Length);
            }
            finally
            {
                handle.Free();
            }
            */


            return publicKey;
        }

        private static byte[] GetPublicKeyBlobFromRsa(byte[] rsaData)
        {
            Debug.Assert(rsaData != null);
            byte[] data = null;

            UInt32 dwCertPublicKeyBlobSize = 0;
            bool success =  NativeMethods.CryptDecodeObject(
                    CryptEncodingFlags.X509AsnEncoding | CryptEncodingFlags.Pkcs7AsnEncoding,
                    new IntPtr((int)CryptOutputTypes.RsaCspPublicKeyBlob), rsaData, rsaData.Length,
                    CryptDecodeFlags.None,
                    data, ref dwCertPublicKeyBlobSize);
            if (!success)
                throw new Win32Exception();

            data = new byte[dwCertPublicKeyBlobSize];
            success =  NativeMethods.CryptDecodeObject(
                    CryptEncodingFlags.X509AsnEncoding | CryptEncodingFlags.Pkcs7AsnEncoding,
                    new IntPtr((int)CryptOutputTypes.RsaCspPublicKeyBlob), rsaData, rsaData.Length,
                    CryptDecodeFlags.None,
                    data, ref dwCertPublicKeyBlobSize);

            if (!success)
                throw new Win32Exception();

            return data;
        }

        private static byte[] ConvertPemToDer(string pemData)
        {
            Debug.Assert(pemData != null);

            uint dwSkip;
            uint dwFlags;
            uint dwBinarySize = 0;

            if (!NativeMethods.CryptStringToBinary(pemData, pemData.Length, CryptStringFlags.Base64Header, null, ref dwBinarySize, out dwSkip, out dwFlags))
                throw new Win32Exception();

            var decodedData = new byte[dwBinarySize];
            if (!NativeMethods.CryptStringToBinary(pemData, pemData.Length, CryptStringFlags.Base64Header, decodedData, ref dwBinarySize, out dwSkip, out dwFlags))
                throw new Win32Exception();
            return decodedData;
        }
    }
}
