using Nez;

namespace NezzyBird.Components
{
    public class Fades : Component
    {
        public float Opacity { get; set; }

        public float TotalTime { get; private set; }

        public float TimeElapsed { get; private set; }

        public bool IsFadingOut { get; private set; }

        public FadeDirection FadeDirection { get; private set; }

        public Fades(
            FadeDirection fadeDirection,
            float totalTime)
        {
            Opacity = 1f;
            TotalTime = totalTime;
            IsFadingOut = false;
            FadeDirection = fadeDirection;
        }

        public void ToggleFadeOut()
        {
            IsFadingOut = !IsFadingOut;
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
