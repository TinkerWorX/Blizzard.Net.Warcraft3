using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct AbilityInfo
    {
        public const int MAX_NAME_LENGTH = 36;

        public const int MAX_BUTTON_ART_LENGTH = 100;

        public const int SIZE =
            sizeof(uint) +
            MAX_NAME_LENGTH * sizeof(byte) +
            sizeof(float) +
            sizeof(float) +
            sizeof(uint) +
            MAX_BUTTON_ART_LENGTH * sizeof(byte) +
            sizeof(byte) +
            sizeof(uint) +
            sizeof(uint);

        public readonly uint Id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte name[MAX_NAME_LENGTH];

        private readonly float cooldown;

        private readonly float cooldownRemaining;

        public readonly uint Level;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_BUTTON_ART_LENGTH)]
        private fixed byte buttonArt[MAX_BUTTON_ART_LENGTH];

        private readonly byte isHeroAbility;

        /// <summary>
        /// Total damage dealt.
        /// </summary>
        public readonly uint DamageDealt;

        /// <summary>
        /// Total healing done.
        /// </summary>
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

        public readonly TimeSpan Cooldown => TimeSpan.FromSeconds(this.cooldown);

        public readonly TimeSpan CooldownRemaining => TimeSpan.FromSeconds(this.cooldownRemaining);

        /// <summary>
        /// Location of the ability's button art.
        /// </summary>
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

        public bool IsHeroAbility => this.isHeroAbility != 0;
    }
}
