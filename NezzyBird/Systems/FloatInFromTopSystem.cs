using Microsoft.Xna.Framework;
using Nez;
using Nez.Tweens;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class FloatInFromTopSystem : EntityProcessingSystem
    {
        public FloatInFromTopSystem() : base(
            new Matcher().all(
                typeof(FloatInFromTop)
            ))
        { }

        public override void process(Entity entity)
        {
            var floatInFromTop = entity.getComponent<FloatInFromTop>();

            floatInFromTop.PassTime(Time.deltaTime);

            var startY = floatInFromTop.StartPosition.Y;
            var endY = floatInFromTop.EndPosition.Y;
            var timePassed = floatInFromTop.TimePassed;
            var totalTime = floatInFromTop.TotalTime;
            var easeType = floatInFromTop.EaseType;

            var newY = Lerps.ease(easeType, startY, endY, timePassed, totalTime);

            var currentX = entity.position.X;

            entity.setPosition(
                new Vector2(
                    currentX,
                    newY)
            );

            if (timePassed >= totalTime)
            {
                entity.removeComponent<FloatInFromTop>();
            }
        }
    }
}
