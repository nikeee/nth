using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace NTH.Security.Cryptography
{
    /// <summary>Implements a 32-bit CRC hash algorithm compatible with Zip etc.</summary>
    /// <remarks>
    /// If you need to call multiple times for the same data either use the HashAlgorithm
    /// interface or remember that the result of one Compute call needs to be ~ (XOR) before
    /// being passed in as the seed for the next Compute call.
    ///
    /// This class was imported from Damien Guard:
    /// https://github.com/damieng/DamienGKit/blob/master/CSharp/DamienG.Library/Security/Cryptography/Crc32.cs
    /// Originally published at http://damieng.com/blog/2006/08/08/calculating_crc32_in_c_and_net
    /// It was adapted to the coding standards of this project.
    /// </remarks>
    public sealed class Crc32 : HashAlgorithm
    {
        public const uint DefaultPolynomial = 0xedb88320u;
        public const uint DefaultSeed = 0xffffffffu;

        private static uint[] defaultTable;

        private readonly uint _seed;
        private readonly uint[] _table;
        private uint _hash;

        #region Ctors

        /// <summary>Initializes a new instance of <see cref="NTH.Security.Cryptography.Crc32" />.</summary>
        public Crc32()
            : this(DefaultPolynomial, DefaultSeed)
        { }

        public Crc32(uint polynomial, uint seed)
        {
            _table = InitializeTable(polynomial);
            _seed = _hash = seed;
        }

        #endregion
        #region Overrides
        
        public override int HashSize { get { return 32; } }

        /// <summary>Initializes <see cref="NTH.Security.Cryptography.Crc32" />.</summary>
        public override void Initialize()
        {
            _hash = _seed;
        }

        protected override void HashCore(byte[] buffer, int start, int length)
        {
            _hash = CalculateHash(_table, _hash, buffer, start, length);
        }

        protected override byte[] HashFinal()
        {
            var hashBuffer = UInt32ToBigEndianBytes(~_hash);
            HashValue = hashBuffer;
            return hashBuffer;
        }

        #endregion
        #region Computations
        
        public static uint Compute(byte[] buffer)
        {
            return Compute(DefaultSeed, buffer);
        }

        public static uint Compute(uint seed, byte[] buffer)
        {
            return Compute(DefaultPolynomial, seed, buffer);
        }

        public static uint Compute(uint polynomial, uint seed, byte[] buffer)
        {
            return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
        }

        private static uint[] InitializeTable(uint polynomial)
        {
            if (polynomial == DefaultPolynomial && defaultTable != null)
                return defaultTable;

            var createTable = new uint[256];
            for (var i = 0; i < 256; i++)
            {
                var entry = (uint)i;
                for (var j = 0; j < 8; j++)
                    if ((entry & 1) == 1)
                        entry = (entry >> 1) ^ polynomial;
                    else
                        entry = entry >> 1;
                createTable[i] = entry;
            }

            if (polynomial == DefaultPolynomial)
                defaultTable = createTable;

            return createTable;
        }

        private static uint CalculateHash(uint[] table, uint seed, IList<byte> buffer, int start, int size)
        {
            var crc = seed;
            for (var i = start; i < size - start; i++)
                crc = (crc >> 8) ^ table[buffer[i] ^ crc & 0xff];
            return crc;
        }

        private static byte[] UInt32ToBigEndianBytes(uint value)
        {
            var result = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(result);
            return result;
        }

        #endregion
    }
}
