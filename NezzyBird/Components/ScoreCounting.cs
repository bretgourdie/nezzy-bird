using Nez;

namespace NezzyBird.Components
{
    public class ScoreCounting : Component
    {
        public readonly int CountTo;

        public int CurrentNumber { get; set; }

        public float TimeSinceLastDisplay { get; private set; }

        public readonly float TimeBetweenDisplays;

        public ScoreCounting(int countTo)
        {
            CountTo = countTo;
            TimeBetweenDisplays = 0.25f;
        }

        public void updateDisplayTime(float deltaTime)
        {
            TimeSinceLastDisplay += deltaTime;
        }

        public void resetDisplayTime()
        {
            TimeSinceLastDisplay = 0f;
        }
    }
}
