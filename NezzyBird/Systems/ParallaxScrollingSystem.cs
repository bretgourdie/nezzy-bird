using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ParallaxScrollingSystem : EntityProcessingSystem
    {
        public ParallaxScrollingSystem() : base(
            new Matcher().all(
                typeof(ParallaxScrolling)
            ))
        { }

        public override void process(Entity entity)
        {
            var sprite = entity.getComponent<Sprite>();
            var parallaxScrolling = entity.getComponent<ParallaxScrolling>();

            var originalPosition = parallaxScrolling.OriginalPosition;

            if (entity.position.X == originalPosition.X - sprite.width / 2)
            {
                entity.position = originalPosition;
            }
        }
    }
}
