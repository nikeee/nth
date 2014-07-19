using System;
using System.Collections.Generic;
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
        private const int ModuloValue = 65521
        /// <summary>Number of iterations we can safely do before applying the modulo.</summary>
        private const int NMax = 5552

        private uint _hash;

        #region Ctors

        /// <summary>Initializes a new instance of <see cref="NTH.Security.Cryptography.Adler32" />.</summary>
        public Adler32()
        { }

        #endregion
        #region Overrides

        public override int HashSize { get { return 32; } }

        /// <summary>Initializes <see cref="NTH.Security.Cryptography.Adler32" />.</summary>
        public override void Initialize()
        { }

        protected override void HashCore(byte[] buffer, int start, int length)
        {
            _hash = CalculateHash(DefaultInitial, buffer, start, length);
        }

        protected override byte[] HashFinal()
        {
            return BitConverter.GetBytes(_hash);
        }

        #endregion
        #region Computations

        public static uint Compute(byte[] buffer)
        {
            return Compute(DefaultInitial, buffer);
        }

        public static uint Compute(uint initialValue, byte[] buffer)
        {
            return CalculateHash(initialValue, buffer, 0, buffer.Length);
        }

        private static uint CalculateHash(uint initialValue, byte[] data, int start, int size)
        {
            uint a = (uint)(initialValue & 0xFFFF);
            uint b = (uint)((initialValue >> 16) & 0xFFFF);

            int index = start;
            int len = length;

            int k;
            while (len > 0)
            {
                k = (len < NMax) ? len : NMax;
                len -= k;

                for (int i=0; i < k; i++)
                {
                    a += data[index++];
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
