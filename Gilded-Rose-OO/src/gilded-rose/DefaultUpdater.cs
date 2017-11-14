namespace gilded_rose
{
    public class DefaultUpdater : ItemUpdater
    {
        public DefaultUpdater(Item item) : base(item) { }

        public override void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }
    }
}
