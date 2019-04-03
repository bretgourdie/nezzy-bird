using Nez;
using System;

namespace NezzyBird.Components
{
    public class ActionOnInterval : Component
    {
        public bool Active { get; set; }

        public readonly float Interval;

        public float TimeSinceLastAction { get; set; }

        public readonly Action Action;

        public ActionOnInterval(
            Action action,
            float interval,
            bool active = true)
        {
            Action = action;
            Interval = interval;
            Active = active;
        }

        public void InvokeAction()
        {
            Action.Invoke();
        }
    }
}
