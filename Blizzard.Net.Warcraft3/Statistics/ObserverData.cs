using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct ObserverData
    {
        public const int WAR3_STATS_MAX_PLAYERS = 28;

        public const int WAR3_STATS_REFRESH_RATE = 2000;

        public const string WAR3_STATS_MEMORY_MAPPED_FILENAME = "War3StatsObserverSharedMemory";

        public const int WAR3_STATS_GAME_SIZE = 1024;

        public const int WAR3_STATS_PLAYERINFO_SIZE = 97; // TODO: This should be 512, but is currently 97 due to an error.

        public static unsafe ObserverData* Open()
        {
            var memoryMappedFile = MemoryMappedFile.OpenExisting(WAR3_STATS_MEMORY_MAPPED_FILENAME);
            var mappedViewAccessor = memoryMappedFile.CreateViewAccessor();
            var pointer = (byte*)0;
            mappedViewAccessor.SafeMemoryMappedViewHandle.AcquirePointer(ref pointer);
            return (ObserverData*)pointer;
        }

        public class PlayersHelper : IReadOnlyList<PlayerInfo>
        {
            private readonly ObserverData observerData;

            public PlayersHelper(ObserverData observerData)
            {
                this.observerData = observerData;
            }

            public PlayerInfo this[int i]
            {
                get
                {
                    switch (i)
                    {
                        case 0:
                            return this.observerData.Player0;
                        case 1:
                            return this.observerData.Player1;
                        case 2:
                            return this.observerData.Player2;
                        case 3:
                            return this.observerData.Player3;
                        case 4:
                            return this.observerData.Player4;
                        case 5:
                            return this.observerData.Player5;
                        case 6:
                            return this.observerData.Player6;
                        case 7:
                            return this.observerData.Player7;
                        case 8:
                            return this.observerData.Player8;
                        case 9:
                            return this.observerData.Player9;
                        case 10:
                            return this.observerData.Player10;
                        case 11:
                            return this.observerData.Player11;
                        case 12:
                            return this.observerData.Player12;
                        case 13:
                            return this.observerData.Player13;
                        case 14:
                            return this.observerData.Player14;
                        case 15:
                            return this.observerData.Player15;
                        case 16:
                            return this.observerData.Player16;
                        case 17:
                            return this.observerData.Player17;
                        case 18:
                            return this.observerData.Player18;
                        case 19:
                            return this.observerData.Player19;
                        case 20:
                            return this.observerData.Player20;
                        case 21:
                            return this.observerData.Player21;
                        case 22:
                            return this.observerData.Player22;
                        case 23:
                            return this.observerData.Player23;
                        case 24:
                            return this.observerData.Player24;
                        case 25:
                            return this.observerData.Player25;
                        case 26:
                            return this.observerData.Player26;
                        case 27:
                            return this.observerData.Player27;
                    }
                    throw new ArgumentOutOfRangeException(nameof(i));
                }
            }

            public IEnumerator<PlayerInfo> GetEnumerator()
            {
                yield return this.observerData.Player0;
                yield return this.observerData.Player1;
                yield return this.observerData.Player2;
                yield return this.observerData.Player3;
                yield return this.observerData.Player4;
                yield return this.observerData.Player5;
                yield return this.observerData.Player6;
                yield return this.observerData.Player7;
                yield return this.observerData.Player8;
                yield return this.observerData.Player9;
                yield return this.observerData.Player10;
                yield return this.observerData.Player11;
                yield return this.observerData.Player12;
                yield return this.observerData.Player13;
                yield return this.observerData.Player14;
                yield return this.observerData.Player15;
                yield return this.observerData.Player16;
                yield return this.observerData.Player17;
                yield return this.observerData.Player18;
                yield return this.observerData.Player19;
                yield return this.observerData.Player20;
                yield return this.observerData.Player21;
                yield return this.observerData.Player22;
                yield return this.observerData.Player23;
                yield return this.observerData.Player24;
                yield return this.observerData.Player25;
                yield return this.observerData.Player26;
                yield return this.observerData.Player27;
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            public int Count => WAR3_STATS_MAX_PLAYERS;
        }

        /// <summary>
        /// Game client version
        /// </summary>
        [FieldOffset(0x00)]
        public readonly uint Version;

        /// <summary>
        /// Refresh rate in milliseconds
        /// </summary>
        [FieldOffset(0x04)]
        public uint RefreshRate;

        [FieldOffset(0x08)]
        public readonly ObserverGame Game;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 0 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player0;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 1 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player1;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 2 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player2;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 3 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player3;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 4 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player4;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 5 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player5;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 6 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player6;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 7 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player7;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 8 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player8;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 9 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player9;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 10 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player10;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 11 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player11;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 12 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player12;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 13 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player13;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 14 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player14;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 15 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player15;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 16 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player16;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 17 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player17;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 18 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player18;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 19 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player19;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 20 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player20;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 21 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player21;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 22 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player22;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 23 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player23;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 24 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player24;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 25 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player25;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 26 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player26;

        [FieldOffset(0x08 + WAR3_STATS_GAME_SIZE + 27 * WAR3_STATS_PLAYERINFO_SIZE)]
        public readonly PlayerInfo Player27;

        public PlayersHelper Players => new PlayersHelper(this);
    }
}
