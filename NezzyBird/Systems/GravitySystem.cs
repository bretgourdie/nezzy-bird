using Microsoft.Xna.Framework;
using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class GravitySystem : EntityProcessingSystem
    {
        public static Matcher GetMatcher()
        {
            var matcher = new Matcher();
            matcher.all(
                new System.Type[]
                {
                    typeof(AffectedByGravity),
                    typeof(Mover),
                    typeof(HasVelocity)
                });

            return matcher;
        }

        public GravitySystem() : base(GravitySystem.GetMatcher()) { }

        public override void process(Entity entity)
        {
            var gravity = entity.getComponent<AffectedByGravity>();
            var jump = entity.getComponent<JumpsOnTap>();
            var mover = entity.getComponent<Mover>();
            var velocity = entity.getComponent<HasVelocity>();

            if (jump != null)
            {
                if (jump.IsJumping)
                {
                    velocity.CurrentVelocity = new Vector2(0, -jump.GetJumpAmount());
                }
            }

            velocity.CurrentVelocity =
                new Vector2(
                    velocity.CurrentVelocity.X,
                    velocity.CurrentVelocity.Y + gravity.GravitationalPull);

            var collisionResult = new CollisionResult();
            mover.move(velocity.CurrentVelocity, out collisionResult);
        }
    }
}
