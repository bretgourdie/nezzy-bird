using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class SparkleSystem : EntityProcessingSystem
    {
        public SparkleSystem() : base(
            new Matcher().all(
                typeof(SparklesCollection)
        ))
        { }

        public override void process(Entity entity)
        {
            var sparkleCollection = entity.getComponent<SparklesCollection>();

            foreach(var sparkle in sparkleCollection)
            {
                if (!sparkle.IsAnimationPlaying())
                {
                    sparkle.PlayAnimation();
                }
            }
        }
    }
}
