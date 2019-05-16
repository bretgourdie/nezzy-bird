using Microsoft.Xna.Framework;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class TitleScreenBird
    {
        public Bird GetBird(TextureAtlas textureAtlas)
        {
            var bird = new Bird(textureAtlas, onlyUseBird0: true);
            bird.position = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 3);

            return bird;
        }
    }
}
