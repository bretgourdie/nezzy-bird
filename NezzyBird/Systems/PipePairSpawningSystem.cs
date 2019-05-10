using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class PipePairSpawningSystem : EntityProcessingSystem
    {
        private bool _hasBirdJumped = false;
        private bool _isBirdAlive = true;
        private readonly Emitter<NezzyEvents> _emitter;
        private readonly TextureAtlas _textureAtlas;

        public PipePairSpawningSystem(
            Emitter<NezzyEvents> emitter,
            TextureAtlas textureAtlas) :
            base(new Matcher()
            .all(
                typeof(SpawnsPipePair))
            )
        {
            _emitter = emitter;
            _emitter.addObserver(NezzyEvents.BirdJumped, _onBirdJump);
            _emitter.addObserver(NezzyEvents.BirdDied, _onBirdDied);

            _textureAtlas = textureAtlas;
        }

        public override void process(Entity entity)
        {
            if (!_hasBirdJumped)
            {
                return;
            }

            if (!_isBirdAlive)
            {
                return;
            }

            var spawnsPipePair = entity.getComponent<SpawnsPipePair>();
            spawnsPipePair.AddToTimeSinceLastSpawn(Time.deltaTime);

            if (spawnsPipePair.TimeSinceLastSpawn >= spawnsPipePair.Interval)
            {
                _spawnPipePair();
                spawnsPipePair.ResetTimeSinceLastSpawn();
            }
        }

        private void _spawnPipePair()
        {
            var topVerticalMargin = 147 * GameConstants.SPRITE_SCALE_FACTOR;
            var bottomVerticalMargin = GameConstants.SCREEN_HEIGHT;
            var startingYCenter = Random.random.Next(topVerticalMargin, bottomVerticalMargin);
            scene.addEntity(new PipePair(_textureAtlas, _emitter, startingYCenter));
        }

        private void _onBirdJump()
        {
            _hasBirdJumped = true;
        }

        private void _onBirdDied()
        {
            _isBirdAlive = false;
        }
    }
}
