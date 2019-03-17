using Nez;
using Nez.Sprites;

namespace NezzyBird.Components
{
    public class ParallaxScrolling : Component
    {
        public Sprite LeftMostSprite { get; private set; }
        public Sprite RightMostSprite { get; private set; }
        private ScrollDirection _scrollDirection;
        private float _rate;

        public ParallaxScrolling(
            ScrollDirection scrollDirection,
            float rate)
        {
            _scrollDirection = scrollDirection;
            _rate = rate;
        }

        public override void onAddedToEntity()
        {
            LeftMostSprite = entity.getComponent<Sprite>();
            RightMostSprite = new Sprite(LeftMostSprite.subtexture);
        }
    }
}
