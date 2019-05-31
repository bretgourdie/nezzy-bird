using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System.Linq;

namespace NezzyBird.Components
{
    public class ScreenFlash : Component, IUpdatable
    {
        public readonly Sprite Overlay;

        private Texture2D _overlayTexture;

        private ScreenFlashState _state { get; set; }

        public ScreenFlash()
        {
            _overlayTexture = new Texture2D(
                Core.graphicsDevice,
                GameConstants.SCREEN_WIDTH,
                GameConstants.SCREEN_HEIGHT);

            var sprite = new Sprite(_overlayTexture);

            _setOverlayTextureColor(Color.Transparent);

            _state = new RaisingInOpacity();
        }

        public override void onEnabled()
        {
            base.onEnabled();
        }

        public void update()
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

        private void _setOverlayTextureColor(Color color)
        {
            var totalPixels = _overlayTexture.Height * _overlayTexture.Width;
            var pixels = Enumerable.Range(0, totalPixels).Select(x => color).ToArray();
            _overlayTexture.SetData(pixels);
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
