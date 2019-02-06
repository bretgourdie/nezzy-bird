using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;
using NezzyBird.Entities;
using System;

namespace NezzyBird.Systems
{
    public class BirdSpriteRotationSystem : EntityProcessingSystem
    {
        public static Matcher GetMatcher()
        {
            var matcher = new Matcher();
            matcher.all(
                new System.Type[]
                {
                    typeof(HasVelocity),
                    typeof(Sprite)
                });

            return matcher;
        }

        public BirdSpriteRotationSystem() : base(BirdSpriteRotationSystem.GetMatcher()) { }

        public override void process(Entity entity)
        {
            var velocity = entity.getComponent<HasVelocity>();
            var sprite = entity.getComponent<Sprite>();

            var lowerBound = -2f;
            var upperBound = Bird.JUMP_HEIGHT;

            var clampedVelocity =
                MathHelper.Clamp(
                    velocity.CurrentVelocity.Y,
                    lowerBound,
                    upperBound);

            var rotationSignificance = (clampedVelocity - lowerBound) / (Math.Abs(upperBound - lowerBound));

            var rotationDegrees = MathHelper.Lerp(-40, 90, rotationSignificance);

            sprite.transform.rotationDegrees = rotationDegrees;
        }
    }
}
