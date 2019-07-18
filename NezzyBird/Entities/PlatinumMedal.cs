using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class PlatinumMedal : Entity
    {
        public PlatinumMedal(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("Platinum");
            addComponent(new Sprite(subtexture));

            addComponent(new SparklesCollection(SparklesCollection.SparkleSpeed.Platinum));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
