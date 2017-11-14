using System;

namespace gilded_rose
{
    public abstract class ItemUpdater
    {
        private Item item;

        protected ItemUpdater(Item item)
        {
            this.item = item;
        }

        public int Quality
        {
            get
            {
                return item.Quality;
            }
            private set
            {
                item.Quality = Math.Max(0, value);
                item.Quality = Math.Min(50, item.Quality);
            }
        }

        public int SellIn
        {
            get
            {
                return item.SellIn;
            }
            private set
            {
                item.SellIn = value;
            }
        }

        public abstract void Update();

        protected void UpdateQuality(int increment = -1)
        {
            Quality += increment;
        }

        protected void UpdateSellIn(int increment = -1)
        {
            SellIn += increment;
        }
    }
}
