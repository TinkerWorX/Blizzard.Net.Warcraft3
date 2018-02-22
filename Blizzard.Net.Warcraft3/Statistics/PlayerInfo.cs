using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
    public unsafe struct PlayerInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        private fixed byte name[36];

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
