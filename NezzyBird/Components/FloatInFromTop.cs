using Microsoft.Xna.Framework;
using Nez;

namespace NezzyBird.Components
{
    public class FloatInFromTop : Component
    {
        public float TimePassed { get; private set; }

        public float TotalTime { get; private set; }

        public readonly Vector2 StartPosition;

        public readonly Vector2 EndPosition;

        public FloatInFromTop(
            Vector2 startPosition,
            Vector2 endPosition)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;

            TotalTime = 1.5f;
        }

        public void PassTime(float deltaTime)
        {
            TimePassed += deltaTime;
        }
    }
}
