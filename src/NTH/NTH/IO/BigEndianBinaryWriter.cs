using System;
using System.IO;
using System.Text;

namespace NTH.IO
{
    /// <summary>Writes primitive types in binary big endian to a stream and supports writing strings in a specific encoding.</summary>
    /// <filterpriority>2</filterpriority>
    public class BigEndianBinaryWriter : BinaryWriter
    {
        #region Ctors

        /// <summary>Initializes a new instance of the <see cref="NTH.IO.BigEndianBinaryWriter" /> class based on the supplied stream and using UTF-8 as the encoding for strings.</summary>
        /// <param name="output">The output stream.</param>
        /// <exception cref="System.ArgumentException">The stream does not support writing, or the stream is already closed.</exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="output" /> is null.</exception>
        public BigEndianBinaryWriter(Stream output)
            : base(output)
        { }

        /// <summary>Initializes a new instance of the <see cref="NTH.IO.BigEndianBinaryWriter" /> class based on the supplied stream and a specific character encoding.</summary>
        /// <param name="output">The supplied stream.</param>
        /// <param name="encoding">The character encoding.</param>
        /// <exception cref="T:System.ArgumentException">The stream does not support writing, or the stream is already closed.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="output" /> or <paramref name="encoding" /> is null.</exception>
        public BigEndianBinaryWriter(Stream output, Encoding encoding)
            : base(output, encoding)
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
