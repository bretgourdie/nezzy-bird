using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class GoldMedal : Entity
    {
        public GoldMedal(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("GoldMedal");
            addComponent(new Sprite(subtexture));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
