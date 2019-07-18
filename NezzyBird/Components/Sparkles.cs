using Nez;
using Nez.Sprites;
using NezzyBird.Entities;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class Sparkles : Component
    {
        public readonly SparkleSpeed Speed;

        public IList<Sparkle> SparkleSlots;

        public Sparkles(SparkleSpeed speed)
        {
            Speed = speed;
        }

        public enum SparkleSpeed
        {
            Bronze,
            Silver,
            Gold,
            Platinum
        }

        public void AnimateSparkles()
        {
            foreach (var sparkle in SparkleSlots)
            {

            }
        }
    }
}
