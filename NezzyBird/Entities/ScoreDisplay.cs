using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;
using System;

namespace NezzyBird.Entities
{
    public class ScoreDisplay : Entity
    {
        public Action OnScoreUpdated { get; private set; }

        public ScoreDisplay(
            TextureAtlas textureAtlas)
        {
            var displaysNumber = new DisplaysNumber();
            addComponent(displaysNumber);

            this.setPosition(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 4);

            this.setScale(GameConstants.SPRITE_SCALE_FACTOR);

            OnScoreUpdated = displaysNumber.OnNumberUpdated;
        }
    }
}
