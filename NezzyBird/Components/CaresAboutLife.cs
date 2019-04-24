using Nez;

namespace NezzyBird.Components
{
    public class CaresAboutLife : Component
    {
        public bool ImportantLifeIsAlive { get; private set; }

        public CaresAboutLife()
        {
            ImportantLifeIsAlive = true;
        }

        public void OnDeath()
        {
            ImportantLifeIsAlive = false;
        }
    }
}
