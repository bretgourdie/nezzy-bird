using Nez;
using Nez.Sprites;

namespace NezzyBird.Components
{
    public class ParallaxScrolling : Component
    {
        public Sprite Sprite { get; private set; }
        public Sprite SecondSprite { get; private set; }
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
            Sprite = entity.getComponent<Sprite>();
            SecondSprite = new Sprite(Sprite.subtexture);
        }
    }
}
