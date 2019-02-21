using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScrollingSystem : EntityProcessingSystem
    {
        public ScrollingSystem() :
            base(new Matcher().all(
                typeof(Scrolling),
                typeof(Mover)
            ))
        { }

        public override void process(Entity entity)
        {
            var scrolling = entity.getComponent<Scrolling>();
            var mover = entity.getComponent<Mover>();

            CollisionResult collisionResult;
            mover.move(scrolling.Movement, out collisionResult);
        }
    }
}
