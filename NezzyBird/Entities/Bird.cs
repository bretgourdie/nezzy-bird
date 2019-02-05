using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Tiled;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Bird : Entity
    {
        private const float GRAVITY_WEIGHT = 0.25f;
        private const float JUMP_HEIGHT = 4.5f;

        public Bird(TextureAtlas textureAtlas)
        {
            var birdFlapAnimation = textureAtlas.getSpriteAnimation("BirdAnimation");
            var birdIdleSprite = birdFlapAnimation.frames.lastItem();
            addComponent(new Sprite(birdIdleSprite));
            addComponent(new AffectedByGravity(GRAVITY_WEIGHT));
            addComponent(new JumpsOnTap(JUMP_HEIGHT));
            addComponent(new Mover());
            addComponent(new HasVelocity());

            this.scale = GameConstants.GetGameScale();

            this.position = new Vector2(200, 200);
        }
    }
}
