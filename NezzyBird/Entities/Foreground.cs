using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Foreground : Entity
    {

        public Foreground(TextureAtlas textureAtlas)
        {
            var foregroundSubtexture = textureAtlas.getSubtexture("Foreground");
            var sprite = new Sprite(foregroundSubtexture);
            sprite.renderLayer = GameConstants.RenderingLevels.Foreground;
            addComponent(sprite);
            addComponent(new EndsGameOnCollision());
            addComponent(new BoxCollider() { isTrigger = true });
            addComponent(new Mover());
            addComponent(new Scrolling(ScrollDirection.Left, GameConstants.PIPE_SCROLL_SPEED));
            addComponent(new ParallaxScrolling());

            this.scale = GameConstants.GetGameScale();
            this.position = new Vector2(
                GameConstants.SOURCE_SCREEN_WIDTH / 2,
                GameConstants.SOURCE_SCREEN_HEIGHT - sprite.height / 8)
                * GameConstants.GetGameScale();
        }
    }
}
