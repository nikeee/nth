using System;

namespace NTH
{
    public class MemoryStatus
    {
        private static MemoryStatus _current;

        public static MemoryStatus Current
        {
            get
            {
                //TODO: May call Update() on every access to the singleton?
                return _current ?? (_current = new MemoryStatus());
            }
        }

        public IntPtr TotalPhysicalMemory { get; private set; }
        public IntPtr AvailablePhysicalMemory { get; private set; }

        public IntPtr TotalVirtualMemory { get; private set; }
        public IntPtr AvailableVirtualMemory { get; private set; }

        private readonly bool _useLegacyApi;

        private MemoryStatus()
        {
            _useLegacyApi = Environment.OSVersion.Version.Major < 5;
            Update();
        }

        private void Update()
        {
            if (_useLegacyApi)
            {
                var status = default(NativeTypes.MemoryStatus);
                status.Initialize();
                NativeMethods.GlobalMemoryStatus(ref status); // TODO Exception handling
                UpdateValuesFromStatus(status);
            }
            else
            {
                var status = default(NativeTypes.MemoryStatusEx);
                status.Initialize();
                NativeMethods.GlobalMemoryStatusEx(status); // TODO Exception handling
                UpdateValuesFromStatus(status);
            }
        }

        private void UpdateValuesFromStatus(NativeTypes.MemoryStatusEx status)
        {
            TotalVirtualMemory = new IntPtr(status.TotalVirtual);
            AvailableVirtualMemory = new IntPtr(status.AvailVirtual);

            TotalPhysicalMemory = new IntPtr(status.TotalPhys);
            AvailablePhysicalMemory = new IntPtr(status.AvailPhys);
        }

        private void UpdateValuesFromStatus(NativeTypes.MemoryStatus status)
        {
            TotalVirtualMemory = new IntPtr(status.TotalVirtual);
            AvailableVirtualMemory = new IntPtr(status.AvailVirtual);

            TotalPhysicalMemory = new IntPtr(status.TotalPhys);
            AvailablePhysicalMemory = new IntPtr(status.AvailPhys);
        }
    }
}
