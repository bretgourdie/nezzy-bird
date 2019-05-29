using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace NezzyBird.Components
{
    public class ScreenFlash : SceneComponent
    {
        public Texture2D Overlay { get; private set; }

        private ScreenFlashState _state { get; set; }

        public ScreenFlash()
        {
            Overlay = new Texture2D(
                Core.graphicsDevice,
                GameConstants.SCREEN_WIDTH,
                GameConstants.SCREEN_HEIGHT);

            _setOverlayColor(Color.Transparent);

            _state = new RaisingInOpacity();
        }

        public override void update()
        {
            _handleState(Time.deltaTime);
            _updateRectangleOpacity();
        }

        public bool IsFinished()
        {
            return _state.FlashIsFinished;
        }

        private void _handleState(float deltaTime)
        {
            _state = _state.Handle(deltaTime);
        }

        private void _updateRectangleOpacity()
        {
            var opacityPercentage = _state.GetOpacityPercentage();

            var overlayColor = Color.Lerp(Color.Transparent, Color.White, opacityPercentage);
        }

        private void _setOverlayColor(Color color)
        {
            Overlay.SetData(new[] { color });
        }

        private abstract class ScreenFlashState
        {
            protected float timePassed;
            protected const float totalTime = 1f;

            public abstract bool FlashIsFinished { get; }

            public virtual ScreenFlashState Handle(float deltaTime)
            {
                timePassed += deltaTime;

                if (StepIsFinished())
                {
                    return newStateAfterFinished();
                }

                return this;
            }

            protected abstract ScreenFlashState newStateAfterFinished();

            public virtual bool StepIsFinished()
            {
                return timePassed >= totalTime;
            }

            public virtual float GetOpacityPercentage()
            {
                return MathHelper.Clamp(timePassed / totalTime, 0f, 1f);
            }
        }

        private class RaisingInOpacity : ScreenFlashState
        {
            public override bool FlashIsFinished => false;

            protected override ScreenFlashState newStateAfterFinished()
            {
                return new LoweringInOpacity();
            }
        }

        private class LoweringInOpacity : ScreenFlashState
        {
            public override bool FlashIsFinished => false;

            protected override ScreenFlashState newStateAfterFinished()
            {
                return new Finished();
            }
        }

        private class Finished : ScreenFlashState
        {
            public override bool FlashIsFinished => true;

            public override ScreenFlashState Handle(float deltaTime)
            {
                return this;
            }

            public override bool IsFinished()
            {
                return true;
            }

            public override float GetOpacityPercentage()
            {
                return 0f;
            }

            protected override ScreenFlashState newStateAfterFinished()
            {
                return null;
            }
        }
    }
}
