using Nez;
using Nez.TextureAtlases;
using NezzyBird.Entities;

namespace NezzyBird.Components
{
    public class Sparkling : Component
    {
        public readonly Sparkle Sparkle;

        public Sparkling(TextureAtlas textureAtlas)
        {
            Sparkle = new Sparkle(textureAtlas);
        }

        public override void onAddedToEntity()
        {
            Sparkle.setParent(this.entity);
            this.entity.scene.addEntity(Sparkle);
        }
    }
}
