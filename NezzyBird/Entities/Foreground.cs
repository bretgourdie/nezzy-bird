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
            addComponent(new Scrolling(ScrollDirection.Left, GameConstants.FOREGROUND_SCROLL_SPEED));

            var originalPosition = new Vector2(
                GameConstants.SOURCE_SCREEN_WIDTH,
                GameConstants.SOURCE_SCREEN_HEIGHT - sprite.height / 8)
                * GameConstants.GetGameScale();
            addComponent(new ParallaxScrolling(originalPosition, (int)(originalPosition.X - sprite.width / 2) ));

            this.position = originalPosition;

            this.scale = GameConstants.GetGameScale();

        }
    }
}
