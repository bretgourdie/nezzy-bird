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
            table.add(titleImage);
            table.row();

            var playButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("PlayButton"));
            var playButton = new Button(playButtonDrawable);
            table.add(playButton);

            var rankingButtonDrawable = new SubtextureDrawable(textureAtlas.getSubtexture("RankingButton"));
            var rankingButton = new Button(rankingButtonDrawable);
            table.add(rankingButton);
            table.row();

            var bar = new ProgressBar(0, 1, 0.1f, false, ProgressBarStyle.create(Color.Black, Color.White));
            table.add(bar);
            table.row();

            var slider = new Slider(0, 1, 0.1f, false, SliderStyle.create(Color.DarkGray, Color.LightYellow));
            table.add(slider);
            table.row();

            var button = new Button(ButtonStyle.create(Color.Black, Color.DarkGray, Color.Green));
            table.add(button).setMinWidth(100).setMinHeight(30);

            this.addComponent(canvas);
        }
    }
}
