using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class LifeDependentActionOnIntervalSystem : EntityProcessingSystem
    {
        public LifeDependentActionOnIntervalSystem() :
            base(new Matcher()
            .all(
                typeof(ActionOnInterval),
                typeof(CaresAboutLife))
            )
        { }

        public override void process(Entity entity)
        {
            var caresAboutLife = entity.getComponent<CaresAboutLife>();

            if (!caresAboutLife.ImportantLifeIsAlive)
            {
                return;
            }

            var actionOnInterval = entity.getComponent<ActionOnInterval>();

            if (!actionOnInterval.Active)
            {
                return;
            }

            actionOnInterval.TimeSinceLastAction += Time.deltaTime;

            if (actionOnInterval.TimeSinceLastAction >= actionOnInterval.Interval)
            {
                actionOnInterval.IntervalHasLapsed();
                actionOnInterval.TimeSinceLastAction = 0f;
            }
        }
    }
}
