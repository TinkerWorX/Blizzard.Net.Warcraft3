using System;
using System.Runtime.InteropServices;

namespace Blizzard.Net.Warcraft3.Statistics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ShopInfo
    {
        public const int MAX_NAME_LENGTH = 100;

        public const int MAX_GOODS = 12;

        public const int SIZE = sizeof(uint) +
            MAX_NAME_LENGTH * sizeof(byte) +
            sizeof(uint) +
            sizeof(uint) +
            MAX_GOODS * ShopGoodInfo.SIZE;

        public readonly uint Id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte name[MAX_NAME_LENGTH];

        public readonly uint OwnerId;

        private readonly uint goodsCount;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NAME_LENGTH)]
        private fixed byte goods[MAX_GOODS * ShopGoodInfo.SIZE];

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

        public Span<ShopGoodInfo> Goods
        {
            get
            {
                fixed (byte* pPlayers = this.goods)
                {
                    return new Span<ShopGoodInfo>(pPlayers, (int)this.goodsCount);
                }
            }
        }
    }
}
