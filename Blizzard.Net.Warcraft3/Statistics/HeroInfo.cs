using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct HeroInfo
    {
        public const int MAX_NAME_LENGTH = 100;

        public const int MAX_BUTTON_ART_LENGTH = 100;

        public const int MAX_ABILITIES = 24;

        public const int MAX_ITEMS = 6;

        public const int SIZE =
            sizeof(uint) +
            MAX_NAME_LENGTH * sizeof(byte) +
            MAX_BUTTON_ART_LENGTH * sizeof(byte) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            sizeof(uint) +
            MAX_ABILITIES * AbilityInfo.SIZE +
            sizeof(uint) +
            MAX_ITEMS * ItemInfo.SIZE;

        public readonly uint Id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte name[MAX_NAME_LENGTH];

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_BUTTON_ART_LENGTH)]
        private fixed byte buttonArt[MAX_BUTTON_ART_LENGTH];

        public readonly uint Level;

        public readonly uint Experience;

        public readonly uint LevelUpExperience;

        public readonly uint HitPoints;

        public readonly uint MaxHitPoints;

        public readonly uint ManaPoints;

        public readonly uint MaxManaPoints;

        public readonly uint DamageDealt;

        public readonly uint DamageReceived;

        public readonly uint SelfDamage;

        public readonly uint PickOrder;

        public readonly uint HealingDone;

        public readonly uint NumberOfDeaths;

        public readonly uint TotalKills;

        public readonly uint SelfKills;

        public readonly uint HeroKills;

        public readonly uint BuildingKills;

        private readonly uint timeAliveMilliSeconds;

        private readonly uint abilityCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ABILITIES * AbilityInfo.SIZE)]
        private fixed byte abilities[MAX_ABILITIES * AbilityInfo.SIZE];

        private readonly uint itemCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ITEMS * ItemInfo.SIZE)]
        private fixed byte items[MAX_ITEMS * ItemInfo.SIZE];

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

        public Span<AbilityInfo> Abilities
        {
            get
            {
                fixed (byte* pAbilities = this.abilities)
                {
                    return new Span<AbilityInfo>(pAbilities, (int)this.abilityCount);
                }
            }
        }

        public Span<ItemInfo> Items
        {
            get
            {
                fixed (byte* pItems = this.items)
                {
                    return new Span<ItemInfo>(pItems, (int)this.itemCount);
                }
            }
        }
    }
}
