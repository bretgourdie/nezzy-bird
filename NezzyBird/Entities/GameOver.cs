using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class GameOver : Entity
    {
        public GameOver()
        {
            addComponent(new GameOverState());
        }
    }
}
