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
            var sprite = new Sprite(subtexture);
            sprite.setRenderLayer(GameConstants.RenderingLevels.Medal);
            addComponent(sprite);

            addComponent(new Sparkling(textureAtlas));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
