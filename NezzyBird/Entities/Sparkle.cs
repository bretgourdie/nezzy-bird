using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class Sparkle : Entity
    {
        public const int SparkleAnimationKey = 0;

        public Sparkle(
            TextureAtlas textureAtlas,
            float delay)
        {
            var sparkleAnimation = textureAtlas.getSpriteAnimation("Sparkle");

            var sparkleSprite = new Sprite<int>(
                SparkleAnimationKey,
                sparkleAnimation);
            sparkleSprite.setRenderLayer(GameConstants.RenderingLevels.Sparkle);

            this.addComponent(sparkleSprite);

            this.name = this.GetType().Name + Time.time;
        }
    }
}
