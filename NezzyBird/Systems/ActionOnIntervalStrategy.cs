using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ActionOnIntervalStrategy : EntityProcessingSystem
    {
        public ActionOnIntervalStrategy() : base(Matcher.empty()) { }

        public override void process(Entity entity)
        {
            var actionOnInterval = entity.getComponent<ActionOnInterval>();

            if (!actionOnInterval.Active)
            {
                return;
            }

            actionOnInterval.TimeSinceLastAction += Time.deltaTime;

            if (actionOnInterval.TimeSinceLastAction >= actionOnInterval.Interval)
            {
                actionOnInterval.InvokeAction();
                actionOnInterval.TimeSinceLastAction = 0f;
            }
        }
    }
}
