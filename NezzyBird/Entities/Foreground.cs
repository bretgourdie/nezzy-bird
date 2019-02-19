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
            addComponent(new Sprite(foregroundSubtexture));

            this.scale = GameConstants.GetGameScale();
            this.position = new Vector2(0, GameConstants.SOURCE_SCREEN_WIDTH);
        }
    }
}
