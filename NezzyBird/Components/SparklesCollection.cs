using Nez;
using Nez.TextureAtlases;
using NezzyBird.Entities;
using System.Collections;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class SparklesCollection : Component, IEnumerable<Sparkle>
    {
        public readonly SparkleSpeed Speed;

        public IList<Sparkle> SparkleSlots;

        public SparklesCollection(
            TextureAtlas textureAtlas,
            SparkleSpeed speed)
        {
            Speed = speed;

            var delay = translateSpeedToDelay(speed);

            SparkleSlots = new List<Sparkle>()
            {
                new Sparkle(textureAtlas, delay),
                new Sparkle(textureAtlas, delay),
                new Sparkle(textureAtlas, delay)
            };
        }

        public IEnumerator<Sparkle> GetEnumerator()
        {
            return SparkleSlots.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return SparkleSlots.GetEnumerator();
        }

        private float translateSpeedToDelay(SparkleSpeed speed)
        {
            return 0.5f;
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
