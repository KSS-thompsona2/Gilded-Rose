using System;
using System.Collections.Generic;
using System.Linq;

namespace gilded_rose
{
	public class GildedRose
    {
        IList<Item> Items;
        Dictionary<string, Action<Item>> itemUpdaters = new Dictionary<string, Action<Item>>(StringComparer.CurrentCultureIgnoreCase)
        {
            { "Aged Brie", AgedBrieUpdater },
            { "Backstage passes to a TAFKAL80ETC concert", BackstagePassesUpdater },
            { "Conjured", ConjuredUpdater },
            { "Sulfuras, Hand of Ragnaros", SulfurasUpdater }
        };

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private static void AgedBrieUpdater(Item item)
        {
            UpdateSellIn(item);
            UpdateQuality(item, 1);
        }

        private static void BackstagePassesUpdater(Item item)
        {
            UpdateSellIn(item);
            if (item.SellIn < 0)
            {
                UpdateQuality(item, -item.Quality);
            }
            else if (item.SellIn <= 5)
            {
                UpdateQuality(item, 3);
            }
            else if (item.SellIn <= 10)
            {
                UpdateQuality(item, 2);
            }
            else
            {
                UpdateQuality(item, 1);
            }
        }

        private static void ConjuredUpdater(Item item)
        {
            UpdateSellIn(item);
            UpdateQuality(item, -2);
        }

        private static void DefaultUpdater(Item item)
        {
            UpdateSellIn(item);
            UpdateQuality(item);
        }

        private static void SulfurasUpdater(Item item)
        {
        }

        public void UpdateItems()
        {
            foreach (Item item in Items)
            {
                Action<Item> updater = itemUpdaters.FirstOrDefault
                    (q => item.Name.StartsWith(q.Key, StringComparison.CurrentCultureIgnoreCase)).Value;
                updater = updater ?? DefaultUpdater;
                updater.Invoke(item);
            }
        }

        private static void UpdateQuality(Item item, int increment = -1)
        {
            item.Quality = Math.Max(0, item.Quality + increment);
            item.Quality = Math.Min(50, item.Quality);
        }

        private static void UpdateSellIn(Item item, int increment = -1)
        {
            item.SellIn += increment;
        }
    }
}