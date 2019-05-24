using Nez;

namespace NezzyBird.Components
{
    public class ScreenFlash : SceneComponent
    {
        public bool IsFinished { get; private set; }
        public bool HasStarted { get; private set; }

        public const float TotalDuration = 2f;
        public float TimePassed { get; private set; }

        public const float ToWhite = TotalDuration / 2f;

        public const float ToClear = TotalDuration / 2f;

        public void AddTime(float deltaTime)
        {
            TimePassed += deltaTime;
        }
    }
}
