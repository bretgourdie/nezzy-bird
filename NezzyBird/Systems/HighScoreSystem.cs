using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;
using System.IO;

namespace NezzyBird.Systems
{
    public class HighScoreSystem : EntityProcessingSystem
    {
        private const string _highScoreFileName = "HighScore.txt";

        private readonly ScoreSpriteHandler _scoreSpriteHandler;

        public HighScoreSystem(TextureAtlas textureAtlas) : base(
            new Matcher().all(
                typeof(HighScoreContainer),
                typeof(DisplaysNumber)
            ))
        {
            _scoreSpriteHandler = new ScoreSpriteHandler(
                ScoreSpriteHandler.NumberLocation.HighScoreMedalBoard,
                textureAtlas);
        }

        public override void process(Entity entity)
        {
            var hs = entity.getComponent<HighScoreContainer>();
            _handleHighScoreContainer(hs);

            var dn = entity.getComponent<DisplaysNumber>();
            _handleDisplaysNumber(dn, entity, hs.HighScore);
        }

        private void _handleDisplaysNumber(DisplaysNumber dn, Entity entity, int highScore)
        {
            if (dn.Number != highScore)
            {
                dn.Number = highScore;
                dn.NumberNeedsToBeUpdated = true;
                _scoreSpriteHandler.HandleSprite(entity);
            }
        }

        private void _handleHighScoreContainer(HighScoreContainer hs)
        {
            if (hs.IsHighScoreRetrieved && hs.WasHighScoreWritten)
            {
                return;
            }

            if (!hs.IsHighScoreRetrieved)
            {
                var highScore = _retrieveScore();
                hs.SetHighScore(highScore);
            }

            if (!hs.WasHighScoreWritten)
            {
                _setScore(hs);
                hs.WasHighScoreWritten = true;
            }
        }

        private int _retrieveScore()
        {
            var highScoreFileText = File.ReadAllText(_highScoreFileName);

            int highScore;
            if (int.TryParse(highScoreFileText, out highScore))
            {
                return highScore;
            }
            else
            {
                return 0;
            }
        }

        private void _setScore(HighScoreContainer hs)
        {
            if (hs.PlayerScore <= hs.HighScore)
            {
                return;
            }

            hs.SetHighScore(hs.PlayerScore);
            hs.WasNewHighScore = true;

            File.WriteAllText(_highScoreFileName, hs.HighScore.ToString());
        }
    }
}
