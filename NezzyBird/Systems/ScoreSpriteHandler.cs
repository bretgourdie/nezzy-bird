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

        private readonly SpriteSize _spriteSize;

        private readonly Rectangle _sampleRectangle;

        public ScoreSpriteHandler(
            SpriteSize spriteSize,
            TextureAtlas textureAtlas)
        {
            _spriteSize = spriteSize;
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
            switch (_spriteSize)
            {
                case SpriteSize.Large:
                    return "l";
                case SpriteSize.Small:
                    return "s";
                default:
                    throw new System.NotImplementedException();
            }
        }

        private float getXCoordinate(int digitPosition)
        {
            float startingXCoordinate;

            switch (_spriteSize)
            {
                case SpriteSize.Large:
                    startingXCoordinate = GameConstants.SCREEN_WIDTH * .5f;
                    break;
                case SpriteSize.Small:
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
            switch (_spriteSize)
            {
                case SpriteSize.Large:
                    return getMainScoreYCoordinate();
                case SpriteSize.Small:
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

        public enum SpriteSize
        {
            Large,
            Small
        }
    }
}
