using Nez;

namespace NezzyBird.Components
{
    public class ParallaxScrolling : Component
    {
        public readonly ScrollDirection ScrollDirection;
        public readonly float Rate;

        public ParallaxScrolling(
            ScrollDirection scrollDirection,
            float rate)
        {
            ScrollDirection = scrollDirection;
            Rate = rate;
        }
    }
}
