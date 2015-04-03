using System.Runtime.InteropServices;

namespace NTH.NativeTypes
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct MemoryStatusEx
    {
        /// <summary>Size of the structure.</summary>
        internal int structLength;
        internal int MemoryLoad;
        internal long TotalPhys;
        internal long AvailPhys;
        internal long TotalPageFile;
        internal long AvailPageFile;
        internal long TotalVirtual;
        internal long AvailVirtual;
        internal long AvailExtendedVirtual;

        internal void Initialize()
        {
            structLength = Marshal.SizeOf(typeof(MemoryStatusEx));
        }
    }
}
