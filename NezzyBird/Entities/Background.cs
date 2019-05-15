using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Background : Entity
    {
        public Background(TextureAtlas atlas)
        {
            var selectedBackground = Random.choose("Day", "Night");
            var backgroundSubtexture = atlas.getSubtexture(selectedBackground);
            var backgroundSprite = new Sprite(backgroundSubtexture);
            backgroundSprite.renderLayer = GameConstants.RenderingLevels.Background;
            addComponent(backgroundSprite);

            this.scale = GameConstants.GetGameScale();

            var originalPosition = new Vector2(
                GameConstants.SOURCE_SCREEN_WIDTH,
                GameConstants.SOURCE_SCREEN_HEIGHT / 2)
                * GameConstants.GetGameScale();

            addComponent(new ParallaxScrolling(originalPosition));
            addComponent(new Scrolling(ScrollDirection.Left, GameConstants.PIPE_SCROLL_SPEED));
            addComponent(new Mover());
            addComponent(new BoxCollider() { isTrigger = true });

            this.setPosition(originalPosition);
        }
    }
}
