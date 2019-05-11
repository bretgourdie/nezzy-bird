using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScrollingSystem : EntityProcessingSystem
    {
        private bool _birdIsAlive = true;

        public ScrollingSystem(Emitter<NezzyEvents> emitter) :
            base(new Matcher()
            .all(
                typeof(Mover),
                typeof(Scrolling)
            )
        )
        {
            emitter.addObserver(NezzyEvents.BirdDied, _onBirdDied);
        }

        public override void process(Entity entity)
        {
            if (!_birdIsAlive)
            {
                return;
            }

            var mover = entity.getComponent<Mover>();
            var optionalSprite = entity.getComponent<Sprite>();
            var scrolling = entity.getComponent<Scrolling>();

            var movement = determineMovement(scrolling.ScrollDirection, scrolling.Rate);

            CollisionResult collisionResult;
            mover.move(movement, out collisionResult);

            var spriteIsNullOrOffscreen = optionalSprite == null || !optionalSprite.isVisible;

            if (entity.position.X < 0 && spriteIsNullOrOffscreen)
            {
                entity.destroy();
            }
        }

        private Vector2 determineMovement(
            ScrollDirection scrollDirection,
            float rate)
        {
            switch (scrollDirection)
            {
                case ScrollDirection.Up:
                    return new Vector2(0, -rate);
                case ScrollDirection.Left:
                    return new Vector2(-rate, 0);
                case ScrollDirection.Down:
                    return new Vector2(0, rate);
                case ScrollDirection.Right:
                    return new Vector2(rate, 0);
                default:
                    throw new System.NotImplementedException();
            }
        }

        private void _onBirdDied()
        {
            _birdIsAlive = false;
        }
    }
}
