using Microsoft.Xna.Framework.Input;
using Nez;

namespace NezzyBird.Components
{
    public class JumpsOnTap : Component, IUpdatable
    {
        private readonly float _jumpAmount;

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
            if (_jumpButton.isPressed)
            {
                Nez.Debug.log("you just jumped!");
            }
        }
    }
}
