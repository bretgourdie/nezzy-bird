using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ParallaxScrollingSystem : EntityProcessingSystem
    {
        private readonly ScrollingMovement _scrollingMovement;

        public ParallaxScrollingSystem(ScrollingMovement scrollingMovement) : base(
            new Matcher().all(
                typeof(ParallaxScrolling),
                typeof(Sprite)
            ))
        {
            _scrollingMovement = scrollingMovement;
        }

        public override void process(Entity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
