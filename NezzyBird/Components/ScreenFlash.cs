using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace NezzyBird.Components
{
    public class ScreenFlash : SceneComponent
    {
        public const float TotalDuration = 2f;

        public float TimePassed { get; private set; }

        public Texture2D Overlay { get; private set; }

        private IScreenFlashState _state { get; set; }

        public ScreenFlash()
        {
            Overlay = new Texture2D(
                Core.graphicsDevice,
                GameConstants.SCREEN_WIDTH,
                GameConstants.SCREEN_HEIGHT);

            var clearWhite = Color.White;
            clearWhite.A = 0;

            Overlay.SetData(new[] { clearWhite });

            _state = new RaisingInOpacity();
        }

        public void HandleState()
        {
            _state = _state.Handle();
        }

        public void AddTime(float deltaTime)
        {
            TimePassed += deltaTime;
        }
        private interface IScreenFlashState
        {
            IScreenFlashState Handle();
        }

        private class RaisingInOpacity : IScreenFlashState
        {
            public IScreenFlashState Handle()
            {
                throw new System.NotImplementedException();
            }
        }

        private class LoweringInOpacity : IScreenFlashState
        {
            public IScreenFlashState Handle()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
