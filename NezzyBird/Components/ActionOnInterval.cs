using Nez;
using System;

namespace NezzyBird.Components
{
    public class ActionOnInterval : Component
    {
        public bool Active { get; set; }

        public readonly float Interval;

        public event EventHandler OnIntervalLapsed;

        public float TimeSinceLastAction { get; set; }

        public ActionOnInterval(
            float interval,
            bool active = true)
        {
            Interval = interval;
            Active = active;
        }

        public void IntervalHasLapsed()
        {
            OnIntervalLapsed(this, EventArgs.Empty);
        }
    }
}
