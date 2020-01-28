using System;
using System.IO.MemoryMappedFiles;

namespace Blizzard.Net.Warcraft3.Statistics
{
    public class ObserverData
    {
        public const int MAX_PLAYERS = 28;

        public const int MAX_SHOPS = 999;

        private const int VERSION_OFFSET = 0;

        private const int REFRESH_RATE_OFFSET = VERSION_OFFSET + sizeof(uint);

        private const int GAME_OFFSET = REFRESH_RATE_OFFSET + sizeof(uint);

        private const int PLAYERS_OFFSET = GAME_OFFSET + ObserverGame.SIZE;

        private const int SHOPS_COUNT_OFFSET = PLAYERS_OFFSET + MAX_PLAYERS * PlayerInfo.SIZE;

        private const int SHOPS_OFFSET = SHOPS_COUNT_OFFSET + sizeof(uint);

        public const int SIZE =
            sizeof(uint) +
            sizeof(uint) +
            ObserverGame.SIZE +
            MAX_PLAYERS * PlayerInfo.SIZE +
            sizeof(uint) +
            MAX_SHOPS * ShopInfo.SIZE;

        public const int DEFAULT_REFRESH_RATE = 2000;

        public const string MEMORY_MAPPED_FILENAME = "War3StatsObserverSharedMemory";

        private readonly unsafe byte* data;

        public ObserverData()
        {
            var memoryMappedFile = MemoryMappedFile.OpenExisting(MEMORY_MAPPED_FILENAME);
            var mappedViewAccessor = memoryMappedFile.CreateViewAccessor();
            unsafe
            {
                var pointer = (byte*)0;
                mappedViewAccessor.SafeMemoryMappedViewHandle.AcquirePointer(ref pointer);
                this.data = pointer;
            }
        }

        /// <summary>
        /// Game client version
        /// </summary>
        public uint Version
        {
            get
            {
                unsafe
                {
                    return *(uint*)&this.data[VERSION_OFFSET];
                }
            }
        }

        /// <summary>
        /// Refresh rate in milliseconds
        /// </summary>
        public uint RefreshRate
        {
            get
            {
                unsafe
                {
                    return *(uint*)&this.data[REFRESH_RATE_OFFSET];
                }
            }
            set
            {
                unsafe
                {
                    *(uint*)&this.data[REFRESH_RATE_OFFSET] = value;
                }
            }
        }

        public unsafe ObserverGame* Game
        {
            get
            {
                return (ObserverGame*)&this.data[GAME_OFFSET];
            }
        }

        public Span<PlayerInfo> Players
        {
            get
            {
                unsafe
                {
                    return new Span<PlayerInfo>(&this.data[PLAYERS_OFFSET], MAX_PLAYERS);
                }
            }
        }

        public Span<ShopInfo> Shops
        {
            get
            {
                unsafe
                {
                    return new Span<ShopInfo>(&this.data[SHOPS_OFFSET], (int)*(uint*)&this.data[SHOPS_COUNT_OFFSET]);
                }
            }
        }
    }
}
