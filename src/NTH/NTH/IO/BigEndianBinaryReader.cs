using System;
using System.IO;
using System.Text;

namespace NTH.IO
{
    internal class BigEndianBinaryReader : BinaryReader
    {
        #region Ctors

        public BigEndianBinaryReader(Stream input)
            : base(input)
        { }
        public BigEndianBinaryReader(Stream input, Encoding encoding)
            : base(input, encoding)
        { }

        #endregion
        #region Int16

        public override short ReadInt16()
        {
            FillBuffer(2);
            return (short)(Buffer[0] << 8 | Buffer[1]);
        }
        //[CLSCompliant(false)]
        public override ushort ReadUInt16()
        {
            FillBuffer(2);
            return (ushort)(Buffer[0] << 8 | Buffer[1]);
        }

        #endregion
        #region Int32
        public override int ReadInt32()
        {
            FillBuffer(4);
            return (Buffer[3] | Buffer[2] << 8 | Buffer[1] << 16 | Buffer[0] << 24);
        }
        //[CLSCompliant(false)]
        public override uint ReadUInt32()
        {
            FillBuffer(4);
            return (uint)(Buffer[3] | Buffer[2] << 8 | Buffer[1] << 16 | Buffer[0] << 24);
        }

        #endregion
        #region Int64

        public override long ReadInt64()
        {
            FillBuffer(8);
            uint lo = (uint)(Buffer[3] | Buffer[2] << 8 |
                             Buffer[1] << 16 | Buffer[0] << 24);
            uint hi = (uint)(Buffer[7] | Buffer[6] << 8 |
                             Buffer[5] << 16 | Buffer[4] << 24);
            return (lo << 32 | hi);
        }
        //[CLSCompliant(false)]
        public override ulong ReadUInt64()
        {
            FillBuffer(8);
            uint lo = (uint)(Buffer[3] | Buffer[2] << 8 |
                             Buffer[1] << 16 | Buffer[0] << 24);
            uint hi = (uint)(Buffer[7] | Buffer[6] << 8 |
                             Buffer[5] << 16 | Buffer[4] << 24);
            return (ulong)(lo << 32 | hi);
        }

        #endregion
        #region Buffer Internals

        protected byte[] Buffer = new byte[1024];
        protected override void FillBuffer(int numBytes)
        {
            if (Buffer != null && (numBytes < 0 || numBytes > Buffer.Length))
                throw new ArgumentException("Invalid numBytes");

            int bytesRead = 0;
            int n = 0;

            if (BaseStream == null)
                throw new EndOfStreamException();

            if (numBytes == 1)
            {
                n = BaseStream.ReadByte();
                if (n == -1)
                    throw new EndOfStreamException();
                Buffer[0] = (byte)n;
                return;
            }

            do
            {
                n = BaseStream.Read(Buffer, bytesRead, numBytes - bytesRead);
                if (n == 0)
                    throw new EndOfStreamException();
                bytesRead += n;
            } while (bytesRead < numBytes);
        }

        #endregion
    }
}
