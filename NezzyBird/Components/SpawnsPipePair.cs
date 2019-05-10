using Nez;
using System;

namespace NezzyBird.Components
{
    public class SpawnsPipePair : Component
    {
        public readonly float Interval;

        public float TimeSinceLastSpawn { get; private set; }

        public SpawnsPipePair(
            float interval)
        {
            Interval = interval;
        }

        public void AddToTimeSinceLastSpawn(float timeElapsed)
        {
            TimeSinceLastSpawn += timeElapsed;
        }

        public void ResetTimeSinceLastSpawn()
        {
            TimeSinceLastSpawn = 0f;
        }
    }
}
