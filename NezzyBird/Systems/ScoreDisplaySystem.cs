using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScoreDisplaySystem : EntityProcessingSystem
    {
        public ScoreDisplaySystem() : base(
            new Matcher().all(typeof(DisplaysNumber)))
        { }

        public override void process(Entity entity)
        {
            var displaysNumber = entity.getComponent<DisplaysNumber>();
            var score = displaysNumber.Number;
            throw new System.NotImplementedException();
        }
    }
}
