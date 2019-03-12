using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using System;

namespace NezzyBird.Components
{
    public class ReactsToTap : Component, IUpdatable
    {
        private VirtualButton _tapButton;
        private Action<bool> _tappingAction;
        private Component _tappingComponent;

        public bool IsTapping { get; set; }

        public ReactsToTap(
            Component tappingComponent,
            Action<bool> tappingAction)
        {
            _tappingComponent = tappingComponent;
            _tappingAction = tappingAction;
        }

        public override void onAddedToEntity()
        {
            _tapButton = new VirtualButton();
            _tapButton.addKeyboardKey(Keys.Space);
            _tapButton.addMouseLeftButton();
            _tapButton.addGamePadButton((int)PlayerIndex.One, Buttons.A);

            entity.addComponent(_tappingComponent);
        }

        public override void onRemovedFromEntity()
        {
            _tapButton.deregister();
        }

        public void update()
        {
            _tappingAction.Invoke(_tapButton.isPressed);
        }
    }
}
