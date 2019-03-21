using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class CaresAboutLifeSystem : EntityProcessingSystem
    {
        public CaresAboutLifeSystem() : base(
            new Matcher()
            .all(
                typeof(CaresAboutLife)
            ))
        { }

        public override void process(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
