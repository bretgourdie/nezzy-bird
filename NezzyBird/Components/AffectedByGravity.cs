using Nez;

namespace NezzyBird.Components
{
    public class AffectedByGravity : Component
    {
        public readonly float GravitationalPull;

        public AffectedByGravity(float gravitationalPull)
        {
            GravitationalPull = gravitationalPull;
        }
    }
}
