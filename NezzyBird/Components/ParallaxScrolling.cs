using Nez;
using Nez.Sprites;

namespace NezzyBird.Components
{
    public class ParallaxScrolling : Component
    {
        public readonly ScrollDirection ScrollDirection;
        public readonly float Rate;
        public Sprite[] ParallaxSprites { get; set; }

        public ParallaxScrolling(
            ScrollDirection scrollDirection,
            float rate)
        {
            ScrollDirection = scrollDirection;
            Rate = rate;
        }
    }
}
