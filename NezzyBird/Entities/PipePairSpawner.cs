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
            addComponent(new ActionOnInterval(SpawnPipePair, 1.5f));
        }

        public void SpawnPipePair()
        {
            scene.addEntity(new PipePair(_textureAtlas));
        }
    }
}
