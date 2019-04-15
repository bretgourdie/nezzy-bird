using Nez;
using NezzyBird.Components;
using NezzyBird.Entities;
using System.Linq;

namespace NezzyBird.Systems
{
    public class ScoreZoneCollisionSystem : EntityProcessingSystem
    {
        public ScoreZoneCollisionSystem() : base(
            new Matcher().all(
                typeof(HasScore),
                typeof(BoxCollider)
            ))
        { }

        public override void process(Entity entity)
        {
            var boxCollider = entity.getComponent<BoxCollider>();

            var colliders = Physics.boxcastBroadphaseExcludingSelf(boxCollider);

            foreach (var collider in colliders)
            {
                if (isColliding(boxCollider, collider))
                {
                    if (collider.entity is ScoreZone)
                    {
                        var hasScore = entity.getComponent<HasScore>();
                        hasScore.Score += 1;
                        collider.entity.destroy();
                    }
                }
            }
        }

        private bool isColliding(
            Collider birdCollider,
            Collider otherCollider)
        {
            CollisionResult collisionResult;
            return birdCollider.collidesWith(otherCollider, out collisionResult);
        }
    }
}
