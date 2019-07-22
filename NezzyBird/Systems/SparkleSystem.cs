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

        public override void process(Entity medal)
        {
            var sparkleCollection = medal.getComponent<SparklesCollection>();

            foreach(var sparkle in sparkleCollection)
            {
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
}
