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

            CollisionResult collisionResult;
            mover.move(scrolling.Movement, out collisionResult);

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
