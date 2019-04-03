using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class ScoreDisplay : Entity
    {
        public ScoreDisplay(TextureAtlas textureAtlas)
        {
            addComponent(new DisplaysNumber());
        }
    }
}
