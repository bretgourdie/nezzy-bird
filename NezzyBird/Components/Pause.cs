using Nez;

namespace NezzyBird.Components
{
    public class Pause : Component
    {
        public float TimePassed { get; private set; }

        public const float TotalTime = 1f;

        public void update ()
        {
            TimePassed += Time.deltaTime;
        }
    }
}
