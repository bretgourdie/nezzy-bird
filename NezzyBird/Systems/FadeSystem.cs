using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class FadeSystem : EntityProcessingSystem
    {
        public readonly SpriteAlphaTestEffect _spriteAlphaTestEffect;
        public FadeSystem() : base(
            new Matcher().all(
                typeof(Fades)
            ))
        {
            _spriteAlphaTestEffect = Core.content.loadNezEffect<SpriteAlphaTestEffect>();
        }

        public override void process(Entity entity)
        {
            var fades = entity.getComponent<Fades>();
            var sprite = entity.getComponent<Sprite>();

            if (sprite.material.effect == null)
            {
                var localEffect = _spriteAlphaTestEffect.Clone();
                sprite.material.effect = localEffect;
            }

            fades.update(Time.deltaTime);

            var startingOpacity = _getStartingOpacity(fades.FadeDirection);
            var endingOpacity = _getEndingOpacity(fades.FadeDirection);

            var totalTime = fades.TotalTime;
            var timeElapsed = fades.TimeElapsed;

            var opacity = Mathf.lerp(startingOpacity, endingOpacity, timeElapsed / totalTime);

            var alphaEffect = sprite.material.effect as SpriteAlphaTestEffect;
            alphaEffect.referenceAlpha = opacity;
        }

        private float _getEndingOpacity(FadeDirection fadeDirection)
        {
            switch (fadeDirection)
            {
                case FadeDirection.In:
                    return 100f;
                case FadeDirection.Out:
                    return 0f;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private float _getStartingOpacity(FadeDirection fadeDirection)
        {
            switch (fadeDirection)
            {
                case FadeDirection.In:
                    return 0f;
                case FadeDirection.Out:
                    return 100f;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
