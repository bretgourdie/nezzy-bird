using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class RankingButton : Entity
    {
        public RankingButton(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("RankingButton");
            addComponent(new Sprite(subtexture));

            this.scale = GameConstants.GetGameScale();
        }
    }
}
