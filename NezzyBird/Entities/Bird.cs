using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Bird : Entity
    {
        public static readonly float GRAVITY_WEIGHT = 0.50f;
        public static readonly float JUMP_HEIGHT = 9f;

        public Bird(TextureAtlas textureAtlas)
        {
            var randomBirdIndex = Random.choose(0, 1, 2);
            var birdFlapAnimation = textureAtlas.getSpriteAnimation($"Bird{randomBirdIndex}");
            var birdIdleSprite = birdFlapAnimation.frames.lastItem();
            var sprite = new Sprite(birdIdleSprite);
            sprite.renderLayer = GameConstants.RenderingLevels.Bird;
            addComponent(sprite);
            addComponent(new AffectedByGravity(GRAVITY_WEIGHT));
            var jumpsOnTap = new JumpsOnTap(JUMP_HEIGHT);
            addComponent(new ReactsToTap(jumpsOnTap, jumpsOnTap.Jump));
            addComponent(new Mover());
            addComponent(new BoxCollider() { isTrigger = true });
            addComponent(new HasVelocity());
            addComponent(new HasScore());
            addComponent(new HasLife());
            addComponent(new WaitsForFirstTap());

            this.scale = GameConstants.GetGameScale();

            this.position = new Vector2(125, 400);
        }
    }
}
