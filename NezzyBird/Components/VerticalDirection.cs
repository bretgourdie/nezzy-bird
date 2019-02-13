using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Textures;

namespace NezzyBird.Components
{
    public class VerticalDirection : Component
    {
        public Sprite Sprite { get; private set; }
        private readonly Subtexture _subtexture;

        public enum MouthOpens
        {
            Up,
            Down
        }

        private readonly MouthOpens _openDirection;

        public VerticalDirection(
            TextureAtlas textureAtlas,
            MouthOpens openDirection)
        {
            _openDirection = openDirection;
            _subtexture = getCorrectSubtexture(textureAtlas, openDirection);
        }

        public override void onAddedToEntity()
        {
            Sprite = new Sprite(_subtexture);
        }

        private Subtexture getCorrectSubtexture(
            TextureAtlas textureAtlas,
            MouthOpens mouthOpens)
        {
            return textureAtlas.getSubtexture($"Pipe0{mouthOpens.ToString()}");
        }
    }
}
