using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using Nez.UI;
using NezzyBird.Systems;

namespace NezzyBird.UI
{
    public class PlayButtonFactory<T> where T : Scene, new()
    {
        private readonly Emitter<NezzyEvents> _emitter;

        public PlayButtonFactory(Emitter<NezzyEvents> emitter)
        {
            _emitter = emitter;
        }

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
            _emitter.emit(NezzyEvents.Transition);
            Core.startSceneTransition(new FadeTransition(() => new T()));
        }
    }
}
