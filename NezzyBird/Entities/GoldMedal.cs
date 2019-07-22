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
            var sprite = new Sprite(subtexture);
            sprite.setRenderLayer(GameConstants.RenderingLevels.Medal);
            addComponent(sprite);

            addComponent(
                new SparklesCollection(
                    textureAtlas,
                    SparklesCollection.SparkleSpeed.Gold));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
