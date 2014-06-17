using System;
using System.IO;
using System.Text;

namespace NTH.IO
{
    public class BigEndianBinaryWriter : BinaryWriter
    {
        #region Ctors

        public BigEndianBinaryWriter(Stream input)
            : base(input)
        { }
        public BigEndianBinaryWriter(Stream input, Encoding encoding)
            : base(input, encoding)
        { }

        #endregion
        #region Int16

        public override void Write(short value)
        {
            ReverseWrite(BitConverter.GetBytes(value));
        }
        public override void Write(ushort value)
        {
            ReverseWrite(BitConverter.GetBytes(value));
        }

        #endregion
        #region Int23

        public override void Write(int value)
        {
            ReverseWrite(BitConverter.GetBytes(value));
        }
        public override void Write(uint value)
        {
            ReverseWrite(BitConverter.GetBytes(value));
        }

        #endregion
        #region Int46

        public override void Write(long value)
        {
            ReverseWrite(BitConverter.GetBytes(value));
        }
        public override void Write(ulong value)
        {
            ReverseWrite(BitConverter.GetBytes(value));
        }

        #endregion
        #region Internal Writing

        protected void ReverseWrite(byte[] data)
        {
            if(BitConverter.IsLittleEndian)
                Array.Reverse(data);
            base.Write(data);
        }

        #endregion
    }
}
