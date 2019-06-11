using Nez.TextureAtlases;
using Nez.UI;

namespace NezzyBird.UI
{
    public class RankingButtonFactory
    {
        public Button Get(TextureAtlas textureAtlas)
        {
            var rankingButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("RankingButton"));
            var rankingButton = new Button(rankingButtonDrawable);
            rankingButton.shouldUseExplicitFocusableControl = true;
            rankingButton.onClicked += _rankingButton_onClicked;
            return rankingButton;
        }

        private void _rankingButton_onClicked(Button obj)
        {
            obj.onClicked -= _rankingButton_onClicked;
            throw new System.NotImplementedException();
        }
    }
}
