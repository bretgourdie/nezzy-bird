using Microsoft.Xna.Framework;
using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class JumpSystem : EntityProcessingSystem
    {
        private bool _canJump = true;
        private Emitter<NezzyEvents> _emitter;

        public JumpSystem(Emitter<NezzyEvents> emitter) : base(
            new Matcher().all(
                typeof(JumpsOnTap),
                typeof(WaitsForFirstTap),
                typeof(HasVelocity)
            )
        )
        {
            _emitter = emitter;
            _emitter.addObserver(NezzyEvents.BirdDied, _onBirdDied);
        }

        public override void process(Entity entity)
        {
            if (!_canJump)
            {
                return;
            }

            var jump = entity.getComponent<JumpsOnTap>();
            var velocity = entity.getComponent<HasVelocity>();
            var waitsForFirstTap = entity.getComponent<WaitsForFirstTap>();

            if (jump.IsJumping)
            {
                velocity.CurrentVelocity = new Vector2(0, -jump.GetJumpAmount());
                waitsForFirstTap.RecordTap();
                _emitter.emit(NezzyEvents.BirdJumped);
            }
        }

        private void _onBirdDied()
        {
            _canJump = false;
        }
    }
}
