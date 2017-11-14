using gilded_rose;
using Xunit;

namespace gilded_rose_test
{
    public class UnitTests
    {
        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 20, 9, 19)]
        [InlineData("Conjured Mana Cake", 3, 6, 2, 4)]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Elixir of the Mongoose", 5, 7, 4, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        public void BasicTest(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var items = new[] { new Item(){
                    Name= name,
                    SellIn = sellIn,
                    Quality = quality } };
            new GildedRose(items).UpdateItems();
            Assert.Equal(expectedSellIn, items[0].SellIn);
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest", 1, 0, 0, 0)]
        [InlineData("Aged Brie", 2, 50, 1, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 49, 9, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 49, 4, 50)]
        public void EdgeCasesTest(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var items = new[] { new Item(){
                    Name= name,
                    SellIn = sellIn,
                    Quality = quality } };
            new GildedRose(items).UpdateItems();
            Assert.Equal(expectedSellIn, items[0].SellIn);
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 40, 9, 42)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 40, 4, 43)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 49, -1, 0)]
        [InlineData("Conjured", 10, 10, 9, 8)]
        public void ComplexItemsTest(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var items = new[] { new Item(){
                    Name= name,
                    SellIn = sellIn,
                    Quality = quality } };
            new GildedRose(items).UpdateItems();
            Assert.Equal(expectedSellIn, items[0].SellIn);
            Assert.Equal(expectedQuality, items[0].Quality);
        }
    }
}
