using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class LifeSystem : EntityProcessingSystem
    {
        public LifeSystem() :
            base(
                new Matcher()
                .all(typeof(Life))
            ) { }

        public override void process(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
