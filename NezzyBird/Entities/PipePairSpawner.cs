using Nez;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class PipePairSpawner : Entity
    {
        private readonly TextureAtlas _textureAtlas;
        private readonly Scene _scene;

        public PipePairSpawner(
            TextureAtlas textureAtlas)
        {
            _textureAtlas = textureAtlas;
        }

        public void SpawnPipePair()
        {
            scene.addEntity(new PipePair(_textureAtlas));
        }
    }
}
