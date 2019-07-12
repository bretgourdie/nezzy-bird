using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Components;
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

            var bird = scene.findEntity("Bird");
            var hasScore = bird.getComponent<HasScore>();

            _gameOverWasTriggered = true;

            var gameOverStateEntities = new IGameOverState[]
            {
                new ScreenFlasher(),
                new Pauser(),
                new GameOverGraphic(_textureAtlas),
                new MedalBoard(_textureAtlas),
                new ScoreCounter(hasScore.Score),
                new MedalContainer(hasScore.Score),
                new GameOverMenu(_textureAtlas)
            };

            scene.addEntity(new GameOverContainer(gameOverStateEntities));
        }
    }
}
