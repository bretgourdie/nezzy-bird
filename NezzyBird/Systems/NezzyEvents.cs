using System.Collections.Generic;

namespace NezzyBird.Systems
{
    public enum NezzyEvents
    {
        BirdScored = 1,
        BirdDied = 2,
        BirdJumped = 3,
        Transition = 4,
    }

    public struct NezzyEventsComparer : IEqualityComparer<NezzyEvents>
    {
        public bool Equals(NezzyEvents x, NezzyEvents y)
        {
            return x == y;
        }

        public int GetHashCode(NezzyEvents obj)
        {
            return (int)obj;
        }
    }
}
