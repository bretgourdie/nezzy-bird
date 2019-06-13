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

            fades.update(Time.deltaTime);

            var startingOpacity = _getStartingOpacity(fades.FadeDirection);
            var endingOpacity = _getEndingOpacity(fades.FadeDirection);
            var totalTime = fades.TotalTime;
            var timeElapsed = fades.TimeElapsed;

            var opacity = Mathf.lerp(startingOpacity, endingOpacity, timeElapsed / totalTime);
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
