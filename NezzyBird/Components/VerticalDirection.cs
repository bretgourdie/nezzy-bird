using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Textures;

namespace NezzyBird.Components
{
    public class VerticalDirection : Component
    {
        public Sprite Sprite { get; private set; }

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
            var _subtexture = getCorrectSubtexture(textureAtlas, openDirection);
            Sprite = new Sprite(_subtexture);
        }

        private Subtexture getCorrectSubtexture(
            TextureAtlas textureAtlas,
            MouthOpens mouthOpens)
        {
            var pipeAsset = $"Pipe0Mouth{mouthOpens.ToString()}";
            return textureAtlas.getSubtexture(pipeAsset);
        }
    }
}
