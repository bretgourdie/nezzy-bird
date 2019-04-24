namespace NezzyBird.Components
{
    public class SimpleScrolling : Scrolling
    {
        public SimpleScrolling(ScrollDirection scrollDirection, float rate) : base(scrollDirection, rate) { }

        public override void onAddedToEntity()
        {
            entity.addComponent(new CaresAboutLife());
        }
    }
}
