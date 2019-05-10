using Microsoft.Xna.Framework;
using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Systems;

namespace NezzyBird.Entities
{
    public class Pipe : Entity
    {
        public Pipe(
            TextureAtlas textureAtlas,
            Emitter<NezzyEvents> emitter,
            VerticalDirection.MouthOpens mouthOpens)
        {
            addComponent(new VerticalDirection(textureAtlas, mouthOpens));
            addComponent(
                new Scrolling(
                    ScrollDirection.Left,
                    GameConstants.PIPE_SCROLL_SPEED));
            addComponent(new Mover());
            addComponent(new EndsGameOnCollision());
            addComponent(new BoxCollider() { isTrigger = true });

            this.scale = GameConstants.GetGameScale();
            var startingX = GameConstants.SCREEN_WIDTH + 200;
            this.position = new Vector2(startingX, this.position.Y);
        }
    }
}
