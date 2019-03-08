using Microsoft.Xna.Framework.Input;
using Nez;

namespace NezzyBird.Components
{
    public class JumpsOnTap : Component
    {
        private readonly float _jumpAmount;
        public bool IsJumping { get; set; }

        public JumpsOnTap(float jumpAmount)
        {
            _jumpAmount = jumpAmount;
        }

        public float GetJumpAmount()
        {
            return IsJumping ? _jumpAmount : 0;
        }

        public void Jump(bool jumpButtonPressed)
        {
            IsJumping = jumpButtonPressed;
        }
    }
}
