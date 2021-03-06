﻿#if FALSE
using System;

namespace NTH.IO
{
    internal static class EndianUtil
    {
        internal static bool IsLittleEndian
        {
            get
            {
                return BitConverter.IsLittleEndian;
            }
        }

        internal static byte[] GetReverseBytes(short value)
        {
            return BitConverter.GetBytes(SwapEndianness(value));
        }

        internal static byte[] GetReverseBytes(int value)
        {
            return BitConverter.GetBytes(SwapEndianness(value));
        }
        internal static byte[] GetReverseBytes(long value)
        {
            return BitConverter.GetBytes(SwapEndianness(value));
        }

        internal static short SwapEndianness(short value)
        {
            return unchecked((short)SwapEndianness((ushort)value));
        }
        internal static ushort SwapEndianness(ushort value)
        {
            unchecked
            {
                return
                    (ushort)
                    ((value & 0xFFU) << 8 |
                    (value & 0xFF00U) >> 8);
            }
        }

        internal static int SwapEndianness(int value)
        {
            return unchecked((int)SwapEndianness((uint)value));
        }
        internal static uint SwapEndianness(uint value)
        {
            unchecked
            {
                return
                    (value & 0x000000FFU) << 24 |
                    (value & 0x0000FF00U) << 8 |
                    (value & 0x00FF0000U) >> 8 |
                    (value & 0xFF000000U) >> 24;
            }
        }

        public static long SwapEndianness(long value)
        {
            return unchecked((long)SwapEndianness((ulong)value));
        }
        public static ulong SwapEndianness(ulong value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }
    }
}
#endif
