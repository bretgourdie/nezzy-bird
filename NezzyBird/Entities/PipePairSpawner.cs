using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Systems;

namespace NezzyBird.Entities
{
    public class PipePairSpawner : Entity
    {
        private readonly TextureAtlas _textureAtlas;
        private readonly Emitter<NezzyEvents> _emitter;

        public PipePairSpawner(
            TextureAtlas textureAtlas,
            Emitter<NezzyEvents> emitter)
        {
            _textureAtlas = textureAtlas;
            _emitter = emitter;

            var caresAboutLife = new CaresAboutLife();
            _emitter.addObserver(NezzyEvents.BirdDied, caresAboutLife.OnDeath);
            addComponent(caresAboutLife);
        }

        public override void onAddedToScene()
        {
            var actionOnInterval = new ActionOnInterval(1.75f);
            actionOnInterval.OnIntervalLapsed += SpawnPipePair;
            addComponent(actionOnInterval);
        }

        public void SpawnPipePair(object sender, System.EventArgs e)
        {
            var topVerticalMargin = 147 * GameConstants.SPRITE_SCALE_FACTOR;
            var bottomVerticalMargin = GameConstants.SCREEN_HEIGHT;
            var startingYCenter = Random.random.Next(topVerticalMargin, bottomVerticalMargin);
            scene.addEntity(new PipePair(_textureAtlas, _emitter, startingYCenter));
        }
    }
}
