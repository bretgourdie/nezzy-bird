using Nez;
using Nez.Sprites;

namespace NezzyBird.Components
{
    public class ParallaxScrolling : Scrolling
    {
        public readonly Entity Other;

        public ParallaxScrolling(
            ScrollDirection scrollDirection,
            float rate,
            Entity other) : base(scrollDirection, rate)
        {
            Other = other;
        }
    }
}
