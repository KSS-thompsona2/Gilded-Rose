namespace gilded_rose
{
    public class AgedBrieUpdater : ItemUpdater
    {
        public AgedBrieUpdater(Item item) : base(item) { }

        public override void Update()
        {
            UpdateSellIn();
            UpdateQuality(1);
        }
    }
}
