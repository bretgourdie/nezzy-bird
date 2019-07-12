using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class SilverMedal : Entity
    {
        public SilverMedal(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("Silver");
            addComponent(new Sprite(subtexture));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
