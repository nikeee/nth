using System;
using System.Diagnostics;

namespace NTH.Analysis
{
    class Diff<T> where T : IComparable<T>
    {
        public DiffType Type { get; private set; }
        public T Content { get; private set; }

        public Diff(DiffType type, T content)
        {
            Type = type;
            Content = content;
        }

        public static Diff<T> Create(DiffType type, T content)
        {
            return new Diff<T>(type, content);
        }

        public static Diff<T>[] Create(DiffType type, T[] contents)
        {
            Debug.Assert(contents != null);

            var diffs = new Diff<T>[contents.Length];
            for (int i = 0; i < contents.Length; i++)
                diffs[i] = new Diff<T>(type, contents[i]);
            return diffs;
        }

        public override string ToString()
        {
            var dt = GetDiffTypeStringRepresentation(Type);
            return string.Concat(dt, Content);
        }

        public override int GetHashCode()
        {
            return Content.GetHashCode() ^ Type.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var d = obj as Diff<T>;
            if ((object)d == null)
                return false;
            return d.Type == Type && d.Content.CompareTo(Content) == 0;
        }

        public bool Equals(Diff<T> obj)
        {
            if (obj == null)
                return false;
            return obj.Type == Type && obj.Content.CompareTo(Content) == 0;
        }

        private static string GetDiffTypeStringRepresentation(DiffType type)
        {
            switch (type)
            {
                case DiffType.Equal:
                    return "=";
                case DiffType.Insert:
                    return "+";
                case DiffType.Delete:
                    return "-";
                default:
                    throw new ArgumentException("Invalid DiffType: " + (int)type);
            }
        }
    }
}
