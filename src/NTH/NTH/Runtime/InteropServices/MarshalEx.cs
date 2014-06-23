using System;
using System.Runtime.InteropServices;

namespace NTH.Runtime.InteropServices
{
    public static class MarshalEx
    {
        public static IntPtr AllocStructGlobal<T>()
            where T : struct
        {
            return AllocStructGlobal<T>(1);
        }
        public static IntPtr AllocStructGlobal<T>(int count)
        {
            if (count < 1)
                throw new ArgumentException("Invalid struct count");

            int size = Marshal.SizeOf(typeof(T));
            return Marshal.AllocHGlobal(size * count);
        }

        public static void FreeStructGlobal<T>(IntPtr hglobal)
        {
            Marshal.FreeHGlobal(hglobal);
        }

        public static void StructureToPtr<T>(T structure, IntPtr ptr, bool fDeleteOld)
            where T : struct
        {
            Marshal.StructureToPtr(structure, ptr, fDeleteOld);
        }

        public static void DestroyStructure<T>(IntPtr ptr)
            where T : struct
        {
            Marshal.DestroyStructure(ptr, typeof(T));
        }
    }
}
