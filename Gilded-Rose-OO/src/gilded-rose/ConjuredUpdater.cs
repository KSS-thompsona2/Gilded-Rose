namespace gilded_rose
{
    public class ConjuredUpdater : ItemUpdater
    {
        public ConjuredUpdater(Item item) : base(item) { }

        public override void Update()
        {
            base.Update();
            Quality -= 2;
        }
    }
}
