using Nez;
using Nez.Sprites;
using NezzyBird.Components;

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
                typeof(SimpleScrolling)
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
            }
        }

        private void handleSimpleScrolling(Entity entity)
        {
            entity.destroy();
        }
    }
}
