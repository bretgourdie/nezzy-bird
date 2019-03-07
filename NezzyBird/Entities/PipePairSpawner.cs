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
        }

        public override void onAddedToScene()
        {
            addComponent(new ActionOnInterval(SpawnPipePair, 1.75f));
        }

        public void SpawnPipePair()
        {
            var topVerticalMargin = 147 * GameConstants.SPRITE_SCALE_FACTOR;
            var bottomVerticalMargin = GameConstants.SCREEN_HEIGHT;
            var startingYCenter = Random.random.Next(topVerticalMargin, bottomVerticalMargin);
            scene.addEntity(new PipePair(_textureAtlas, startingYCenter));
        }
    }
}
