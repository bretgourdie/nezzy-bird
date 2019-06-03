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
            _gameOverMenu = gameOverMenu;

            var list = new LinkedList<Entity>();
            list.AddLast(_screenFlasher);
            list.AddLast(_gameOverMenu);

            _currentEntityNode = list.First;
        }

        public void update() => _currentEntityNode.Value.update();

        public Entity GetCurrentEntity() => _currentEntityNode.Value;

        public void AdvanceToNextEntity() => _currentEntityNode = _currentEntityNode.Next;

        public bool CurrentEntityIsComplete => !_currentEntityNode.Value.enabled;
    }
}
