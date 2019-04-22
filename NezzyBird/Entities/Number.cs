using Nez;
using Nez.Sprites;

namespace NezzyBird.Entities
{
    public class Number : Entity
    {
        public void SetSprite(Sprite sprite)
        {
            removeComponent<Sprite>();
            addComponent(sprite);
        }
    }
}
