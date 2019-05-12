using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ParallaxScrollingSystem : EntityProcessingSystem
    {
        public ParallaxScrollingSystem() : base(
            new Matcher().all(
                typeof(ParallaxScrolling)
            ))
        { }

        public override void process(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
