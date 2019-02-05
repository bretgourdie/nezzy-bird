using Microsoft.Xna.Framework.Input;
using Nez;

namespace NezzyBird.Components
{
    public class JumpsOnTap : Component, IUpdatable
    {
        private readonly float _jumpAmount;
        public bool IsJumping { get; set; }

        private VirtualButton _jumpButton;

        public JumpsOnTap(float jumpAmount)
        {
            _jumpAmount = jumpAmount;
        }

        public override void onAddedToEntity()
        {
            _jumpButton = new VirtualButton();
            _jumpButton.addKeyboardKey(Keys.Space);
            _jumpButton.addMouseLeftButton();
        }

        public override void onRemovedFromEntity()
        {
            _jumpButton.deregister();
        }

        public void update()
        {
            IsJumping = _jumpButton.isPressed;
        }

        public float GetJumpAmount()
        {
            return IsJumping ? _jumpAmount : 0;
        }
    }
}
