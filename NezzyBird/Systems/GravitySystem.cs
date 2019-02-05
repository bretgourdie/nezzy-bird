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
                    typeof(JumpsOnTap),
                    typeof(Mover)
                });

            return matcher;
        }

        public GravitySystem() : base(GravitySystem.GetMatcher()) { }

        public override void process(Entity entity)
        {
            var gravity = entity.getComponent<AffectedByGravity>();
            var jump = entity.getComponent<JumpsOnTap>();
            var mover = entity.getComponent<Mover>();

            var velocity = new Vector2();
            velocity.Y = gravity.GravitationalPull - jump.GetJumpAmount();

            CollisionResult collisionResult;
            mover.move(velocity, out collisionResult);
        }
    }
}
