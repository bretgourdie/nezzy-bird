using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class BronzeMedal : Entity
    {
        public BronzeMedal(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("Bronze");
            addComponent(new Sprite(subtexture));

            addComponent(new SparklesCollection(SparklesCollection.SparkleSpeed.Bronze));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
