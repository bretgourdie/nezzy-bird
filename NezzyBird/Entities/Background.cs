using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Background : Entity
    {
        public Background(TextureAtlas atlas, bool onlyUseDay = false)
        {
            string selectedBackground;

            if (onlyUseDay)
            {
                selectedBackground = "Day";
            }
            else
            {
                selectedBackground = Random.choose("Day", "Night");
            }
            var backgroundSubtexture = atlas.getSubtexture(selectedBackground);
            var backgroundSprite = new Sprite(backgroundSubtexture);
            backgroundSprite.renderLayer = GameConstants.RenderingLevels.Background;
            addComponent(backgroundSprite);

            this.scale = GameConstants.GetGameScale();

            var originalPosition = new Vector2(
                GameConstants.SOURCE_SCREEN_WIDTH,
                GameConstants.SOURCE_SCREEN_HEIGHT / 2)
                * GameConstants.GetGameScale();

            addComponent(new ParallaxScrolling(originalPosition, 6 * GameConstants.SPRITE_SCALE_FACTOR));
            addComponent(new Scrolling(ScrollDirection.Left, GameConstants.FOREGROUND_SCROLL_SPEED / 4));
            addComponent(new Mover());
            addComponent(new BoxCollider() { isTrigger = true });

            this.setPosition(originalPosition);
        }
    }
}
