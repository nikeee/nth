using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace NTH
{
    public class BuildMetadataCollection : Collection<BuildMetadata>
    {
        #region Ctors

        public BuildMetadataCollection(IEnumerable<BuildMetadata> enumerable)
            : base(enumerable.ToList())
        { }
        public BuildMetadataCollection()
        { }

        #endregion

        #region operators

        #region ==

        private static bool AreItemsEqual(BuildMetadataCollection a, BuildMetadataCollection b)
        {
            Debug.Assert((object)a != null);
            Debug.Assert((object)b != null);
            Debug.Assert(a.Count == b.Count);

            int max = a.Count;
            for (int i = 0; i < max; ++i)
                if (a[i] != b[i])
                    return false;
            return true;
        }

        public static bool operator ==(BuildMetadataCollection a, BuildMetadataCollection b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            if (a.Count != b.Count)
                return false;
            return AreItemsEqual(a, b);
        }

        public static bool operator !=(BuildMetadataCollection a, BuildMetadataCollection b)
        {
            return !(a == b);
        }

        #endregion
        #region equals

        public override bool Equals(object obj)
        {
            var b = obj as BuildMetadataCollection;
            if (b == null)
                return false;
            if (Count != b.Count)
                return false;
            return AreItemsEqual(this, b);
        }

        public bool Equals(BuildMetadataCollection obj)
        {
            if (obj == null)
                return false;
            if (Count != obj.Count)
                return false;
            return AreItemsEqual(this, obj);
        }

        public override int GetHashCode() => base.GetHashCode(); // No immutable fields available, so just call the base?

        #endregion

        #endregion

        public override string ToString()
        {
            if (Count == 0)
                return string.Empty;
            return string.Join(".", this); // looks weird
        }
    }
}
