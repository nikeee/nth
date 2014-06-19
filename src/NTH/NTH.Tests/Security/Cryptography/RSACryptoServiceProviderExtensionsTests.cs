using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTH.Security.Cryptography;

namespace NTH.Tests.Security.Cryptography
{
    [TestClass]
    public class RSACryptoServiceProviderExtensionsTests
    {
        private const string dataToSignString =
            "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium " +
            "doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore " +
            "veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim " +
            "ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia " +
            "consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque " +
            "porro quisquam est, qui dolorem ipsum, quia dolor sit amet, consectetur, " +
            "adipisci[ng] velit, sed quia non numquam [do] eius modi tempora inci[di]dunt, " +
            "ut labore et dolore magnam aliquam quaerat voluptatem.";


        private static readonly byte[] DataToSign = Encoding.Default.GetBytes(dataToSignString);

        [TestMethod]
        public void Der()
        {
            byte[] publicKeyDER = Resources.GetResource("RSACryptoServiceProviderExtensionPublicKey.der");
            byte[] privateKeyDER = Resources.GetResource("RSACryptoServiceProviderExtensionPrivateKey.der");

            Console.WriteLine("Public key:\n{0}\n", BitConverter.ToString(publicKeyDER).Replace("-", ""));
            Console.WriteLine("Private key:\n{0}\n", BitConverter.ToString(privateKeyDER).Replace("-", ""));

            byte[] signature;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportPrivateKeyDer(privateKeyDER);
                using (var sha1 = new SHA1CryptoServiceProvider())
                    signature = rsa.SignData(DataToSign, sha1);
            }

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportPublicKeyDer(publicKeyDER);

                bool isValidSignature;
                using (var sha1 = new SHA1CryptoServiceProvider())
                    isValidSignature = rsa.VerifyData(DataToSign, sha1, signature);
                Assert.IsTrue(isValidSignature);

                // invalidate signature so the next check must fail
                signature[signature.Length - 1] ^= 0xFF;
                using (var sha1 = new SHA1CryptoServiceProvider())
                    isValidSignature = rsa.VerifyData(DataToSign, sha1, signature);
                Assert.IsFalse(isValidSignature);
            }
        }

        [TestMethod]
        public void Pem()
        {
            string publicKeyPem = Encoding.ASCII.GetString(Resources.GetResource("RSACryptoServiceProviderExtensionPublicKey.pem"));
            string privateKeyPem = Encoding.ASCII.GetString(Resources.GetResource("RSACryptoServiceProviderExtensionPrivateKey.pem"));

            Console.WriteLine("Public key:\n{0}", publicKeyPem);
            Console.WriteLine("Private key:\n{0}", privateKeyPem);

            byte[] signature;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportPrivateKeyPem(privateKeyPem);
                using (var sha1 = new SHA1CryptoServiceProvider())
                    signature = rsa.SignData(DataToSign, sha1);
            }
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportPublicKeyPem(publicKeyPem);

                bool isValid;

                using (var sha1 = new SHA1CryptoServiceProvider())
                    isValid = rsa.VerifyData(DataToSign, sha1, signature);

                Assert.IsTrue(isValid);

                // invalidate signature so the next check must fail
                signature[signature.Length - 1] ^= 0xFF;
                using (var sha1 = new SHA1CryptoServiceProvider())
                    isValid = rsa.VerifyData(DataToSign, sha1, signature);
                Assert.IsFalse(isValid);
            }
        }
    }
}
