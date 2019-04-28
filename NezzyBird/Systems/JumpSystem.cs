using Microsoft.Xna.Framework;
using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class JumpSystem : EntityProcessingSystem
    {
        private bool _canJump = true;

        public JumpSystem(Emitter<NezzyEvents> emitter) : base(
            new Matcher().all(typeof(JumpsOnTap)))
        {
            emitter.addObserver(NezzyEvents.BirdDied, _onBirdDied);
        }

        public override void process(Entity entity)
        {
            if (!_canJump)
            {
                return;
            }

            var jump = entity.getComponent<JumpsOnTap>();
            var velocity = entity.getComponent<HasVelocity>();

            if (jump.IsJumping)
            {
                velocity.CurrentVelocity = new Vector2(0, -jump.GetJumpAmount());
            }
        }

        private void _onBirdDied()
        {
            _canJump = false;
        }
    }
}
