using Nez;

namespace NezzyBird.Components
{
    public class Scrolling : Component
    {
        private readonly float _rate;

        public enum ScrollDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        private readonly ScrollDirection _scrollDirection;

        public Scrolling(ScrollDirection scrollDirection, float rate)
        {
            _scrollDirection = scrollDirection;
            _rate = rate;
        }
    }
}
