using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class BirdSpriteRotationSystem : EntityProcessingSystem
    {
        public BirdSpriteRotationSystem() : base(
            new Matcher().all(
                typeof(JumpsOnTap),
                typeof(Sprite)
            ))
        {
        }

        public override void process(Entity entity)
        {
            var jumpsOnTap = entity.getComponent<JumpsOnTap>();
            var sprite = entity.getComponent<Sprite>();

            if (jumpsOnTap.IsJumping)
            {
                sprite.transform.tweenRotationDegreesTo(-40f)
                    .setNextTween(
                        sprite.transform.tweenRotationDegreesTo(90f, 0.5f))
                .start();
            }
        }
    }
}
