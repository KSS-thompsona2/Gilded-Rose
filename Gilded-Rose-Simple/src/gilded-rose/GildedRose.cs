using System;
using System.Collections.Generic;

namespace gilded_rose
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private static void UpdateItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    item.SellIn--;
                    UpdateQuality(item, 1);
                    break;

                case "Backstage passes to a TAFKAL80ETC concert":
                    item.SellIn--;
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
                    break;

                case "Sulfuras, Hand of Ragnaros":
                    break;

                default:
                    item.SellIn--;
                    if (item.Name.StartsWith("Conjured", StringComparison.CurrentCultureIgnoreCase))
                    {
                        UpdateQuality(item, -2);
                    }
                    else
                    {
                        UpdateQuality(item);
                    }
                    break;
            }

        }

        public void UpdateItems()
        {
            foreach (Item item in Items)
            {
                UpdateItem(item);
            }
        }

        private static void UpdateQuality(Item item, int increment = -1)
        {
            item.Quality = Math.Max(0, item.Quality + increment);
            item.Quality = Math.Min(50, item.Quality);
        }
    }
}