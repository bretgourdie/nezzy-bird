using Nez;
using Nez.Systems;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class ScoreZoneCollisionSystem : EntityProcessingSystem
    {
        private readonly Emitter<NezzyEvents> _emitter;
        private readonly EntityProcessingSystem _collisionStrategy;

        public ScoreZoneCollisionSystem(
            Emitter<NezzyEvents> emitter) : base(
            new Matcher().all(
                typeof(HasScore),
                typeof(BoxCollider)
            )
        )
        {
            _emitter = emitter;
            _collisionStrategy = new CollisionSystem(typeof(ScoreZone), onCollision);
        }

        public override void process(Entity entity)
        {
            _collisionStrategy.process(entity);
        }

        private void onCollision(Entity entity, Collider collidedWith)
        {
            var hasScore = entity.getComponent<HasScore>();
            hasScore.Score += 1;
            collidedWith.entity.destroy();
            _emitter.emit(NezzyEvents.BirdScored);
        }
    }
}
