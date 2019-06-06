using Nez;
using NezzyBird.Components;
using System.Collections.Generic;

namespace NezzyBird.Entities
{
    public class GameOver : Entity
    {
        public GameOver(IList<Entity> gameOverStateEntities)
        {
            addComponent(new GameOverState(gameOverStateEntities));
        }
    }
}
