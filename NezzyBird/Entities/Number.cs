using Nez;
using Nez.Sprites;

namespace NezzyBird.Entities
{
    public class Number : Entity
    {
        public Number()
        {
            this.scale = GameConstants.GetGameScale();
            this.name = $"{this.GetType().Name} {Time.timeSinceSceneLoad}";
        }

        public void SetSprite(Sprite sprite)
        {
            removeComponent<Sprite>();
            addComponent(sprite);
            sprite.setRenderLayer(GameConstants.RenderingLevels.Number);
        }
    }
}
