using Nez;

namespace NezzyBird.Components
{
    public class Fades : Component
    {
        public float TotalTime { get; private set; }

        public float TimeElapsed { get; private set; }

        public FadeDirection FadeDirection { get; private set; }

        public Fades(
            FadeDirection fadeDirection,
            float totalTime)
        {
            TotalTime = totalTime;
            FadeDirection = fadeDirection;
        }

        public void update(float deltaTime)
        {
            TimeElapsed += deltaTime;
        }
    }

    public enum FadeDirection
    {
        In,
        Out
    }
}
