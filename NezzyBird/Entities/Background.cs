using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

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

            var middleOfScreen = GameConstants.GetScreenBounds() / 2;
            this.setPosition(middleOfScreen);
        }
    }
}
