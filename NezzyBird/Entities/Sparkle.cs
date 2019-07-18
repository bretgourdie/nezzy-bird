using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class Sparkle : Entity
    {
        private const int _sparkleAnimationKey = 0;
        private readonly Sprite<int> _sparkleAnimation;

        public Sparkle(TextureAtlas textureAtlas)
        {
            var sparkleAnimation = textureAtlas.getSpriteAnimation("sparkle");

            _sparkleAnimation = new Sprite<int>(
                _sparkleAnimationKey,
                sparkleAnimation);

            this.addComponent(_sparkleAnimation);
        }

        public void PlayAnimation()
        {
            _sparkleAnimation.play(_sparkleAnimationKey);
        }

        public bool IsAnimationPlaying()
        {
            return !_sparkleAnimation.isPlaying;
        }
    }
}
