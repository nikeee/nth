using System;

namespace NTH
{
    public class ByteSize
    {
        private readonly long _byteCount;

        public long ByteCount { get { return _byteCount; } }

        public ByteSize()
            : this(0)
        { }
        public ByteSize(long bytes)
            : this(bytes, BytePrefix.Bytes)
        { }
        public ByteSize(long prefixedBytes, BytePrefix type)
        {
            if (prefixedBytes == 0)
            {
                _byteCount = 0;
                return;
            }

            if (type != BytePrefix.Bytes)
            {
                int kind = (int)type >> 8;
                int factorIdentifier = (int)type & 0xff;
                int baseInt = (PrefixType)kind == PrefixType.Binary ? 1024 : 1000;

                _byteCount = prefixedBytes * MathEx.Pow(baseInt, factorIdentifier);
            }
            else
            {
                _byteCount = prefixedBytes;
            }
        }

        //TODO: Add Parse/TryParse method

        public string ToString(PrefixType prefixType)
        {
            return Format(_byteCount, prefixType);
        }

        public override string ToString()
        {
            return ToString(PrefixType.Binary);
        }

        private static string Format(long size, PrefixType prefixType)
        {
            int unit = prefixType == PrefixType.Decimal ? 1000 : 1024;
            string i = prefixType == PrefixType.Decimal ? "" : "i";

            if (size < unit)
                return (size).ToString("F0") + " bytes";
            
            if (size < Math.Pow(unit, 2))
                return (size / unit).ToString("F0") + " K" + i + "B";

            if (size < Math.Pow(unit, 3))
                return (size / Math.Pow(unit, 2)).ToString("F0") + " M" + i + "B";

            if (size < Math.Pow(unit, 4))
                return (size / Math.Pow(unit, 3)).ToString("F0") + " G" + i + "B";

            if (size < Math.Pow(unit, 5))
                return (size / Math.Pow(unit, 4)).ToString("F0") + " T" + i + "B";

            if (size < Math.Pow(unit, 6))
                return (size / Math.Pow(unit, 5)).ToString("F0") + " P" + i + "B";

            return (size / Math.Pow(unit, 6)).ToString("F0") + " E" + i + "B";
        }
    }

    public enum PrefixType
    {
        Decimal = 0x1,
        Binary = 0x2
    }

    public enum BytePrefix
    {
        Bytes = 0x000,

        KiloByte = 0x101,
        MegaByte,
        GigaByte,
        TeraByte,
        PetaByte,
        ExaByte,

        KibiByte = 0x201,
        MibiByte,
        GibiByte,
        TebiByte,
        PebiByte,
        ExbiByte
    }
}
