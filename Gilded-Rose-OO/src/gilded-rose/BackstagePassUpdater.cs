namespace gilded_rose
{
    public class BackstagePassUpdater : ItemUpdater
    {
        public BackstagePassUpdater(Item item) : base(item) { }

        public override void Update()
        {
            base.Update();
            Quality =
                    (SellIn < 0) ? 0 :
                    (SellIn <= 5) ? Quality += 3 :
                    (SellIn <= 10) ? Quality += 2 :
                    ++Quality;
        }
    }
}
