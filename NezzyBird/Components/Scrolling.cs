using Nez;

namespace NezzyBird.Components
{
    public class Scrolling : Component
    {
        public readonly ScrollDirection ScrollDirection;
        public readonly float Rate;

        public Scrolling(ScrollDirection scrollDirection, float rate)
        {
            ScrollDirection = scrollDirection;
            Rate = rate;
        }
    }
}
