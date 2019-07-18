using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class MedalSelectionSystem : EntityProcessingSystem
    {
        private readonly TextureAtlas _textureAtlas;

        public MedalSelectionSystem(TextureAtlas textureAtlas) : base(
            new Matcher().all(
                typeof(MedalContaining)
            ))
        {
            _textureAtlas = textureAtlas;
        }

        public override void process(Entity entity)
        {
            var medalContaining = entity.getComponent<MedalContaining>();

            if (medalContaining.IsMedalSet)
            {
                return;
            }

            var medal = _determineMedal(medalContaining.Score);
            medalContaining.Medal = medal;
        }

        private Entity _determineMedal(int score)
        {
            return new PlatinumMedal(_textureAtlas);
            //if (score < 10)
            //{
            //    return new NoMedal(_textureAtlas);
            //}

            //else if (score >= 10 && score < 20)
            //{
            //    return new BronzeMedal(_textureAtlas);
            //}

            //else if (score >= 20 && score < 30)
            //{
            //    return new SilverMedal(_textureAtlas);
            //}

            //else if (score >= 30 && score < 40)
            //{
            //    return new GoldMedal(_textureAtlas);
            //}

            //else if (score >= 40)
            //{
            //    return new PlatinumMedal(_textureAtlas);
            //}

            //else
            //{
            //    throw new System.NotImplementedException();
            //}
        }
    }
}
