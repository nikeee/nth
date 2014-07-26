using System.Runtime.InteropServices;

namespace NTH.NativeTypes
{
    internal struct MemoryStatus
    {

        /// <summary>Size of the structure.</summary>
        internal uint structLength;

        /// <summary>% used</summary>
        internal uint MemoryLoad;

        /// <summary>bytes of total ram</summary>
        internal uint TotalPhys;

        /// <summary>bytes of currently available ram</summary>
        internal uint AvailPhys;

        /// <summary>bytes in pageing (? not normally supported in Ce)</summary>
        internal uint TotalPageFile;

        /// <summary> bytes in pageing (? not normally supported in Ce)</summary>
        internal uint AvailPageFile;

        /// <summary>total virtual bytes can be used</summary>
        internal uint TotalVirtual;

        /// <summary>current virtual bytes available</summary>
        internal uint AvailVirtual;

        internal void Initialize()
        {
            structLength = (uint)Marshal.SizeOf(typeof(MemoryStatus));
        }
    }
}
