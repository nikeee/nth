﻿using System;
using System.Collections.Generic;

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
    }
}
