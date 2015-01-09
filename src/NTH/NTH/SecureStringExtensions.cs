using System;
using System.Security;

namespace NTH
{
    /// <summary>Some utility extensions on <typeparam name="System.Security.SecureString"/>.</summary>
    internal static class SecureStringExtensions
    {
        internal static void RemoveChar(this SecureString value)
        {
            if (value == null)
                throw new NullReferenceException();
            if (value.Length > 0)
                value.RemoveAt(value.Length - 1);
        }
    }
}
