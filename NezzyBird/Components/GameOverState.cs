using Nez;
using NezzyBird.Entities;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class GameOverState : Component, IUpdatable
    {
        private readonly ScreenFlasher _screenFlasher;
        private readonly GameOverMenu _gameOverMenu;

        private LinkedListNode<Entity> _currentEntityNode;

        public GameOverState(
            ScreenFlasher screenFlasher,
            GameOverMenu gameOverMenu)
        {
            _screenFlasher = screenFlasher;
            _screenFlasher.setEnabled(false);
            _gameOverMenu = gameOverMenu;
            _gameOverMenu.setEnabled(false);

            var list = new LinkedList<Entity>();
            list.AddLast(_screenFlasher);
            list.AddLast(_gameOverMenu);

            _currentEntityNode = list.First;
        }

        public override void onAddedToEntity()
        {
            entity.scene.addEntity(_screenFlasher);
            entity.scene.addEntity(_gameOverMenu);
        }

        public void update() => _currentEntityNode.Value.update();

        public Entity CurrentEntity => _currentEntityNode.Value;

        public void AdvanceToNextEntity() => _currentEntityNode = _currentEntityNode.Next;

        public bool CurrentEntityIsComplete => !_currentEntityNode.Value.enabled;
    }
}
