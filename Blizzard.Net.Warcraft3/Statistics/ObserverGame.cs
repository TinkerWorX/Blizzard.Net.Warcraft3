using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ObserverGame
    {
        private readonly byte isInGameByte;

        /// <summary>
        /// Game clock in milliseconds
        /// </summary>
        private readonly uint ClockMs;

        /// <summary>
        /// Active players count
        /// </summary>
        private readonly byte activePlayersCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        private fixed byte gameName[256];

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        private fixed byte mapName[256];

        /// <summary>
        /// Game active / inactive. Stats are bogus when inactive
        /// </summary>
        public bool IsInGame => this.isInGameByte != 0;

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
