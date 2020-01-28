using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ObserverGame
    {
        public const int MAX_GAME_NAME_LENGTH = 256;

        public const int MAX_MAP_NAME_LENGHT = 256;

        public const int SIZE =
            sizeof(byte) +
            sizeof(uint) +
            sizeof(byte) +
            MAX_GAME_NAME_LENGTH * sizeof(byte) +
            MAX_MAP_NAME_LENGHT * sizeof(byte);

        private readonly byte isInGameByte;

        /// <summary>
        /// Game clock in milliseconds.
        /// </summary>
        private readonly uint ClockMs;

        /// <summary>
        /// Active players count.
        /// </summary>
        private readonly byte activePlayersCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_GAME_NAME_LENGTH)]
        private fixed byte gameName[MAX_GAME_NAME_LENGTH];

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_MAP_NAME_LENGHT)]
        private fixed byte mapName[MAX_MAP_NAME_LENGHT];

        /// <summary>
        /// Game active / inactive. Stats are bogus when inactive
        /// </summary>
        public bool IsInGame => this.isInGameByte != 0;

        /// <summary>
        /// Total time of current game
        /// </summary>
        public TimeSpan GameTime => TimeSpan.FromMilliseconds(this.ClockMs);

        public int NumberOfPlayers => this.activePlayersCount;

        public string GameName
        {
            get
            {
                fixed (byte* pGameName = this.gameName)
                {
                    return Marshal.PtrToStringAnsi(new IntPtr(pGameName));
                }
            }
        }

        public string MapName
        {
            get
            {
                fixed (byte* pMapName = this.mapName)
                {
                    return Marshal.PtrToStringAnsi(new IntPtr(pMapName));
                }
            }
        }
    }
}
