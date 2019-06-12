using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class FadeOutSystem : EntityProcessingSystem
    {
        private bool _isFadingOut = false;

        public FadeOutSystem(Emitter<NezzyEvents> emitter) : base(
            new Matcher().all(
                typeof(Fades)
            ))
        {
            emitter.addObserver(NezzyEvents.BirdJumped, () => _isFadingOut = true);
        }

        public override void process(Entity entity)
        {
            if (!_isFadingOut)
            {
                return;
            }

            var fades = entity.getComponent<Fades>();

        }
    }
}
