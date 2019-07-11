using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class PlatinumMedal : Entity
    {
        public PlatinumMedal(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("PlatinumMedal");
            addComponent(new Sprite(subtexture));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
