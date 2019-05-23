using Nez;
using Nez.Systems;

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

            scene.removeEntityProcessor(this);
        }
    }
}
