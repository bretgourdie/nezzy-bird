using Nez;

namespace NezzyBird.Components
{
    public class AffectedByGravity : Component
    {
        private readonly float _gravitationalPull;

        public AffectedByGravity(float gravitationalPull)
        {
            _gravitationalPull = gravitationalPull;
        }
    }
}
