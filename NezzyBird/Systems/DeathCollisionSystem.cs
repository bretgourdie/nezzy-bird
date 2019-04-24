using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class DeathCollisionSystem : EntityProcessingSystem
    {
        private readonly Emitter<NezzyEvents> _emitter;

        public DeathCollisionSystem(Emitter<NezzyEvents> emitter) :
            base(new Matcher()
                .all(
                    typeof(EndsGameOnCollision),
                    typeof(BoxCollider)
                )
            )
        {
            _emitter = emitter;
        }

        public override void process(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
