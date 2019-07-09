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

        public ScoreSpriteHandler(
            SpriteSize spriteSize,
            TextureAtlas textureAtlas)
        {
            _spriteSize = spriteSize;
            _textureAtlas = textureAtlas;
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
            var sampleSprite = _textureAtlas.getSubtexture($"{getSpriteSizePrefix()}0");
            var rectangle = sampleSprite.sourceRect;
            var spriteWidth = rectangle.Width;

            float startingXCoordinate;

            switch (_spriteSize)
            {
                case SpriteSize.Large:
                    startingXCoordinate = GameConstants.SCREEN_WIDTH * .5f;
                    break;
                case SpriteSize.Small:
                    startingXCoordinate = GameConstants.SCREEN_WIDTH * .5f;
                    break;
                default:
                    throw new System.NotImplementedException();
            }

            const int spritePadding = 2;
            var x =
                startingXCoordinate
                - digitPosition * spriteWidth * GameConstants.SPRITE_SCALE_FACTOR
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
                    return getMainScoreYCoordinate();
                default:
                    throw new System.NotImplementedException();
            }
        }

        private float getMainScoreYCoordinate()
        {
            const float percentageFromTopOfScreen = .10f;
            return GameConstants.SCREEN_HEIGHT * percentageFromTopOfScreen;
        }

        public enum SpriteSize
        {
            Large,
            Small
        }
    }
}
