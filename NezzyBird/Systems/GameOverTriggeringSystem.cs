using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class GameOverTriggeringSystem : PassiveSystem
    {
        private bool _gameOverWasTriggered;
        private readonly TextureAtlas _textureAtlas;

        public GameOverTriggeringSystem(
            Emitter<NezzyEvents> emitter,
            TextureAtlas textureAtlas)
        {
            emitter.addObserver(NezzyEvents.BirdDied, _handleGameOverTriggering);
            _textureAtlas = textureAtlas;
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
                new GameOverMenu(_textureAtlas));
            scene.addEntity(gameOver);
        }
    }
}
