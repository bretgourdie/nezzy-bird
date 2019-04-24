using Nez;

namespace NezzyBird.Systems
{
    public class CollisionSystem : EntityProcessingSystem
    {
        public CollisionSystem() : base(Matcher.empty()) { }

        public override void process(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
