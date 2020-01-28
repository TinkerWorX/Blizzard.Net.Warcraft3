using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PlayerInfo
    {
        public const int MAX_NAME_LENGTH = 36;

        public const int MAX_HEROES = 999;

        public const int MAX_STRUCTURES = 999;

        public const int MAX_UPGRADES = 999;

        public const int MAX_UNITS = 999;

        public const int MAX_UNITS_IN_QUEUE = 999;

        public const int MAX_ITEMS = 999;

        public const int MAX_UPKEEP_LEVELS = 10;

        public const int SIZE =
            MAX_NAME_LENGTH * sizeof(byte) +
            sizeof(RacePreference) +
            sizeof(RacePreference) +
            sizeof(byte) +
            sizeof(byte) +
            sizeof(byte) +
            sizeof(PlayerType) +
            sizeof(uint) +
            sizeof(PlayerGameResult) +
            sizeof(PlayerSlotState) +
            sizeof(AiDifficultyPreference) +
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
            MAX_HEROES * HeroInfo.SIZE +
            sizeof(uint) +
            MAX_STRUCTURES * StructureInfo.SIZE +
            sizeof(uint) +
            MAX_UPGRADES * UpgradeInfo.SIZE +
            sizeof(uint) +
            MAX_UNITS * UnitInfo.SIZE +
            sizeof(uint) +
            MAX_UNITS_IN_QUEUE * BuildQueueInfo.SIZE +
            sizeof(uint) +
            MAX_ITEMS * PlayerItemInfo.SIZE +
            MAX_UPKEEP_LEVELS * sizeof(uint);

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte name[MAX_NAME_LENGTH];

        public readonly RacePreference RacePreference;

        public readonly PlayerRace Race;

        public readonly byte Id;

        public readonly byte TeamIndex;

        public readonly byte TeamColor;

        public readonly PlayerType Type;

        public readonly uint Handicap;

        public readonly PlayerGameResult GameResult;

        public readonly PlayerSlotState SlotState;

        public readonly AiDifficultyPreference AiDifficulty;

        public readonly uint ActionsPerMinute;

        public readonly uint RealTimeActionsPerMinute;

        public readonly uint Gold;

        public readonly uint GoldMined;

        public readonly uint GoldUpkeepLost;

        public readonly uint GoldDiversionTax;

        public readonly uint Lumber;

        public readonly uint LumberMined;

        public readonly uint LumberUpkeepLost;

        public readonly uint LumberDiversionTax;

        public readonly uint FoodCap;

        public readonly uint FoodUsed;

        private readonly uint heroCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_HEROES * HeroInfo.SIZE)]
        private fixed byte heroes[MAX_HEROES * HeroInfo.SIZE];

        private readonly uint structureCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRUCTURES * StructureInfo.SIZE)]
        private fixed byte structures[MAX_STRUCTURES * StructureInfo.SIZE];

        private readonly uint upgradeCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_UPGRADES * UpgradeInfo.SIZE)]
        private fixed byte upgrades[MAX_UPGRADES * UpgradeInfo.SIZE];

        private readonly uint unitCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_UNITS * UnitInfo.SIZE)]
        private fixed byte units[MAX_UNITS * UnitInfo.SIZE];

        private readonly uint unitsInQueueCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_UNITS_IN_QUEUE * BuildQueueInfo.SIZE)]
        private fixed byte unitsInQueue[MAX_UNITS_IN_QUEUE * BuildQueueInfo.SIZE];

        private readonly uint itemCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ITEMS * PlayerItemInfo.SIZE)]
        private fixed byte items[MAX_ITEMS * PlayerItemInfo.SIZE];

        private fixed uint timeInUpkeep[MAX_UPKEEP_LEVELS];

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
