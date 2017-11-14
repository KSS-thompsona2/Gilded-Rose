namespace gilded_rose
{
    public class BackstagePassUpdater : ItemUpdater
    {
        public BackstagePassUpdater(Item item) : base(item) { }

        public override void Update()
        {
            UpdateSellIn();
            if (SellIn < 0)
            {
                UpdateQuality(-Quality);
            }
            else if (SellIn <= 5)
            {
                UpdateQuality(3);
            }
            else if (SellIn <= 10)
            {
                UpdateQuality(2);
            }
            else
            {
                UpdateQuality(1);
            }

        }
    }
}
