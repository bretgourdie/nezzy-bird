using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class Sparkle : Entity
    {
        public const int SparkleAnimationKey = 0;

        public Sparkle(TextureAtlas textureAtlas)
        {
            var sparkleAnimation = textureAtlas.getSpriteAnimation("Sparkle");

            sparkleAnimation.setLoop(false);
            sparkleAnimation.setPingPong(true);
            sparkleAnimation.setFps(8);

            var sparkleSprite = new Sprite<int>(
                SparkleAnimationKey,
                sparkleAnimation);
            sparkleSprite.setRenderLayer(GameConstants.RenderingLevels.Sparkle);

            this.addComponent(sparkleSprite);

            this.name = this.GetType().Name + Time.time;
        }
    }
}
