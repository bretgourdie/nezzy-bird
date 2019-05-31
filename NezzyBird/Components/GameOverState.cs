using Nez;
using NezzyBird.Entities;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class GameOverState : Component, IUpdatable
    {
        public readonly Entities.ScreenFlasher ScreenFlasher;
        public readonly GameOverMenu GameOverMenu;

        public LinkedListNode<Entity> CurrentEntityNode { get; private set; }

        public GameOverState(
            Entities.ScreenFlasher screenFlasher,
            GameOverMenu gameOverMenu)
        {
            ScreenFlasher = screenFlasher;
            GameOverMenu = gameOverMenu;

            var list = new LinkedList<Entity>();
            list.AddLast(ScreenFlasher);
            list.AddLast(GameOverMenu);

            CurrentEntityNode = list.First;
        }

        public void update()
        {
            CurrentEntityNode.Value.update();
        }

        public Entity GetCurrentEntity()
        {
            return CurrentEntityNode.Value;
        }

        public void AdvanceToNextEntity()
        {
            CurrentEntityNode = CurrentEntityNode.Next;
        }
    }
}
