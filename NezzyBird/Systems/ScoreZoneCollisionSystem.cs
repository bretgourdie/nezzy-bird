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
                typeof(IncreasesScoreWhenPassing),
                typeof(BoxCollider)
            ))
        { }

        public override void process(Entity entity)
        {
            var increasesScoreWhenPassing = entity.getComponent<IncreasesScoreWhenPassing>();
            var boxCollider = entity.getComponent<BoxCollider>();

            var colliders = Physics.boxcastBroadphase(
                entity.getComponent<Collider>().bounds);

            var entitiesThatMatter = colliders.Where(x => x.entity is Bird);

            foreach (var collider in entitiesThatMatter)
            {
                CollisionResult collisionResult;
                if (entity.getComponent<Collider>().collidesWith(collider, out collisionResult))
                {
                    var hasScore = collider.entity.getComponent<HasScore>();

                    if (hasScore != null)
                    {
                        hasScore.Score += 1;
                    }

                    entity.destroy();
                }
            }
        }
    }
}
