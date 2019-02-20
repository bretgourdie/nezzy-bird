using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScrollingSystem : EntityProcessingSystem
    {
        public ScrollingSystem() :
            base(new Matcher().all(
                typeof(Scrolling)
            ))
        { }

        public override void process(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
