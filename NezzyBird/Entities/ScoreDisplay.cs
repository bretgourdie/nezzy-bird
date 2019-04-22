using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class ScoreDisplay : Entity
    {
        public ScoreDisplay(
            TextureAtlas textureAtlas,
            HasScore hasScore)
        {
            addComponent(new DisplaysNumber(hasScore));

            this.setPosition(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 4);

            this.setScale(GameConstants.SPRITE_SCALE_FACTOR);
        }
    }
}
