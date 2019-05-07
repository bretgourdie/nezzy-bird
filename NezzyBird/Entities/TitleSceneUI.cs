using Microsoft.Xna.Framework;
using Nez;
using Nez.TextureAtlases;
using Nez.UI;

namespace NezzyBird.Entities
{
    public class TitleSceneUI : Entity
    {
        public TitleSceneUI(TextureAtlas textureAtlas)
        {
            var gameScale = GameConstants.GetGameScale();

            var canvas = new UICanvas();

            var stage = canvas.stage;

            var table = stage.addElement(new Table()).setFillParent(true);

            var titleImage = new Image(textureAtlas.getSubtexture("Title"));

            titleImage.setScale(gameScale.X, gameScale.Y);
            table.add(titleImage)
                .setPadBottom(400);
            table.row();

            var playButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("PlayButton"));
            var playButton = new Button(playButtonDrawable);
            playButton.shouldUseExplicitFocusableControl = true;

            var rankingButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("RankingButton"));
            var rankingButton = new Button(rankingButtonDrawable);
            rankingButton.shouldUseExplicitFocusableControl = true;

            playButton.gamepadRightElement = rankingButton;
            rankingButton.gamepadLeftElement = playButton;

            const int actionButtonMiddlePad = 10;
            const int actionButtonBottomPad = 100;

            table.add(playButton)
                .setMinWidth(playButtonDrawable.minWidth * gameScale.X)
                .setMinHeight(playButtonDrawable.minHeight * gameScale.Y)
                .setPadRight(actionButtonMiddlePad)
                .setPadBottom(actionButtonBottomPad);
            table.add(rankingButton)
                .setMinWidth(rankingButtonDrawable.minWidth * gameScale.X)
                .setMinHeight(rankingButtonDrawable.minHeight * gameScale.Y)
                .setPadLeft(actionButtonMiddlePad)
                .setPadBottom(actionButtonBottomPad);
            table.row();

            var copyrightImage = new Image(textureAtlas.getSubtexture("Copyright"));
            copyrightImage.setScale(gameScale.X, gameScale.Y);
            table.add(copyrightImage);

            this.addComponent(canvas);
        }
    }
}
