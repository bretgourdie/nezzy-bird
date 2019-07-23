using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScoreDisplaySystem : EntityProcessingSystem
    {
        private bool _birdDied;
        private readonly ScoreSpriteHandler _scoreSpriteHandler;

        public ScoreDisplaySystem(
            Emitter<NezzyEvents> emitter,
            TextureAtlas textureAtlas) : base(
                new Matcher().all(
                    typeof(DisplaysNumber),
                    typeof(DisplaysCurrentScore)
            ))
        {
            emitter.addObserver(NezzyEvents.BirdDied, () => _birdDied = true);
            _scoreSpriteHandler =
                new ScoreSpriteHandler(
                    ScoreSpriteHandler.NumberLocation.ScoreHUD,
                    textureAtlas);
        }

        public override void process(Entity entity)
        {
            var displaysNumber = entity.getComponent<DisplaysNumber>();

            if (_birdDied && displaysNumber.RemoveAfterBirdDies)
            {
                entity.destroy();
                return;
            }


            if (!displaysNumber.NumberNeedsToBeUpdated)
            {
                return;
            }

            _scoreSpriteHandler.HandleSprite(entity);
        }
    }
}
