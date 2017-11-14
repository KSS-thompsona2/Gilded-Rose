namespace gilded_rose
{
    public class ConjuredUpdater : ItemUpdater
    {
        public ConjuredUpdater(Item item) : base(item) { }

        public override void Update()
        {
            UpdateSellIn();
            UpdateQuality(-2);
        }
    }
}
