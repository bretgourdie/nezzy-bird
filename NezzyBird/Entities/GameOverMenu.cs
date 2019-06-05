using Nez;
using Nez.TextureAtlases;
using Nez.UI;
using NezzyBird.UI;

namespace NezzyBird.Entities
{
    public class GameOverMenu : Entity
    {
        public GameOverMenu(TextureAtlas textureAtlas)
        {
            var gameScale = GameConstants.GetGameScale();

            var canvas = new UICanvas();

            var stage = canvas.stage;

            var table = stage.addElement(new Table()).setFillParent(true);

            PlayAndRankButtonRow.AddToTable(textureAtlas, table);

            this.addComponent(canvas);
        }
    }
}
