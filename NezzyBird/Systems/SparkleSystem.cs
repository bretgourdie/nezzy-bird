using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;
using NezzyBird.Entities;

namespace NezzyBird.Systems
{
    public class SparkleSystem : EntityProcessingSystem
    {
        public SparkleSystem() : base(
            new Matcher().all(
                typeof(SparklesCollection)
        ))
        { }

        public override void process(Entity entity)
        {
            var sparkleCollection = entity.getComponent<SparklesCollection>();

            foreach(var sparkle in sparkleCollection)
            {
                var sprite = sparkle.getComponent<Sprite<int>>();

                if (!sprite.isPlaying)
                {
                    var randomX = Random.nextFloat(50f) - 25f;
                    var randomY = Random.nextFloat(50f) - 25f;
                    sparkle.setPosition(
                        new Vector2(
                            randomX,
                            randomY));

                    sprite.play(Sparkle.SparkleAnimationKey);
                }
            }
        }
    }
}
