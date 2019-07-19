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
            var sparkleAnimation = textureAtlas.getSpriteAnimation("sparkle");

            var sparkleSprite = new Sprite<int>(
                SparkleAnimationKey,
                sparkleAnimation);

            sparkleSprite.getAnimation(SparkleAnimationKey).delay = delay;

            this.addComponent(sparkleSprite);
        }
    }
}
