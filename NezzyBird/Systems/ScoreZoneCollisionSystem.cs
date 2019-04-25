using Nez;
using Nez.Systems;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class ScoreZoneCollisionSystem : EntityProcessingSystem
    {
        private readonly Emitter<NezzyEvents> _emitter;
        private readonly CollisionSystem _collisionSystem;

        public ScoreZoneCollisionSystem(
            Emitter<NezzyEvents> emitter) : base(
            new Matcher().all(
                typeof(HasScore),
                typeof(BoxCollider)
            )
        )
        {
            _emitter = emitter;
            _collisionSystem = new CollisionSystem(typeof(ScoreZone));
            _collisionSystem.OnCollision += _collisionSystem_OnCollision;
        }

        private void _collisionSystem_OnCollision(object sender, CollisionEventArgs e)
        {
            var entity = e.Entity;
            var hasScore = entity.getComponent<HasScore>();
            hasScore.Score += 1;
            _emitter.emit(NezzyEvents.BirdScored);

            var collidedWith = e.CollidedWith;
            collidedWith.entity.destroy();
        }

        public override void process(Entity entity)
        {
            _collisionSystem.process(entity);
        }
    }
}
