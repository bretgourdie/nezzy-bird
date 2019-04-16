using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

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

            var spriteComponents = entity.getComponents<Sprite>();
            foreach (var component in spriteComponents)
            {
                entity.removeComponent(component);
            }

            var score = displaysNumber.Score;

            var strScore = score.ToString();

            foreach (var digit in strScore)
            {
                var digitSubtexture = _textureAtlas.getSubtexture($"l{digit}");
                entity.addComponent(new Sprite(digitSubtexture));
                entity.setScale(GameConstants.SPRITE_SCALE_FACTOR);
            }
        }
    }
}
