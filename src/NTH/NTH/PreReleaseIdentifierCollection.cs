using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace NTH
{
    public class PreReleaseIdentifierCollection : Collection<PreReleaseIdentifier>
    {
        #region Ctors

        public PreReleaseIdentifierCollection(IEnumerable<PreReleaseIdentifier> enumerable)
            : base(enumerable.ToList())
        { }
        public PreReleaseIdentifierCollection()
        { }

        #endregion

        #region operators

        #region >

        public static bool operator >(PreReleaseIdentifierCollection a, PreReleaseIdentifierCollection b)
        {
            // if both lists are empty, one of them cant be more valuable.
            if (a.Count == 0 && b.Count == 0)
                return false;

            if (a.Count == 0 && b.Count != 0)
                return true;
            if (a.Count != 0 && b.Count == 0)
                return false;

            var max = Math.Min(a.Count, b.Count);
            for (int i = 0; i < max; ++i)
            {
                if (a[i] > b[i])
                    return true;
                if (a[i] < b[i])
                    return false;
            }

            // all identifiers are equal, so take a look at the total count
            if (max != Math.Max(a.Count, b.Count))
            {
                if (a.Count == max) // if a is the one with less identifiers
                    return false; // so it must be less valuable
                return true; // else, return false
            }

            return false; // essentially, a == b
        }

        #endregion
        #region <

        public static bool operator <(PreReleaseIdentifierCollection a, PreReleaseIdentifierCollection b)
        {
            // if both lists are empty, one of them cant be more valuable.
            if (a.Count == 0 && b.Count == 0)
                return false;

            if (a.Count == 0 && b.Count != 0)
                return false;
            if (a.Count != 0 && b.Count == 0)
                return true;

            var max = Math.Min(a.Count, b.Count);
            for (int i = 0; i < max; ++i)
            {
                if (a[i] < b[i])
                    return true;
                if (a[i] > b[i])
                    return false;
            }

            // all identifiers are equal, so take a look at the total count
            if (max != Math.Max(a.Count, b.Count))
            {
                if (a.Count == max) // if a is the one with less identifiers
                    return true; // so it must be less valuable
                return false; // else, return false
            }

            return false; // essentially, a == b
        }

        #endregion
        #region ==

        private static bool AreItemsEqual(PreReleaseIdentifierCollection a, PreReleaseIdentifierCollection b)
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

        public static bool operator ==(PreReleaseIdentifierCollection a, PreReleaseIdentifierCollection b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            if (a.Count != b.Count)
                return false;
            return AreItemsEqual(a, b);
        }

        public static bool operator !=(PreReleaseIdentifierCollection a, PreReleaseIdentifierCollection b)
        {
            return !(a == b);
        }

        #endregion
        #region equals

        public override bool Equals(object obj)
        {
            var b = obj as PreReleaseIdentifierCollection;
            if (b == null)
                return false;
            if (Count != b.Count)
                return false;
            return AreItemsEqual(this, b);
        }

        public bool Equals(PreReleaseIdentifierCollection obj)
        {
            if (obj == null)
                return false;
            if (Count != obj.Count)
                return false;
            return AreItemsEqual(this, obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode(); // No immutable fields available, so just call the base?
        }

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
