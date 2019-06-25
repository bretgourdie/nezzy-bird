using Nez;
using NezzyBird.Components;
using System.Collections.Generic;

namespace NezzyBird.Entities
{
    public class GameOverContainer : Entity
    {
        public GameOverContainer(IList<IGameOverState> gameOverStateEntities)
        {
            addComponent(new GameOverState(gameOverStateEntities));
            this.name = this.GetType().Name;
        }
    }
}
