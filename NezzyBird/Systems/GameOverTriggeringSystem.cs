using Nez;
using Nez.Systems;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class GameOverTriggeringSystem : PassiveSystem
    {
        private bool _gameOverWasTriggered;

        public GameOverTriggeringSystem(Emitter<NezzyEvents> emitter)
        {
            emitter.addObserver(NezzyEvents.BirdDied, _handleGameOverTriggering);
        }

        private void _handleGameOverTriggering()
        {
            if (_gameOverWasTriggered)
            {
                return;
            }

            _gameOverWasTriggered = true;
            var gameOver = new GameOver(
                new ScreenFlasher(),
                new GameOverMenu());
            scene.addEntity(gameOver);
        }
    }
}
