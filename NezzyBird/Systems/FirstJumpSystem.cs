using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class FirstJumpSystem : PassiveSystem
    {
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
            var fadesOnFirstJumpComponents = scene.findComponentsOfType<FadesOnFirstJump>();

            foreach (var fadesOnFirstJump in fadesOnFirstJumpComponents)
            {
                fadesOnFirstJump.entity.removeComponent<Fades>();
                fadesOnFirstJump.entity.addComponent(fadesOnFirstJump.FirstJumpFade);
            }

            this.scene.removeEntityProcessor(this);
        }
    }
}
