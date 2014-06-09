﻿using System;

namespace NTH.Text
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

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
    }
}