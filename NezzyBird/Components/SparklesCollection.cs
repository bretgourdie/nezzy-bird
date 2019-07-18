using Nez;
using NezzyBird.Entities;
using System.Collections;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class SparklesCollection : Component, IEnumerable<Sparkle>
    {
        public readonly SparkleSpeed Speed;

        public IList<Sparkle> SparkleSlots;

        public SparklesCollection(SparkleSpeed speed)
        {
            Speed = speed;
        }

        public IEnumerator<Sparkle> GetEnumerator()
        {
            return SparkleSlots.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return SparkleSlots.GetEnumerator();
        }

        public enum SparkleSpeed
        {
            Bronze,
            Silver,
            Gold,
            Platinum
        }
    }
}
