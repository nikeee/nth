using System;
using System.Security.Cryptography;

namespace NTH.Security.Cryptography
{
    /// <summary>Implements a 32-bit ADLER-32 hash algorithm.</summary>
    /// <remarks>
    /// This class was evaluated from this forum post:
    /// http://forum.singul4rity.com/thread-24.html
    /// </remarks>
    public sealed class Adler32 : HashAlgorithm
    {
        private const int DefaultInitial = 1;

        /// <summary>Base for modulo arithmetic</summary>
        private const int ModuloValue = 65521;

        /// <summary>Number of iterations we can safely do before applying the modulo.</summary>
        private const int NMax = 5552;

        private uint _hash;

        #region Ctors

        /// <summary>Initializes a new instance of <see cref="NTH.Security.Cryptography.Adler32" />.</summary>
        public Adler32()
        {
            _hash = DefaultInitial;
        }

        #endregion
        #region Overrides

        public override int HashSize { get { return 32; } }

        /// <summary>Initializes <see cref="NTH.Security.Cryptography.Adler32" />.</summary>
        public override void Initialize()
        {
            _hash = DefaultInitial;
        }

        protected override void HashCore(byte[] buffer, int start, int length)
        {
            _hash = CalculateHash(buffer, _hash, start, length);
        }

        protected override byte[] HashFinal()
        {
            return BitConverter.GetBytes(_hash);
        }

        #endregion
        #region Computations

        /// <summary>Computes the Adler32 checksum for the given data.</summary>
        /// <param name="data">The data to compute the checksum of.</param>
        public static uint Compute(byte[] data)
        {
            return Compute(data, DefaultInitial);
        }

        /// <summary>Computes the Adler32 checksum for the given data.</summary>
        /// <param name="data">The data to compute the checksum of.</param>
        /// <param name="initialValue">Initial value or previous result. Use 1 for the first transformation.</param>
        public static uint Compute(byte[] data, uint initialValue)
        {
            return CalculateHash(data, initialValue, 0, data.Length);
        }

        /// <summary>Computes the Adler32 checksum for the given data.</summary>
        /// <param name="data">The data to compute the checksum of.</param>
        /// <param name="initialValue">Initial value or previous result. Use 1 for the first transformation.</param>
        /// <param name="start">Index of first byte to compute checksum for.</param>
        /// <param name="length">Number of bytes to compute checksum for.</param>
        public static uint Compute(byte[] data, uint initialValue, int start, int length)
        {
            return CalculateHash(data, initialValue, start, length);
        }

        /// <summary>Computes the Adler32 checksum for the given data.</summary>
        /// <param name="buffer">The data to compute the checksum of.</param>
        /// <param name="initialValue">Initial value or previous result. Use 1 for the first transformation.</param>
        /// <param name="start">Index of first byte to compute checksum for.</param>
        /// <param name="length">Number of bytes to compute checksum for.</param>
        /// <returns>The checksum of the given data.</returns>
        private static uint CalculateHash(byte[] buffer, uint initialValue, int start, int length)
        {
            uint a = initialValue & 0xFFFF;
            uint b = (initialValue >> 16) & 0xFFFF;

            int index = start;

            int k;
            while (length > 0)
            {
                k = (length < NMax) ? length : NMax;
                length -= k;

                for (int i = 0; i < k; i++)
                {
                    a += buffer[index++];
                    b += a;
                }
                a %= ModuloValue;
                b %= ModuloValue;
            }

            return (b << 16) | a;
        }

        #endregion
    }
}
