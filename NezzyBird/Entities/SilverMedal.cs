using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class SilverMedal : Entity
    {
        public SilverMedal(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("Silver");
            addComponent(new Sprite(subtexture));

            addComponent(
                new SparklesCollection(
                    textureAtlas,
                    SparklesCollection.SparkleSpeed.Silver));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
