using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class New : Entity
    {
        public New(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("New");
            addComponent(new Sprite(subtexture));

            this.scale = GameConstants.GetGameScale();

            const int xPad = 55;
            const int yPad = 12;

            this.setPosition(
                new Vector2(
                    GameConstants.SCREEN_WIDTH / 2 + xPad,
                    GameConstants.SCREEN_HEIGHT / 2 + yPad));

            this.name = this.GetType().Name;
        }
    }
}
