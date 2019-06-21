using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace NezzyBird.Entities
{
    public class Number : Entity
    {
        public Number(
            int position,
            int spriteWidth)
        {
            const int spritePadding = 2;
            var x =
                GameConstants.SCREEN_WIDTH * .5f
                - position * spriteWidth * GameConstants.SPRITE_SCALE_FACTOR
                + spritePadding;
            const float percentageFromTopOfScreen = .10f;

            this.position = new Vector2(
                x,
                GameConstants.SCREEN_HEIGHT * percentageFromTopOfScreen);
            this.scale = GameConstants.GetGameScale();

            this.name = $"{this.GetType().Name} {Time.timeSinceSceneLoad}";
        }

        public void SetSprite(Sprite sprite)
        {
            removeComponent<Sprite>();
            addComponent(sprite);
        }
    }
}
