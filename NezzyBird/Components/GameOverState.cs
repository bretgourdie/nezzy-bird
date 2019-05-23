using Nez;
using NezzyBird.Entities;

namespace NezzyBird.Components
{
    public class GameOverState : Component
    {
        public readonly ScreenFlasher ScreenFlasher;

        public GameOverState(
            ScreenFlasher screenFlasher)
        {
            ScreenFlasher = screenFlasher;
            // GameOverMenu = gameOverMenu;
        }
    }
}
