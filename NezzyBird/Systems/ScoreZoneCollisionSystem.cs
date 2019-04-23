using Nez;
using Nez.Systems;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class ScoreZoneCollisionSystem : EntityProcessingSystem
    {
        private readonly Emitter<NezzyEvents> _emitter;

        public ScoreZoneCollisionSystem(
            Emitter<NezzyEvents> emitter) : base(
            new Matcher().all(
                typeof(HasScore),
                typeof(BoxCollider)
            )
        )
        {
            _emitter = emitter;
        }

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
                        _emitter.emit(NezzyEvents.BirdScored);
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
