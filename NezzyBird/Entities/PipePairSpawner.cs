using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class PipePairSpawner : Entity
    {
        private readonly TextureAtlas _textureAtlas;

        public PipePairSpawner(
            TextureAtlas textureAtlas)
        {
            _textureAtlas = textureAtlas;
            addComponent(new CaresAboutLife());
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
            scene.addEntity(new PipePair(_textureAtlas, startingYCenter));
        }
    }
}
