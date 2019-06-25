using Nez;
using Nez.TextureAtlases;
using Nez.UI;
using NezzyBird.Scenes;
using NezzyBird.UI;

namespace NezzyBird.Entities
{
    public class GameOverMenu : Entity, IGameOverState
    {
        public GameOverMenu(TextureAtlas textureAtlas)
        {
            var gameScale = GameConstants.GetGameScale();

            var canvas = new UICanvas();

            var stage = canvas.stage;

            var table = stage.addElement(new Table()).setFillParent(true);

            new PlayAndRankButtonRow<TitleScene>().AddToTable(textureAtlas, table);

            this.addComponent(canvas);

            this.name = this.GetType().Name;
        }

        public Entity Get()
        {
            return this;
        }

        public bool IsFinished()
        {
            return false;
        }

        public bool RemoveAfterFinished()
        {
            return false;
        }
    }
}
