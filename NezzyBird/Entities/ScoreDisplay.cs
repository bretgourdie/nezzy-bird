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

            this.setPosition(0, GameConstants.SCREEN_HEIGHT / .25f);
        }
    }
}
