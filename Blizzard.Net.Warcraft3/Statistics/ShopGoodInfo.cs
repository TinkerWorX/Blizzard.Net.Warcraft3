using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ShopGoodInfo
    {
        public const int MAX_NAME_LENGTH = 100;

        public const int SIZE =
            sizeof(uint) +
            MAX_NAME_LENGTH * sizeof(byte) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(float) +
            sizeof(float);

        public readonly uint Id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte name[MAX_NAME_LENGTH];

        public readonly uint Stock;

        public readonly uint MaxStock;

        private readonly float cooldown;

        private readonly float cooldownRemaining;

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

        public readonly TimeSpan Cooldown => TimeSpan.FromSeconds(this.cooldown);

        public readonly TimeSpan CooldownRemaining => TimeSpan.FromSeconds(this.cooldownRemaining);
    }
}
