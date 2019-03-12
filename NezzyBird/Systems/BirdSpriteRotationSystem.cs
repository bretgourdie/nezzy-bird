using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Tweens;
using NezzyBird.Components;
using NezzyBird.Entities;
using System;

namespace NezzyBird.Systems
{
    public class BirdSpriteRotationSystem : EntityProcessingSystem
    {
        public BirdSpriteRotationSystem() : base(
            new Matcher()
            .all(
                typeof(JumpsOnTap),
                typeof(Sprite))) { }

        public override void process(Entity entity)
        {
            var jump = entity.getComponent<JumpsOnTap>();

            if (!jump.IsJumping)
            {
                return;
            }

            var sprite = entity.getComponent<Sprite>();

            TweenManager.stopAllTweensWithTarget(sprite.transform);

            var jumpBegin = sprite.transform.tweenRotationDegreesTo(-25, 0.1f);
            var descentBegin = sprite.transform.tweenRotationDegreesTo(90, 0.65f).setEaseType(EaseType.ExpoIn);

            var completeAnimation = jumpBegin.setNextTween(descentBegin);

            completeAnimation.start();
        }
    }
}
