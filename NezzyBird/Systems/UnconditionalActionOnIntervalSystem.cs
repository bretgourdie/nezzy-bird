using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class UnconditionalActionOnIntervalSystem : EntityProcessingSystem
    {
        private readonly EntityProcessingSystem _actionOnIntervalStrategy;

        public UnconditionalActionOnIntervalSystem(
            EntityProcessingSystem actionOnIntervalStrategy) :
            base(new Matcher()
                .all(typeof(ActionOnInterval))
                .exclude(typeof(CaresAboutLife))
            )
        {
            _actionOnIntervalStrategy = actionOnIntervalStrategy;
        }

        public override void process(Entity entity)
        {
            _actionOnIntervalStrategy.process(entity);
        }
    }
}
