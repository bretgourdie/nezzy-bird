using Microsoft.Xna.Framework;
using Nez;

namespace NezzyBird.Components
{
    public class ParallaxScrolling : Component
    {
        public readonly Vector2 OriginalPosition;
        public readonly int LeftOffscreenAmount;

        public ParallaxScrolling(
            Vector2 originalPosition,
            int leftOffscreenAmount)
        {
            OriginalPosition = originalPosition;
            LeftOffscreenAmount = leftOffscreenAmount;
        }
    }
}
