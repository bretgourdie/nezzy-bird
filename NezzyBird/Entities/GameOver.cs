using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class GameOver : Entity
    {
        public GameOver(
            ScreenFlasher screenFlasher,
            GameOverMenu gameOverMenu)
        {
            addComponent(new GameOverState(screenFlasher, gameOverMenu));
        }
    }
}
