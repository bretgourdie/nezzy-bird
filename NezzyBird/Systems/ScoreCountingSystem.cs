using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScoreCountingSystem : EntityProcessingSystem
    {
        public ScoreCountingSystem() : base(
            new Matcher().all(
                typeof(ScoreCounting),
                typeof(DisplaysNumber)
            ))
        { }

        public override void process(Entity entity)
        {
            var scoreCounting = entity.getComponent<ScoreCounting>();
            var displaysNumber = entity.getComponent<DisplaysNumber>();
        }
    }
}
