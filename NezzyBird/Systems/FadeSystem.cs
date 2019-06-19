using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class FadeSystem : EntityProcessingSystem
    {
        public FadeSystem() : base(
            new Matcher().all(
                typeof(Fades)
            ))
        { }

        public override void process(Entity entity)
        {
            var fades = entity.getComponent<Fades>();
            var sprite = entity.getComponent<Sprite>();

            var startingOpacity = _getStartingOpacity(fades.FadeDirection);
            var endingOpacity = _getEndingOpacity(fades.FadeDirection);

            if (!fades.InitialOpacitySet)
            {
                sprite.color.A = startingOpacity;
                fades.DeclareInitialOpacitySet();
            }

            fades.update(Time.deltaTime);

            var totalTime = fades.TotalTime;
            var timeElapsed = fades.TimeElapsed;

            var opacity = (byte)Mathf.lerp(startingOpacity, endingOpacity, timeElapsed / totalTime);

            sprite.color.A = opacity;
        }

        private byte _getEndingOpacity(FadeDirection fadeDirection)
        {
            switch (fadeDirection)
            {
                case FadeDirection.In:
                    return byte.MaxValue;
                case FadeDirection.Out:
                    return byte.MinValue;
                default:
                    throw new System.NotImplementedException();
            }
        }

        private byte _getStartingOpacity(FadeDirection fadeDirection)
        {
            switch (fadeDirection)
            {
                case FadeDirection.In:
                    return byte.MinValue;
                case FadeDirection.Out:
                    return byte.MaxValue;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
