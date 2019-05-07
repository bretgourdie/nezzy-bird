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
            var canvas = new UICanvas();

            var stage = canvas.stage;

            var table = stage.addElement(new Table()).setFillParent(true);

            var background = new SubtextureDrawable(textureAtlas.getSubtexture("Day"));
            table.setBackground(background);

            var titleImage = new Image(textureAtlas.getSubtexture("Title"));
            var gameScale = GameConstants.GetGameScale();
            titleImage.setScale(gameScale.X, gameScale.Y);
            table.add(titleImage)
                .setPadBottom(300);
            table.row();

            var playButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("PlayButton"));
            var playButton = new Button(playButtonDrawable);
            playButton.shouldUseExplicitFocusableControl = true;

            var rankingButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("RankingButton"));
            var rankingButton = new Button(rankingButtonDrawable);
            rankingButton.shouldUseExplicitFocusableControl = true;

            playButton.gamepadRightElement = rankingButton;
            rankingButton.gamepadLeftElement = playButton;

            table.add(playButton)
                .setMinWidth(playButtonDrawable.minWidth * gameScale.X)
                .setMinHeight(playButtonDrawable.minHeight * gameScale.Y)
                .setPadRight(10);
            table.add(rankingButton)
                .setMinWidth(rankingButtonDrawable.minWidth * gameScale.X)
                .setMinHeight(rankingButtonDrawable.minHeight * gameScale.Y)
                .setPadLeft(10);
            table.row();

            this.addComponent(canvas);
        }
    }
}
