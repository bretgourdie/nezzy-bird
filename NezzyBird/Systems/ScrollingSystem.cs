using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;
using System;

namespace NezzyBird.Systems
{
    public class ScrollingSystem : EntityProcessingSystem
    {
        public ScrollingSystem() :
            base(new Matcher()
            .all(
                typeof(Mover),
                typeof(Sprite)
            )
            .one(
                typeof(SimpleScrolling),
                typeof(ParallaxScrolling)
            )) { }

        public override void process(Entity entity)
        {

            var mover = entity.getComponent<Mover>();
            var sprite = entity.getComponent<Sprite>();
            var scrolling = entity.getComponent<Scrolling>();

            CollisionResult collisionResult;
            mover.move(scrolling.Movement, out collisionResult);

            if (entity.position.X < 0 && !sprite.isVisible)
            {
                if (scrolling is SimpleScrolling)
                {
                    handleSimpleScrolling(entity);
                }

                else if (scrolling is ParallaxScrolling)
                {
                    handleParallaxScrolling(entity, (scrolling as ParallaxScrolling).Other, sprite);
                }
            }
        }

        private void handleSimpleScrolling(Entity entity)
        {
            entity.destroy();
        }

        private void handleParallaxScrolling(Entity current, Entity other, Sprite sprite)
        {
            var newPosition = other.position + new Vector2(sprite.width, sprite.height);
            current.setPosition(newPosition);
        }
    }
}
