using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ItemInfo
    {
        public const int MAX_NAME_LENGTH = 100;

        public const int MAX_BUTTON_ART_LENGTH = 100;

        public const int SIZE =
            sizeof(uint) +
            MAX_NAME_LENGTH * sizeof(byte) +
            sizeof(uint) +
            sizeof(uint) +
            MAX_BUTTON_ART_LENGTH * sizeof(byte);

        public readonly uint Id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte name[MAX_NAME_LENGTH];

        public readonly uint Slot;

        public readonly uint Charges;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_BUTTON_ART_LENGTH)]
        private fixed byte buttonArt[MAX_BUTTON_ART_LENGTH];

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

        public string ButtonArt
        {
            get
            {
                fixed (byte* pButtonArt = this.buttonArt)
                {
                    return Marshal.PtrToStringAnsi(new IntPtr(pButtonArt));
                }
            }
        }
    }
}
