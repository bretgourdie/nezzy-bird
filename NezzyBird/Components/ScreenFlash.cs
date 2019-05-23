using Nez;

namespace NezzyBird.Components
{
    public class ScreenFlash : Component
    {
        public bool IsFinished { get; private set; }
        public bool HasStarted { get; private set; }

        public const float TotalDuration = 2f;
        public float TimePassed { get; private set; }

        public void AddTime(float deltaTime)
        {
            TimePassed += deltaTime;
        }
    }
}
