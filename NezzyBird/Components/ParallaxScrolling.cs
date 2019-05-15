using Nez;
using Nez.Sprites;

namespace NezzyBird.Components
{
    public class ParallaxScrolling : Component
    {
        public readonly Entity OtherEntity;
        public Sprite OtherSprite => OtherEntity.getComponent<Sprite>();

        public ParallaxScrolling()
        {
            OtherEntity = new Entity();
        }

        public override void onAddedToEntity()
        {
            entity.scene.addEntity(OtherEntity);
        }

        public void AddSprite(Sprite sprite)
        {
            OtherEntity.addComponent(sprite);
        }
    }
}
