using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Pipe : Entity
    {
        public static readonly float SCROLL_SPEED = 1f;
        public Pipe(
            TextureAtlas textureAtlas,
            VerticalDirection.MouthOpens mouthOpens)
        {
            addComponent(new VerticalDirection(textureAtlas, mouthOpens));
            addComponent(new Scrolling(Scrolling.ScrollDirection.Left, SCROLL_SPEED));
            addComponent(new Mover());
            addComponent(new EndsGameOnCollision());

            this.scale = GameConstants.GetGameScale();
        }
    }
}
