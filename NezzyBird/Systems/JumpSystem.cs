using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Systems;
using NezzyBird.Components;
using System;

namespace NezzyBird.Systems
{
    public class JumpSystem : EntityProcessingSystem, IDisposable
    {
        private bool _canJump = true;
        private readonly Emitter<NezzyEvents> _emitter;
        private readonly VirtualButton _tapButton;

        public JumpSystem(Emitter<NezzyEvents> emitter) : base(
            new Matcher().all(
                typeof(JumpsOnTap),
                typeof(WaitsForFirstTap),
                typeof(HasVelocity)
            )
        )
        {
            _emitter = emitter;
            _emitter.addObserver(NezzyEvents.BirdDied, () => _canJump = false);

            _tapButton = _addTappingButton();
        }

        public override void process(Entity entity)
        {
            if (!_canJump)
            {
                return;
            }

            if (!_tapButton.isPressed)
            {
                return;
            }

            var jump = entity.getComponent<JumpsOnTap>();
            var velocity = entity.getComponent<HasVelocity>();
            var waitsForFirstTap = entity.getComponent<WaitsForFirstTap>();

            velocity.CurrentVelocity = new Vector2(0, -jump.JumpAmount);
            waitsForFirstTap.RecordTap();
            _emitter.emit(NezzyEvents.BirdJumped);
        }

        private VirtualButton _addTappingButton()
        {
            var tapButton = new VirtualButton();
            tapButton.addKeyboardKey(Keys.Space);
            tapButton.addMouseLeftButton();
            tapButton.addGamePadButton((int)PlayerIndex.One, Buttons.A);

            return tapButton;
        }

        public void Dispose() => _tapButton.deregister();
    }
}
