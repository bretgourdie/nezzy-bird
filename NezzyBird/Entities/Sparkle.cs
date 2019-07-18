using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class Sparkle : Entity
    {
        public readonly SpriteAnimation SparkleAnimation;

        public Sparkle(TextureAtlas textureAtlas)
        {
            SparkleAnimation = textureAtlas.getSpriteAnimation("sparkle");
        }
    }
}
