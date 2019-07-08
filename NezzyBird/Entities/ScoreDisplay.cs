using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Systems;

namespace NezzyBird.Entities
{
    public class ScoreDisplay : Entity
    {
        public ScoreDisplay(
            TextureAtlas textureAtlas,
            Emitter<NezzyEvents> emitter)
        {
            var displaysNumber = new DisplaysNumber(removeAfterBirdDies: true);
            addComponent(displaysNumber);

            this.setPosition(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 4);

            this.setScale(GameConstants.SPRITE_SCALE_FACTOR);

            emitter.addObserver(NezzyEvents.BirdScored, displaysNumber.OnNumberUpdated);

            this.name = this.GetType().Name;
        }
    }
}
