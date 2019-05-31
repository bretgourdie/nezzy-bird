using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScreenFlashSystem : EntityProcessingSystem
    {
        public ScreenFlashSystem() : base(
            new Matcher().all(
                typeof(ScreenFlash)
        ))
        { }

        public override void process(Entity entity)
        {
            var screenFlash = entity.getComponent<ScreenFlash>();

            screenFlash.update();

            if (screenFlash.IsFinished())
            {
                entity.setEnabled(false);
            }
        }
    }
}
