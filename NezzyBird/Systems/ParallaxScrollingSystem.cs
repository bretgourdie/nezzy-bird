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

            if (entity.position.X <= parallaxScrolling.LeftOffscreenAmount)
            {
                entity.position = parallaxScrolling.OriginalPosition;
            }
        }
    }
}
