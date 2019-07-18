using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class GoldMedal : Entity
    {
        public GoldMedal(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("Gold");
            addComponent(new Sprite(subtexture));

            addComponent(new Sparkles(Sparkles.SparkleSpeed.Gold));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
