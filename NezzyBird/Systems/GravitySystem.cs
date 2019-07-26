using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class GravitySystem : EntityProcessingSystem
    {
        private readonly float _floorY;

        public GravitySystem(Foreground foreground) :
            base(new Matcher().all(
                typeof(AffectedByGravity),
                typeof(WaitsForFirstTap),
                typeof(Mover),
                typeof(HasVelocity),
                typeof(Sprite<int>)
            ))
        {
            var foregroundSprite = foreground.getComponent<Sprite>();
            _floorY = foreground.position.Y - foregroundSprite.height / 2;
        }

        public override void process(Entity entity)
        {
            var waitsForFirstTap = entity.getComponent<WaitsForFirstTap>();

            if (!waitsForFirstTap.HasTapped)
            {
                return;
            }

            var position = entity.position;
            var sprite = entity.getComponent<Sprite<int>>();

            if (position.Y + sprite.height / 2 >= _floorY)
            {
                return;
            }

            var gravity = entity.getComponent<AffectedByGravity>();
            var mover = entity.getComponent<Mover>();
            var velocity = entity.getComponent<HasVelocity>();

            velocity.CurrentVelocity =
                new Vector2(
                    velocity.CurrentVelocity.X,
                    velocity.CurrentVelocity.Y + gravity.GravitationalPull);

            CollisionResult collisionResult;
            mover.move(velocity.CurrentVelocity, out collisionResult);
        }
    }
}
