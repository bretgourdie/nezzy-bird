using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Systems;
using Nez.Tweens;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class BirdSpriteRotationSystem : EntityProcessingSystem
    {
        private bool _birdHasJumped;

        public BirdSpriteRotationSystem(Emitter<NezzyEvents> emitter) : base(
            new Matcher()
            .all(
                typeof(JumpsOnTap),
                typeof(Sprite)))
        {
            emitter.addObserver(NezzyEvents.BirdJumped, () => _birdHasJumped = true);
        }

        public override void process(Entity entity)
        {
            var jump = entity.getComponent<JumpsOnTap>();

            if (!_birdHasJumped)
            {
                return;
            }

            var sprite = entity.getComponent<Sprite>();

            TweenManager.stopAllTweensWithTarget(sprite.transform);

            var jumpBegin = sprite.transform.tweenRotationDegreesTo(-25, 0.1f);
            var descentBegin = sprite.transform.tweenRotationDegreesTo(90, 0.65f).setEaseType(EaseType.ExpoIn);

            var completeAnimation = jumpBegin.setNextTween(descentBegin);

            completeAnimation.start();

            _birdHasJumped = false;
        }
    }
}
