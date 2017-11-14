using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace gilded_rose
{
	public class GildedRose
    {
        IList<Item> Items;
        Dictionary<string, Type> itemUpdaters = new Dictionary<string, Type>(StringComparer.CurrentCultureIgnoreCase)
        {
            { "Aged Brie", typeof(AgedBrieUpdater) },
            { "Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassUpdater) },
            { "Conjured", typeof(ConjuredUpdater) },
            { "Default", typeof(DefaultUpdater) },
            { "Sulfuras, Hand of Ragnaros", typeof(SulfurasUpdater) }
        };

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateItems()
        {
            foreach (Item item in Items)
            {
                Type updaterType = itemUpdaters.FirstOrDefault
                    (u => item.Name.StartsWith(u.Key, StringComparison.CurrentCultureIgnoreCase)).Value
                    ?? typeof(DefaultUpdater);
                ConstructorInfo updaterConstructor = updaterType.GetConstructor(new [] { typeof(Item) });
                ItemUpdater updater = (ItemUpdater)updaterConstructor.Invoke(new[] { item });
                updater.Update();
            }
        }
    }
}