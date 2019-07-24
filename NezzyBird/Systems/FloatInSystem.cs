using Microsoft.Xna.Framework;
using Nez;
using Nez.Systems;
using Nez.Tweens;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class FloatInSystem : EntityProcessingSystem
    {
        private readonly Emitter<NezzyEvents> _emitter;

        public FloatInSystem(Emitter<NezzyEvents> emitter) : base(
            new Matcher().all(
                typeof(FloatIn)
            ))
        {
            _emitter = emitter;
        }

        public override void process(Entity entity)
        {
            var floatIn = entity.getComponent<FloatIn>();

            floatIn.PassTime(Time.deltaTime);

            var start = floatIn.StartPosition;
            var end = floatIn.EndPosition;
            var timePassed = floatIn.TimePassed;
            var totalTime = floatIn.TotalTime;
            var easeType = floatIn.EaseType;

            if (!floatIn.PlayedTransitionSwoosh)
            {
                _emitter.emit(NezzyEvents.Transition);
                floatIn.PlayedTransitionSwoosh = true;
            }

            var newLerpedPosition = lerpedPosition(start, end, timePassed, totalTime, easeType);

            entity.setPosition(newLerpedPosition);

            if (timePassed >= totalTime)
            {
                entity.setPosition(end);
                entity.removeComponent<FloatIn>();
            }
        }

        private Vector2 lerpedPosition(
            Vector2 start,
            Vector2 end,
            float timePassed,
            float totalTime,
            EaseType easeType)
        {
            return new Vector2(
                lerpedCoordinate(start.X, end.X, timePassed, totalTime, easeType),
                lerpedCoordinate(start.Y, end.Y, timePassed, totalTime, easeType)
            );
        }

        private float lerpedCoordinate(
            float start,
            float end,
            float timePassed,
            float totalTime,
            EaseType easeType)
        {
            return Lerps.ease(easeType, start, end, timePassed, totalTime);
        }
    }
}
