using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class ScoreDisplaySystem : EntityProcessingSystem
    {
        private TextureAtlas _textureAtlas;

        public ScoreDisplaySystem(TextureAtlas textureAtlas) : base(
            new Matcher().all(typeof(DisplaysNumber)))
        {
            _textureAtlas = textureAtlas;
        }

        public override void process(Entity entity)
        {
            var displaysNumber = entity.getComponent<DisplaysNumber>();
            
            if (!displaysNumber.ScoreNeedsUpdated())
            {
                return;
            }

            displaysNumber.UpdateScore();

            var score = displaysNumber.Score;

            var strScore = score.ToString();

            while (displaysNumber.Numbers.Count < strScore.Length)
            {
                var newNumber = new Number();
                displaysNumber.AddNumber(newNumber);
            }

            for (int ii = 0; ii < strScore.Length; ii++)
            {
                var digit = strScore[ii];
                var digitSubtexture = _textureAtlas.getSubtexture($"l{digit}");
                var sprite = new Sprite(digitSubtexture);

                displaysNumber.SetNumber(ii, sprite);
            }
        }
    }
}
