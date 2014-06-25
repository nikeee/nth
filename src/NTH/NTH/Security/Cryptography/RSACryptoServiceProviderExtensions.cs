/*********************************************************************************
 * Copyright (c) 2013, Christian Etter info at christian-etter dot de
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer. 
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution. 
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *********************************************************************************/

using NTH.IO;
using NTH.NativeTypes;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace NTH.Security.Cryptography
{
    /// <remarks> 
    /// This file was evaluated from <see cref="http://www.christian-etter.de/?p=771">CE's Blog</see>.
    /// The code has been adopted to the coding standards of this project.
    /// It was published with the approval of the original author.
    /// </remarks>
    public static class RSACryptoServiceProviderExtensions
    {
        public static void ImportPublicKeyPem(this RSACryptoServiceProvider provider, string pemString)
        {
            if (provider == null)
                throw new NullReferenceException();
            if (string.IsNullOrWhiteSpace(pemString))
                throw new ArgumentNullException("pemString");

            var derData = ConvertPemToDer(pemString);
            provider.ImportPublicKeyDer(derData);
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

        public static void ImportPrivateKeyPem(this RSACryptoServiceProvider provider, string pemString)
        {
            if (provider == null)
                throw new NullReferenceException();
            if (string.IsNullOrWhiteSpace(pemString))
                throw new ArgumentNullException("pemString");

            byte[] derData = ConvertPemToDer(pemString);
            provider.ImportPrivateKeyDer(derData);
        }

        public static void ImportPrivateKeyDer(this RSACryptoServiceProvider provider, byte[] derData)
        {
            if (provider == null)
                throw new NullReferenceException();
            if (derData == null)
                throw new ArgumentNullException();
            var privateKeyBlob = GetPrivateKeyDer(derData);
            provider.ImportCspBlob(privateKeyBlob);
        }


        private static byte[] ConvertDerToRsa(byte[] derData)
        {
            Debug.Assert(derData != null);

            byte[] data = null;

            UInt32 dwCertPublicKeyInfoSize = 0;

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

            return publicKey;
        }

        private static byte[] GetPublicKeyBlobFromRsa(byte[] rsaData)
        {
            Debug.Assert(rsaData != null);
            byte[] data = null;

            uint dwCertPublicKeyBlobSize = 0;
            bool success = NativeMethods.CryptDecodeObject(
                    CryptEncodingFlags.X509AsnEncoding | CryptEncodingFlags.Pkcs7AsnEncoding,
                    new IntPtr((int)CryptOutputTypes.RsaCspPublicKeyBlob), rsaData, rsaData.Length,
                    CryptDecodeFlags.None,
                    data, ref dwCertPublicKeyBlobSize);
            if (!success)
                throw new Win32Exception();

            data = new byte[dwCertPublicKeyBlobSize];
            success = NativeMethods.CryptDecodeObject(
                    CryptEncodingFlags.X509AsnEncoding | CryptEncodingFlags.Pkcs7AsnEncoding,
                    new IntPtr((int)CryptOutputTypes.RsaCspPublicKeyBlob), rsaData, rsaData.Length,
                    CryptDecodeFlags.None,
                    data, ref dwCertPublicKeyBlobSize);

            if (!success)
                throw new Win32Exception();

            return data;
        }

        private static byte[] GetPrivateKeyDer(byte[] derData)
        {
            byte[] data = null;
            uint dwRSAPrivateKeyBlobSize = 0;
            bool success = NativeMethods.CryptDecodeObject(
                    CryptEncodingFlags.X509AsnEncoding | CryptEncodingFlags.Pkcs7AsnEncoding,
                    new IntPtr((int)CryptOutputTypes.PkcsRsaPrivateKey),
                    derData, derData.Length, CryptDecodeFlags.None, data, ref dwRSAPrivateKeyBlobSize);

            if (!success)
                throw new Win32Exception();

            data = new byte[dwRSAPrivateKeyBlobSize];

            success = NativeMethods.CryptDecodeObject(
                    CryptEncodingFlags.X509AsnEncoding | CryptEncodingFlags.Pkcs7AsnEncoding,
                    new IntPtr((int) CryptOutputTypes.PkcsRsaPrivateKey),
                    derData, derData.Length, CryptDecodeFlags.None, data, ref dwRSAPrivateKeyBlobSize);
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
