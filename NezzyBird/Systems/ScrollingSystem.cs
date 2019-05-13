using Nez;
using Nez.Sprites;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScrollingSystem : EntityProcessingSystem
    {
        private bool _birdIsAlive = true;
        private ScrollingMovement _scrollingMovement;

        public ScrollingSystem(
            ScrollingMovement scrollingMovement,
            Emitter<NezzyEvents> emitter) :
            base(new Matcher()
            .all(
                typeof(Mover),
                typeof(Scrolling)
            )
        )
        {
            _scrollingMovement = scrollingMovement;
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

            var movement = _scrollingMovement.Convert(scrolling.ScrollDirection, scrolling.Rate);

            CollisionResult collisionResult;
            mover.move(movement, out collisionResult);

            var spriteIsNullOrOffscreen = optionalSprite == null || !optionalSprite.isVisible;

            if (entity.position.X < 0 && spriteIsNullOrOffscreen)
            {
                entity.destroy();
            }
        }

        private void _onBirdDied()
        {
            _birdIsAlive = false;
        }
    }
}
