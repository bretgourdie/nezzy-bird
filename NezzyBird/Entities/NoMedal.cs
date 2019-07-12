using Nez;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class NoMedal : Entity
    {
        public NoMedal(TextureAtlas textureAtlas)
        {
            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
