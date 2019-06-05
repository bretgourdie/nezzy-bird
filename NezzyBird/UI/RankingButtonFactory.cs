using Nez.TextureAtlases;
using Nez.UI;

namespace NezzyBird.UI
{
    public class RankingButtonFactory
    {
        public static Button Get(TextureAtlas textureAtlas)
        {
            var rankingButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("RankingButton"));
            var rankingButton = new Button(rankingButtonDrawable);
            rankingButton.shouldUseExplicitFocusableControl = true;
            return rankingButton;
        }
    }
}
