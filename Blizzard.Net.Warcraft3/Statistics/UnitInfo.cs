using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct UnitInfo
    {
        public const int MAX_NAME_LENGTH = 100;

        public const int MAX_BUTTON_ART_LENGTH = 100;

        public const int SIZE =
            sizeof(uint) +
            MAX_NAME_LENGTH * sizeof(byte) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            MAX_BUTTON_ART_LENGTH * sizeof(byte) +
            sizeof(byte) + sizeof(byte) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint);

        public readonly uint Id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte name[MAX_NAME_LENGTH];

        public readonly uint OwnerId;

        public readonly uint CurrentAmount;

        public readonly uint TotalAmount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_BUTTON_ART_LENGTH)]
        private fixed byte buttonArt[MAX_BUTTON_ART_LENGTH];

        private readonly byte isPeon;

        private readonly byte isFunctionalPeon;

        public readonly uint DamageDealt;

        public readonly uint DamageReceived;

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

        public bool IsPeon => this.isPeon != 0;

        public bool IsFunctionalPeon => this.isFunctionalPeon != 0;

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
