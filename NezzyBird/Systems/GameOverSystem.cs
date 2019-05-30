using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class GameOverSystem : ProcessingSystem
    {
        private bool IsBirdAlive = true;

        public GameOverSystem(Emitter<NezzyEvents> emitter)
        {
            emitter.addObserver(NezzyEvents.BirdDied, () => IsBirdAlive = false);
        }

        public override void process()
        {
            if (IsBirdAlive)
            {
                return;
            }

            scene.addSceneComponent(new ScreenFlash());
            scene.removeEntityProcessor(this);
        }
    }
}
