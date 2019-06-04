using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System.Linq;

namespace NezzyBird.Components
{
    public class ScreenFlash : Component
    {
        private readonly Sprite _overlay;

        private Texture2D _overlayTexture;

        private ScreenFlashState _state { get; set; }

        public ScreenFlash()
        {
            _overlayTexture = new Texture2D(
                Core.graphicsDevice,
                GameConstants.SCREEN_WIDTH,
                GameConstants.SCREEN_HEIGHT);

            _overlay = new Sprite(_overlayTexture);

            _setOverlayTextureColor(Color.Transparent);

            _state = new RaisingInOpacity();
        }

        public override void onAddedToEntity()
        {
            entity.addComponent(_overlay);
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

            var overlayColor = Color.Lerp(_state.FromColor, _state.ToColor, opacityPercentage);

            _setOverlayTextureColor(overlayColor);
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
            protected virtual float totalTime => 0.0625f;

            public abstract bool FlashIsFinished { get; }

            public abstract Color FromColor { get; }
            public abstract Color ToColor { get; }

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

            public override Color FromColor => Color.Transparent;

            public override Color ToColor => Color.White;

            protected override ScreenFlashState newStateAfterFinished()
            {
                return new LoweringInOpacity();
            }
        }

        private class LoweringInOpacity : ScreenFlashState
        {
            public override bool FlashIsFinished => false;

            public override Color FromColor => Color.White;

            public override Color ToColor => Color.Transparent;

            protected override ScreenFlashState newStateAfterFinished()
            {
                return new Finished();
            }
        }

        private class Finished : ScreenFlashState
        {
            public override bool FlashIsFinished => true;

            public override Color FromColor => Color.Transparent;

            public override Color ToColor => Color.Transparent;

            protected override float totalTime => 0f;

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
