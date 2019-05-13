using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ParallaxScrollingSystem : EntityProcessingSystem
    {
        private readonly ScrollingMovement _scrollingMovement;

        public ParallaxScrollingSystem(ScrollingMovement scrollingMovement) : base(
            new Matcher().all(
                typeof(ParallaxScrolling)
            ))
        {
            _scrollingMovement = scrollingMovement;
        }

        public override void onAdded(Entity entity)
        {
            var sprite = entity.getComponent<Sprite>();

            if (sprite == null)
            {
                throw new System.InvalidOperationException("Entity has no sprite to clone");
            }

            var secondarySprite = (Sprite)sprite.clone();


            secondarySprite.transform.localPosition = _getSpaceToRightOfNextSprite(sprite);

            var parallaxScrolling = entity.getComponent<ParallaxScrolling>();

            parallaxScrolling.ParallaxSprites = new Sprite[]
            {
                sprite,
                secondarySprite
            };
        }

        public override void process(Entity entity)
        {
            var parallaxScrolling = entity.getComponent<ParallaxScrolling>();
            var sprites = parallaxScrolling.ParallaxSprites;

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
