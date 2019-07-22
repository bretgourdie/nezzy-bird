using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Textures;

namespace NezzyBird.Components
{
    public class VerticalDirection : Component
    {
        private readonly Sprite _sprite;

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
            _sprite = new Sprite(_subtexture);
            _sprite.setRenderLayer(GameConstants.RenderingLevels.Pipe);
        }

        public override void onAddedToEntity()
        {
            base.entity.addComponent(_sprite);
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
