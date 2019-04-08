using Microsoft.Xna.Framework;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Pipe : Entity
    {
        public Pipe(
            TextureAtlas textureAtlas,
            VerticalDirection.MouthOpens mouthOpens)
        {
            addComponent(new VerticalDirection(textureAtlas, mouthOpens));
            addComponent(new SimpleScrolling(ScrollDirection.Left, GameConstants.PIPE_SCROLL_SPEED));
            addComponent(new Mover());
            addComponent(new EndsGameOnCollision());
            addComponent(new BoxCollider() { isTrigger = true });

            this.scale = GameConstants.GetGameScale();
            var startingX = GameConstants.SCREEN_WIDTH + 200;
            this.position = new Vector2(startingX, this.position.Y);
        }
    }
}
