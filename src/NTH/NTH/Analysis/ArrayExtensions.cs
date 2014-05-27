using System;
using System.Diagnostics;

namespace NTH.Analysis
{
    internal static class ArrayExtensions<T> where T : IComparable<T>
    {
        public static int IndexOf(T[] array, T item)
        {
            Debug.Assert(array != null);
            for (int i = 0; i < array.Length; ++i)
                if (array[i].CompareTo(item) == 0)
                    return i;
            return -1;
        }

        public static int IndexOf(T[] array, T[] items)
        {
            Debug.Assert(array != null);

            bool broke = false;
            var target = array.Length - items.Length;
            int j;

            for (int i = 0; i < target; ++i)
            {
                for (j = 0; j < items.Length; ++j)
                {
                    if (array[i + j].CompareTo(items[j]) != 0)
                    {
                        broke = true;
                        break;
                    }
                }
                if (broke)
                    broke = false;
                else if (j == items.Length - 1)
                    return i;
            }
            return -1;
        }

        public static T[] Substring(T[] array, int startIndex)
        {
            Debug.Assert(array != null);
            return Substring(array, startIndex, array.Length - startIndex);
        }

        public static T[] Substring(T[] array, int startIndex, int length)
        {
            Debug.Assert(array != null);
            var min = Math.Min(length, array.Length - startIndex);
            var newArr = new T[min];
            for (int i = startIndex; i < min + startIndex; ++i)
                newArr[i - startIndex] = array[i];
            return newArr;
        }
    }
}
