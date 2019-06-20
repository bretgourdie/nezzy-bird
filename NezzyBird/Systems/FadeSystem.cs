using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class FadeSystem : EntityProcessingSystem
    {
        private readonly Color _opaque = Color.White;

        public FadeSystem() : base(
            new Matcher().all(
                typeof(Fades)
            ))
        { }

        public override void process(Entity entity)
        {
            var fades = entity.getComponent<Fades>();
            var sprite = entity.getComponent<Sprite>();

            var startingColor = _getStartingColor(fades.FadeDirection);
            var endingColor = _getEndingColor(fades.FadeDirection);

            fades.update(Time.deltaTime);

            var totalTime = fades.TotalTime;
            var timeElapsed = fades.TimeElapsed;

            var lerpedColor = Color.Lerp(startingColor, endingColor, timeElapsed / totalTime);

            sprite.color = lerpedColor;
        }

        private Color _getStartingColor(FadeDirection fadeDirection)
        {
            switch (fadeDirection)
            {
                case FadeDirection.In:
                    return Color.Transparent;
                case FadeDirection.Out:
                    return _opaque;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private Color _getEndingColor(FadeDirection fadeDirection)
        {
            switch (fadeDirection)
            {
                case FadeDirection.In:
                    return _opaque;
                case FadeDirection.Out:
                    return Color.Transparent;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
