using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PlayerItemInfo
    {
        public const int MAX_NAME_LENGTH = 100;

        public const int SIZE =
            sizeof(uint) +
            MAX_NAME_LENGTH * sizeof(byte) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint);

        public readonly uint Id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte name[MAX_NAME_LENGTH];

        public readonly uint ItemLevel;

        public readonly uint Collected;

        public readonly uint Purchased;

        public readonly uint Sold;

        public readonly uint Used;

        public readonly uint Destroyed;

        public readonly uint DamageDealt;

        public readonly uint HealingDone;

        public string Name
        {
            get
            {
                fixed (byte* pName = this.name)
                {
                    return Marshal.PtrToStringAnsi(new IntPtr(pName));
                }
            }
        }
    }
}
