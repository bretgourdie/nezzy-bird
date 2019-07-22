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
                typeof(Sparkling)
        ))
        { }

        public override void process(Entity medal)
        {
            var sparkling = medal.getComponent<Sparkling>();

            var sparkle = sparkling.Sparkle;

            var sparkleSprite = sparkle.getComponent<Sprite<int>>();

            if (!sparkleSprite.isPlaying)
            {
                var randomX = Random.nextFloat(50f) - 25f;
                var randomY = Random.nextFloat(50f) - 25f;
                sparkle.setLocalPosition(
                    new Vector2(
                        randomX,
                        randomY));

                sparkleSprite.setLocalOffset(sparkle.localPosition);

                sparkleSprite.play(Sparkle.SparkleAnimationKey);
            }
        }
    }
}
