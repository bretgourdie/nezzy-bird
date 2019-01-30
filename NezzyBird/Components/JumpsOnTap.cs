using Nez;

namespace NezzyBird.Components
{
    public class JumpsOnTap : Component
    {
        private readonly float _jumpAmount;

        public JumpsOnTap(float jumpAmount)
        {
            _jumpAmount = jumpAmount;
        }
    }
}
