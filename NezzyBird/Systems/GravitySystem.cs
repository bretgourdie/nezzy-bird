using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class GravitySystem : EntityProcessingSystem
    {
        public GravitySystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity)
        {
            var gravity = entity.getComponent<AffectedByGravity>();
        }
    }
}
