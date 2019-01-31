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
            backgroundSprite.renderLayer = 100;
            addComponent(backgroundSprite);

            this.scale = GameConstants.GetGameScale();

            var middleOfScreen = new Vector2(
                backgroundSprite.width / 2,
                backgroundSprite.height / 2);
            this.setPosition(middleOfScreen);
        }
    }
}
