using System;
using System.IO;
using System.Security.Cryptography;

namespace NTH.IO
{
    public static class FileEx
    {
        public static byte[] ComputeHash(string fileName, HashAlgorithm hashAlgorithm)
        {
            if (hashAlgorithm == null)
                throw new ArgumentNullException("hashAlgorithm");

            using (var stream = File.OpenRead(fileName))
                return hashAlgorithm.ComputeHash(stream);
        }

        #region Specific Hashes

        public static byte[] ComputeHashMd5(string fileName)
        {
            using (var csp = new MD5CryptoServiceProvider())
                return ComputeHash(fileName, csp);
        }
        public static byte[] ComputeHashSha1(string fileName)
        {
            using (var csp = new SHA1CryptoServiceProvider())
                return ComputeHash(fileName, csp);
        }
        public static byte[] ComputeHashSha256(string fileName)
        {
            using (var csp = new SHA256CryptoServiceProvider())
                return ComputeHash(fileName, csp);
        }
        public static byte[] ComputeHashSha384(string fileName)
        {
            using (var csp = new SHA384CryptoServiceProvider())
                return ComputeHash(fileName, csp);
        }
        public static byte[] ComputeHashSha512(string fileName)
        {
            using (var csp = new SHA512CryptoServiceProvider())
                return ComputeHash(fileName, csp);
        }

        #endregion
    }
}
