using Nez.TextureAtlases;
using Nez.UI;

namespace NezzyBird.UI
{
    public class PlayButtonFactory
    {
        public static Button Get(TextureAtlas textureAtlas)
        {
            var playButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("PlayButton"));
            var playButton = new Button(playButtonDrawable);
            playButton.shouldUseExplicitFocusableControl = true;
            return playButton;
        }
    }
}
