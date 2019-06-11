using Nez;
using Nez.TextureAtlases;
using Nez.UI;

namespace NezzyBird.UI
{
    public class PlayButtonFactory<T> where T : Scene, new()
    {
        public Button Get(TextureAtlas textureAtlas)
        {
            var playButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("PlayButton"));
            var playButton = new Button(playButtonDrawable);
            playButton.shouldUseExplicitFocusableControl = true;
            playButton.onClicked += _playButton_onClicked;
            return playButton;
        }

        private void _playButton_onClicked(Button obj)
        {
            obj.onClicked -= _playButton_onClicked;
            Core.startSceneTransition(new FadeTransition(() => new T()));
        }
    }
}
