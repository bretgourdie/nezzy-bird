using Microsoft.Xna.Framework;
using Nez;

namespace NezzyBird.Components
{
    public class ParallaxScrolling : Component
    {
        public readonly Vector2 OriginalPosition;

        public ParallaxScrolling(Vector2 originalPosition)
        {
            OriginalPosition = originalPosition;
        }
    }
}
