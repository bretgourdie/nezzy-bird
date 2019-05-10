using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class LifeDependentActionOnIntervalSystem : EntityProcessingSystem
    {
        private bool _hasBirdJumped = false;

        public LifeDependentActionOnIntervalSystem(Emitter<NezzyEvents> emitter) :
            base(new Matcher()
            .all(
                typeof(ActionOnInterval),
                typeof(CaresAboutLife))
            )
        {
            emitter.addObserver(NezzyEvents.BirdJumped, _onBirdJump);
        }

        public override void process(Entity entity)
        {
            if (!_hasBirdJumped)
            {
                return;
            }

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

        private void _onBirdJump()
        {
            _hasBirdJumped = true;
        }
    }
}
