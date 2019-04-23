using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class ScoreDisplaySystem : EntityProcessingSystem
    {
        private readonly TextureAtlas _textureAtlas;

        public ScoreDisplaySystem(
            TextureAtlas textureAtlas) : base(
            new Matcher().all(typeof(DisplaysNumber)))
        {
            _textureAtlas = textureAtlas;
        }

        public override void process(Entity entity)
        {
            var displaysNumber = entity.getComponent<DisplaysNumber>();
            
            if (!displaysNumber.NumberNeedsToBeUpdated)
            {
                return;
            }

            displaysNumber.HandleUpdatedNumber();

            var score = displaysNumber.Number;

            var strScore = score.ToString();

            var sampleSprite = _textureAtlas.getSubtexture("l0");
            var rectangle = sampleSprite.sourceRect;
            var spriteWidth = rectangle.Width;

            while (displaysNumber.NumberSpriteHoldersCount < strScore.Length)
            {
                var newNumber = new Number(displaysNumber.NumberSpriteHoldersCount, spriteWidth);
                displaysNumber.AddNumberSpriteHolder(newNumber);
                scene.addEntity(newNumber);
            }

            for (int ii = 0; ii < strScore.Length; ii++)
            {
                var digit = strScore[ii];
                var digitSubtexture = _textureAtlas.getSubtexture($"l{digit}");
                var sprite = new Sprite(digitSubtexture);

                var reversedIndex = strScore.Length - ii - 1;
                displaysNumber.SetNumberSprite(reversedIndex, sprite);
            }
        }
    }
}
