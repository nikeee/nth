using System;
using System.Text;

namespace NTH.Text
{
    public static class StringExtensions
    {
        #region is-something

        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value.Length == 0;
        }
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null)
                return true;

            for (int i = 0; i < value.Length; ++i)
                if (!char.IsWhiteSpace(value[i]))
                    return false;
            return true;
        }
        public static bool IsNullOrDBNull(this string value)
        {
            if (value == null)
                return true;

            if (DBNull.Value.Equals(value))
                return true;

            return value.GetTypeCode() == TypeCode.DBNull;
        }

        #endregion

        public static string StripWhiteSpace(this string value)
        {
            if (value == null)
                return null;
            if (value.Length == 0 || value.Trim().Length == 0)
                return string.Empty;
            var sb = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; ++i)
                if (!char.IsWhiteSpace(value[i]))
                    sb.Append(value[i]);
            return sb.ToString();
        }

        #region ensure

        public static string EnsureWrappingStrings(this string value, string prefix, string suffix)
        {
            return value.EnsurePrefix(prefix).EnsureSuffix(suffix);
        }

        public static string EnsureQuotes(this string value)
        {
            return value.EnsureWrappingStrings("\"", "\"");
        }

        #region ensure prefix

        public static string EnsurePrefix(this string value, string prefix)
        {
            return value.EnsurePrefix(prefix, StringComparison.Ordinal);
        }
        public static string EnsurePrefix(this string value, string prefix, StringComparison comparison)
        {
            if (string.IsNullOrEmpty(value))
                return prefix;
            if (value.IndexOf(prefix, comparison) != 0)
                return string.Concat(prefix, value);
            return value;
        }

        #endregion
        #region ensure suffix

        public static string EnsureSuffix(this string value, string suffix)
        {
            return value.EnsureSuffix(suffix, StringComparison.Ordinal);
        }
        public static string EnsureSuffix(this string value, string suffix, StringComparison comparison)
        {
            if (string.IsNullOrEmpty(value))
                return suffix;
            if (!value.EndsWith(suffix, comparison))
                return string.Concat(value, suffix);
            return value;
        }

        #endregion

        #endregion

        public static bool Contains(this string str, string value, StringComparison comparisonType)
        {
            return str.IndexOf(value, comparisonType) > -1;
        }

        #region levenshtein

        public static int LevenshteinDistanceTo(this string source, string target)
        {
            return source.LevenshteinDistanceTo(target, LevenshteinMethod.Default);
        }
        public static int LevenshteinDistanceTo(this string source, string target, LevenshteinMethod method)
        {
            switch (method)
            {
                case LevenshteinMethod.Matrix:
                    return LevenshteinCalculator.CalculateMatrix(source, target);
                case LevenshteinMethod.Vector:
                    return LevenshteinCalculator.CalculateVector(source, target);
                case LevenshteinMethod.Recursive:
                    return LevenshteinCalculator.CalculateRecursive(source, target);
                case LevenshteinMethod.Damerau:
                    return new DamerauLevenshteinDistanceMetric().GetDistance(source, target, -1); // May change to static call here, seperating each method to a seperate static class
                default:
                    throw new ArgumentException("Invalid method.");
            }
        }

        #endregion
    }
}
