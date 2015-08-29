using System;

namespace NTH
{
    public struct ByteSize : IEquatable<ByteSize>
    {
        public static ByteSize Zero => default(ByteSize);

        public long ByteCount { get; }

        #region Ctor

        public ByteSize(long bytes)
            : this(bytes, ByteSizeUnit.Bytes)
        { }
        public ByteSize(long prefixedBytes, ByteSizeUnit type)
        {
            if (prefixedBytes == 0)
            {
                ByteCount = 0;
                return;
            }

            if (type == ByteSizeUnit.Bytes)
            {
                ByteCount = prefixedBytes;
                return;

            }
            int kind = (int)type >> 8;
            int factorIdentifier = (int)type & 0xff;
            int baseInt = (PrefixType)kind == PrefixType.Binary ? 1024 : 1000;

            ByteCount = prefixedBytes * MathEx.Pow(baseInt, factorIdentifier);
        }

        #endregion

        //TODO: Add Parse/TryParse method
        //TODO: Add implicit/explicit cast operators

        #region +/- operators

        public static ByteSize operator +(ByteSize bs1, ByteSize bs2) => new ByteSize(bs1.ByteCount + bs2.ByteCount);
        public static ByteSize operator ++(ByteSize b) => new ByteSize(b.ByteCount + 1);

        public static ByteSize operator -(ByteSize bs1, ByteSize bs2) => new ByteSize(bs1.ByteCount - bs2.ByteCount);
        public static ByteSize operator --(ByteSize b) => new ByteSize(b.ByteCount - 1);

        #endregion
        #region gt/lt operators

        public static bool operator <(ByteSize b1, ByteSize b2) => b1.ByteCount < b2.ByteCount;
        public static bool operator <=(ByteSize b1, ByteSize b2) => b1.ByteCount <= b2.ByteCount;
        public static bool operator >(ByteSize b1, ByteSize b2) => b1.ByteCount > b2.ByteCount;
        public static bool operator >=(ByteSize b1, ByteSize b2) => b1.ByteCount >= b2.ByteCount;

        #endregion
        #region Equals

        public static bool operator ==(ByteSize a, ByteSize b) => a.ByteCount == b.ByteCount;
        public static bool operator !=(ByteSize a, ByteSize b) => a.ByteCount != b.ByteCount;

        public override bool Equals(object obj) => obj is ByteSize && (ByteSize)obj == this;
        public bool Equals(ByteSize other) => other.ByteCount == ByteCount;

        public override int GetHashCode() => ByteCount.GetHashCode();

        #endregion
        #region ToString

        public string ToString(PrefixType prefixType) => Format(ByteCount, prefixType);

        public override string ToString() => ToString(PrefixType.Binary);

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

        #endregion
    }
}
