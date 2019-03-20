using Nez;

namespace NezzyBird.Components
{
    public class Life : Component
    {
        public bool IsAlive { get; private set; }

        public Life()
        {
            IsAlive = true;
        }

        public void Kill()
        {
            IsAlive = false;
        }
    }
}
