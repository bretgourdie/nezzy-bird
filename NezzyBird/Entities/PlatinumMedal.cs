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
            var sprite = new Sprite(subtexture);
            sprite.setRenderLayer(GameConstants.RenderingLevels.Medal);
            addComponent(sprite);

            addComponent(new Sparkling(textureAtlas));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
