using System;

namespace NTH
{
    public class ByteSize
    {
        private static ByteSize _zero;
        public static ByteSize Zero { get { return _zero ?? (_zero = new ByteSize(0, BytePrefix.Bytes)); } }

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
        //TODO: Add implicit/explicit cast operators

        public static ByteSize operator +(ByteSize bs1, ByteSize bs2)
        {
            if (bs1 == null)
            {
                if (bs2 == null)
                    return new ByteSize(0, BytePrefix.Bytes);
                return new ByteSize(bs2.ByteCount);
            }
            if (bs2 == null)
                return new ByteSize(bs1.ByteCount);
            return new ByteSize(bs1._byteCount + bs2._byteCount);
        }
        public static ByteSize operator -(ByteSize bs1, ByteSize bs2)
        {
            if (bs1 == null)
            {
                if (bs2 == null)
                    return new ByteSize(0, BytePrefix.Bytes);
                return new ByteSize(-bs2.ByteCount);
            }
            if (bs2 == null)
                return new ByteSize(bs1.ByteCount);
            return new ByteSize(bs1._byteCount - bs2._byteCount);
        }

        #region Equals

        public static bool operator ==(ByteSize a, ByteSize b)
        {
            if (object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a._byteCount == b._byteCount;
        }

        public static bool operator !=(ByteSize a, ByteSize b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var bs = obj as ByteSize;
            if (bs == null)
                return false;
            return bs._byteCount == this._byteCount;
        }

        public bool Equals(ByteSize bs)
        {
            return bs._byteCount == _byteCount;
        }

        public override int GetHashCode()
        {
            return _byteCount.GetHashCode();
        }

        #endregion

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
}
