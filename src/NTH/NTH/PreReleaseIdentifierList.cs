using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NTH
{
    public class PreReleaseIdentifierList : List<PreReleaseIdentifier>
    {
        public PreReleaseIdentifierList(IEnumerable<PreReleaseIdentifier> collection)
            : base(collection)
        { }
        public PreReleaseIdentifierList()
        { }


        public static bool operator >(PreReleaseIdentifierList a, PreReleaseIdentifierList b)
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
        public static bool operator <(PreReleaseIdentifierList a, PreReleaseIdentifierList b)
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

        public override string ToString()
        {
            if (Count == 0)
                return string.Empty;
            return string.Join(".", this); // looks weird
        }
    }
}
