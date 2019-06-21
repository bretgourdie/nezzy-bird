using Nez;
using Nez.TextureAtlases;
using Nez.UI;
using NezzyBird.Scenes;
using NezzyBird.UI;

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

            new PlayAndRankButtonRow<MainScene>().AddToTable(textureAtlas, table);
            table.row();

            var copyrightImage = new Image(textureAtlas.getSubtexture("Copyright"));
            copyrightImage.setScale(gameScale.X, gameScale.Y);
            table.add(copyrightImage);

            this.addComponent(canvas);

            this.name = this.GetType().Name;
        }
    }
}
