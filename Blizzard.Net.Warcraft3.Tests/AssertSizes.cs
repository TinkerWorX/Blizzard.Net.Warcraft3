using Blizzard.Net.Warcraft3.Statistics;
using NUnit.Framework;

namespace Blizzard.Net.Warcraft3.Tests
{
    public unsafe class AssertSizes
    {
        [Test]
        public void PlayerTypeSize() => Assert.AreEqual(sizeof(PlayerType), sizeof(byte));

        [Test]
        public void RacePreferenceSize() => Assert.AreEqual(sizeof(RacePreference), sizeof(byte));

        [Test]
        public void AiDifficultyPreferenceSize() => Assert.AreEqual(sizeof(AiDifficultyPreference), sizeof(byte));

        [Test]
        public void PlayerRaceSize() => Assert.AreEqual(sizeof(PlayerRace), sizeof(byte));

        [Test]
        public void PlayerSlotStateSize() => Assert.AreEqual(sizeof(PlayerSlotState), sizeof(byte));

        [Test]
        public void BuildQueueTypeSize() => Assert.AreEqual(sizeof(BuildQueueType), sizeof(byte));

        [Test]
        public void ObserverGameSize() => Assert.AreEqual(sizeof(ObserverGame), ObserverGame.SIZE);

        [Test]
        public void AbilityInfoSize() => Assert.AreEqual(sizeof(AbilityInfo), AbilityInfo.SIZE);

        [Test]
        public void StructureInfoSize() => Assert.AreEqual(sizeof(StructureInfo), StructureInfo.SIZE);

        [Test]
        public void UpgradeInfoSize() => Assert.AreEqual(sizeof(UpgradeInfo), UpgradeInfo.SIZE);

        [Test]
        public void UnitInfoSize() => Assert.AreEqual(sizeof(UnitInfo), UnitInfo.SIZE);

        [Test]
        public void BuildQueueInfoSize() => Assert.AreEqual(sizeof(BuildQueueInfo), BuildQueueInfo.SIZE);

        [Test]
        public void ShopGoodInfoSize() => Assert.AreEqual(sizeof(ShopGoodInfo), ShopGoodInfo.SIZE);

        [Test]
        public void ShopInfoSize() => Assert.AreEqual(sizeof(ShopInfo), ShopInfo.SIZE);

        [Test]
        public void ItemInfoSize() => Assert.AreEqual(sizeof(ItemInfo), ItemInfo.SIZE);

        [Test]
        public void PlayerItemInfoSize() => Assert.AreEqual(sizeof(PlayerItemInfo), PlayerItemInfo.SIZE);

        [Test]
        public void HeroInfoSize() => Assert.AreEqual(sizeof(HeroInfo), HeroInfo.SIZE);

        [Test]
        public void PlayerInfoSize() => Assert.AreEqual(sizeof(PlayerInfo), PlayerInfo.SIZE);
    }
}