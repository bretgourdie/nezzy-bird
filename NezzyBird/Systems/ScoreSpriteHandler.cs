using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class ScoreSpriteHandler
    {
        private readonly TextureAtlas _textureAtlas;

        private readonly NumberLocation _numberLocation;

        private readonly Rectangle _sampleRectangle;

        public ScoreSpriteHandler(
            NumberLocation numberLocation,
            TextureAtlas textureAtlas)
        {
            _numberLocation = numberLocation;
            _textureAtlas = textureAtlas;
            _sampleRectangle = getSampleSpriteRectangle();
        }

        public void HandleSprite(Entity entity)
        {
            var displaysNumber = entity.getComponent<DisplaysNumber>();

            displaysNumber.HandleUpdatedNumber();

            var score = displaysNumber.Number;

            var strScore = score.ToString();



            while (displaysNumber.NumberSpriteHoldersCount < strScore.Length)
            {
                var newNumber = new Number();
                var digitPosition = displaysNumber.NumberSpriteHoldersCount;
                newNumber.position = new Vector2(
                    getXCoordinate(digitPosition),
                    getYCoordinate());
                displaysNumber.AddNumberSpriteHolder(newNumber);
                entity.scene.addEntity(newNumber);
            }

            for (int ii = 0; ii < strScore.Length; ii++)
            {
                var digit = strScore[ii];
                var digitSubtexture = _textureAtlas.getSubtexture($"{getSpriteSizePrefix()}{digit}");
                var sprite = new Sprite(digitSubtexture);

                var reversedIndex = strScore.Length - ii - 1;
                displaysNumber.SetNumberSprite(reversedIndex, sprite);
            }
        }

        private string getSpriteSizePrefix()
        {
            switch (_numberLocation)
            {
                case NumberLocation.ScoreHUD:
                    return "l";
                case NumberLocation.PlayerScoreMedalBoard:
                case NumberLocation.HighScoreMedalBoard:
                    return "s";
                default:
                    throw new System.NotImplementedException();
            }
        }

        private float getXCoordinate(int digitPosition)
        {
            float startingXCoordinate;

            switch (_numberLocation)
            {
                case NumberLocation.ScoreHUD:
                case NumberLocation.HighScoreMedalBoard:
                    startingXCoordinate = GameConstants.SCREEN_WIDTH * .5f;
                    break;
                case NumberLocation.PlayerScoreMedalBoard:
                    startingXCoordinate = GameConstants.SCREEN_WIDTH * .75f + (_sampleRectangle.Width * GameConstants.SPRITE_SCALE_FACTOR);
                    break;
                default:
                    throw new System.NotImplementedException();
            }

            const int spritePadding = 2;
            var x =
                startingXCoordinate
                - digitPosition * (_sampleRectangle.Width * GameConstants.SPRITE_SCALE_FACTOR)
                + spritePadding;

            return x;
        }

        private float getYCoordinate()
        {
            switch (_numberLocation)
            {
                case NumberLocation.ScoreHUD:
                case NumberLocation.HighScoreMedalBoard:
                    return getMainScoreYCoordinate();
                case NumberLocation.PlayerScoreMedalBoard:
                    return getMedalBoardYCoordinate();
                default:
                    throw new System.NotImplementedException();
            }
        }

        private float getMedalBoardYCoordinate()
        {
            const float padding = 2;
            return
                GameConstants.SCREEN_HEIGHT * 0.5f
                - (_sampleRectangle.Height * GameConstants.SPRITE_SCALE_FACTOR)
                + padding;
        }

        private float getMainScoreYCoordinate()
        {
            const float percentageFromTopOfScreen = .10f;
            return GameConstants.SCREEN_HEIGHT * percentageFromTopOfScreen;
        }

        private Rectangle getSampleSpriteRectangle()
        {
            var sampleSprite = _textureAtlas.getSubtexture($"{getSpriteSizePrefix()}0");
            var rectangle = sampleSprite.sourceRect;
            return rectangle;
        }

        public enum NumberLocation
        {
            ScoreHUD,
            PlayerScoreMedalBoard,
            HighScoreMedalBoard
        }
    }
}
