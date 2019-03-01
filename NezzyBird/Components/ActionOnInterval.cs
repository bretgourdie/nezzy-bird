using Nez;
using System;
using System.Collections;

namespace NezzyBird.Components
{
    public class ActionOnInterval : Component
    {
        public bool Active { get; set; }

        public ActionOnInterval(
            Action action,
            float interval,
            bool active = true)
        {
            Active = active;
            Core.startCoroutine(Perform(action, interval));
        }

        public IEnumerator Perform(
            Action action,
            float interval)
        {
            while (Active)
            {
                action.Invoke();
                yield return Coroutine.waitForSeconds(interval);
            }
        }
    }
}
