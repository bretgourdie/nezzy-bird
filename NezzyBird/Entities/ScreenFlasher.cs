using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class ScreenFlasher : Entity
    {
        public ScreenFlasher()
        {
            addComponent(new ScreenFlash());
        }
    }
}
