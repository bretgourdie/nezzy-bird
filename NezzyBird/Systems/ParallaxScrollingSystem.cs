using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ParallaxScrollingSystem : EntityProcessingSystem
    {
        public ParallaxScrollingSystem() : base(
            new Matcher().all(
                typeof(ParallaxScrolling)
            ))
        { }

        public override void onAdded(Entity entity)
        {
            var sprite = entity.getComponent<Sprite>();

            if (sprite == null)
            {
                throw new System.InvalidOperationException("Entity has no sprite to clone");
            }

            var secondarySprite = (Sprite)sprite.clone();

            var parallaxScrolling = entity.getComponent<ParallaxScrolling>();
            parallaxScrolling.AddSprite(secondarySprite);
            parallaxScrolling.OtherEntity.position =
                new Vector2(
                    entity.position.X + sprite.width,
                    entity.position.Y);
        }

        public override void process(Entity entity)
        {
            var sprite = entity.getComponent<Sprite>();
            var parallaxScrolling = entity.getComponent<ParallaxScrolling>();

            var otherSprite = parallaxScrolling.OtherSprite;

            var sprites = new Sprite[] { sprite, otherSprite };

            for (int ii = 0; ii < sprites.Length; ii++)
            {
                var currentSprite = sprites[ii];

                if (!currentSprite.isVisible)
                {
                    var nextSpriteIndex = (ii + 1) % sprites.Length;
                    var nextSprite = sprites[nextSpriteIndex];

                    currentSprite.transform.localPosition = _getSpaceToRightOfNextSprite(nextSprite);
                }
            }
        }

        private Vector2 _getSpaceToRightOfNextSprite(
            Sprite nextSprite)
        {
            return nextSprite.transform.localPosition + new Vector2(nextSprite.width, 0);
        }
    }
}
