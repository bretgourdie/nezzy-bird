using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class LifeDependentActionOnIntervalSystem : EntityProcessingSystem
    {
        private readonly EntityProcessingSystem _actionOnIntervalStrategy;

        public LifeDependentActionOnIntervalSystem(
            EntityProcessingSystem actionOnIntervalStrategy) :
            base(new Matcher()
            .all(
                typeof(ActionOnInterval),
                typeof(CaresAboutLife))
            )
        {
            _actionOnIntervalStrategy = actionOnIntervalStrategy;
        }

        public override void process(Entity entity)
        {
            var caresAboutLife = entity.getComponent<CaresAboutLife>();

            if (caresAboutLife.ImportantLifeIsAlive)
            {
                _actionOnIntervalStrategy.process(entity);
            }
        }
    }
}
