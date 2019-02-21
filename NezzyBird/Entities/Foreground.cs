using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

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

            this.scale = GameConstants.GetGameScale();
            this.position = new Vector2(
                GameConstants.SOURCE_SCREEN_WIDTH / 2,
                GameConstants.SOURCE_SCREEN_HEIGHT - 10)
                * GameConstants.GetGameScale();
        }
    }
}
