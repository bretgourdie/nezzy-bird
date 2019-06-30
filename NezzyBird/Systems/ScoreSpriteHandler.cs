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

            var spriteSizePrefix = getSpriteSizePrefix(_spriteSize);

            var sampleSprite = _textureAtlas.getSubtexture($"{spriteSizePrefix}0");
            var rectangle = sampleSprite.sourceRect;
            var spriteWidth = rectangle.Width;

            while (displaysNumber.NumberSpriteHoldersCount < strScore.Length)
            {
                var newNumber = new Number(displaysNumber.NumberSpriteHoldersCount, spriteWidth);
                displaysNumber.AddNumberSpriteHolder(newNumber);
                entity.scene.addEntity(newNumber);
            }

            for (int ii = 0; ii < strScore.Length; ii++)
            {
                var digit = strScore[ii];
                var digitSubtexture = _textureAtlas.getSubtexture($"{spriteSizePrefix}{digit}");
                var sprite = new Sprite(digitSubtexture);

                var reversedIndex = strScore.Length - ii - 1;
                displaysNumber.SetNumberSprite(reversedIndex, sprite);
            }
        }

        private string getSpriteSizePrefix(SpriteSize spriteSize)
        {
            switch (spriteSize)
            {
                case SpriteSize.Large:
                    return "l";
                case SpriteSize.Small:
                    return "s";
                default:
                    throw new System.NotImplementedException();
            }
        }

        public enum SpriteSize
        {
            Large,
            Small
        }
    }
}
