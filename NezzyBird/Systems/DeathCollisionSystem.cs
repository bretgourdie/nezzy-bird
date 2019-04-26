using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class DeathCollisionSystem : EntityProcessingSystem
    {
        private readonly Emitter<NezzyEvents> _emitter;
        private readonly CollisionSystem _collisionSystem;

        public DeathCollisionSystem(Emitter<NezzyEvents> emitter) :
            base(new Matcher()
                .all(
                    typeof(HasLife),
                    typeof(BoxCollider)
                )
            )
        {
            _emitter = emitter;
            _collisionSystem = new CollisionSystem(typeof(EndsGameOnCollision));
            _collisionSystem.OnCollision += onEndGameCollision;
        }

        private void onEndGameCollision(object sender, CollisionEventArgs e)
        {
            var entity = e.Entity;

            var hasLife = entity.getComponent<HasLife>();

            if (hasLife == null)
            {
                return;
            }

            hasLife.Kill();
            _emitter.emit(NezzyEvents.BirdDied);
        }

        public override void process(Entity entity)
        {
            _collisionSystem.process(entity);
        }
    }
}
