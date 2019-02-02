using Nez;

namespace NezzyBird.Components
{
    public class JumpsOnTap : Component, IUpdatable
    {
        private readonly float _jumpAmount;

        public JumpsOnTap(float jumpAmount)
        {
            _jumpAmount = jumpAmount;
        }

        public void update()
        {
            throw new System.NotImplementedException();
        }
    }
}
