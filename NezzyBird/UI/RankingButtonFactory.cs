using Microsoft.Xna.Framework;
using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using Nez.UI;
using NezzyBird.Systems;

namespace NezzyBird.UI
{
    public class RankingButtonFactory
    {
        private readonly Emitter<NezzyEvents> _emitter;

        public RankingButtonFactory(Emitter<NezzyEvents> emitter)
        {
            _emitter = emitter;
        }

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
            _emitter.emit(NezzyEvents.Transition);

            var label = new Label("Could not connect to the Internet. Try again later!");
            label.scaleBy(GameConstants.GetGameScale().X);
            label.setPosition(
                GameConstants.SCREEN_WIDTH / 2 - label.minWidth / 2,
                GameConstants.SCREEN_HEIGHT - 25);

            var canvas = new UICanvas();
            canvas.stage.addElement(label);

            var uiEntity = new Entity("RankingButtonLabel");

            uiEntity.addComponent(canvas);

            Core.scene.addEntity(uiEntity);
        }
    }
}
