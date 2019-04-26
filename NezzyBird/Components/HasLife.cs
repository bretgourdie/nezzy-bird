using Nez;

namespace NezzyBird.Components
{
    public class HasLife : Component
    {
        public bool IsAlive { get; private set; }

        public HasLife()
        {
            IsAlive = true;
        }

        public void Kill()
        {
            IsAlive = false;
        }
    }
}
