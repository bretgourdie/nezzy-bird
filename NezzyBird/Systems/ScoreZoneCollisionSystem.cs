using Nez;
using NezzyBird.Components;

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

            foreach (var collider in colliders)
            {
                CollisionResult collisionResult;
                if (entity.getComponent<Collider>().collidesWith(collider, out collisionResult))
                {
                    // Do something constructive
                    entity.destroy();
                }
            }
        }
    }
}
