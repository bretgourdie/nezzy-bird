using Nez;
using Nez.Systems;

namespace NezzyBird.Systems
{
    public class FirstJumpSystem : PassiveSystem
    {
        private bool _sawFirstJump = false;
        private readonly Emitter<NezzyEvents> _emitter;

        public FirstJumpSystem(
            Emitter<NezzyEvents> emitter)
        {
            _emitter = emitter;
            _emitter.addObserver(NezzyEvents.BirdJumped, _handleFirstJump);
        }

        private void _handleFirstJump()
        {
            _emitter.removeObserver(NezzyEvents.BirdJumped, _handleFirstJump);
            _sawFirstJump = true;
        }
    }
}
