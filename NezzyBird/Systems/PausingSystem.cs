using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class PausingSystem : EntityProcessingSystem
    {
        public PausingSystem() : base(
            new Matcher().all(
                typeof(Pause)
            ))
        { }

        public override void process(Entity entity)
        {
            var pause = entity.getComponent<Pause>();

            pause.update();

            if (pause.TimePassed >= Pause.TotalTime)
            {
                entity.setEnabled(false);
            }
        }
    }
}
