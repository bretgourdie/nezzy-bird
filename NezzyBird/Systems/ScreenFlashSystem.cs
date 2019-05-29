using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScreenFlashSystem : ProcessingSystem
    {
        public override void process()
        {
            var screenFlash = scene.getSceneComponent<ScreenFlash>();

            if (screenFlash == null)
            {
                return;
            }

            if (screenFlash.IsFinished())
            {
                scene.removeSceneComponent<ScreenFlash>();
            }
        }
    }
}
