using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class ScreenFlasher : Entity
    {
        public ScreenFlasher()
        {
            addComponent(new ScreenFlash());
            this.setPosition(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 2);

            this.name = this.GetType().Name;
        }
    }
}
