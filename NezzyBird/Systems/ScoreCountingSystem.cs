using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScoreCountingSystem : EntityProcessingSystem
    {
        private readonly ScoreSpriteHandler _scoreSpriteHandler;

        public ScoreCountingSystem(TextureAtlas textureAtlas) : base(
            new Matcher().all(
                typeof(ScoreCounting),
                typeof(DisplaysNumber)
            ))
        {
            _scoreSpriteHandler = new ScoreSpriteHandler(
                ScoreSpriteHandler.SpriteSize.Small,
                textureAtlas);
        }

        public override void process(Entity entity)
        {
            var scoreCounting = entity.getComponent<ScoreCounting>();
            var displaysNumber = entity.getComponent<DisplaysNumber>();

            scoreCounting.updateDisplayTime(Time.deltaTime);

            if (scoreCounting.TimeSinceLastDisplay >= scoreCounting.TimeBetweenDisplays)
            {
                scoreCounting.resetDisplayTime();

                if (scoreCounting.CurrentNumber < scoreCounting.CountTo)
                {
                    displaysNumber.OnNumberUpdated();
                    scoreCounting.CurrentNumber = displaysNumber.Number;
                }
            }

            _scoreSpriteHandler.HandleSprite(entity);
        }
    }
}
