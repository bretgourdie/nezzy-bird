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
        private const int _birdFlapAnimation = 0;

        public Bird(TextureAtlas textureAtlas, bool useTitleScreenBird = false)
        {
            if (useTitleScreenBird)
            {
                var birdFlapAnimation = textureAtlas.getSpriteAnimation($"Bird0");
                var birdIdleSprite = birdFlapAnimation.frames.lastItem();
                var sprite = new Sprite(birdIdleSprite);
                sprite.setRenderLayer(GameConstants.RenderingLevels.Bird);
                addComponent(sprite);
            }
            else
            {
                var randomBirdIndex = Random.choose(0, 1, 2);
                var birdFlapAnimation = textureAtlas.getSpriteAnimation($"Bird{randomBirdIndex}");
                birdFlapAnimation.setFps(30);
                birdFlapAnimation.setLoop(true);
                var birdFlapT = new Sprite<int>(_birdFlapAnimation, birdFlapAnimation);
                birdFlapT.setRenderLayer(GameConstants.RenderingLevels.Bird);
                addComponent(birdFlapT);
                birdFlapT.play(_birdFlapAnimation);
            }

            addComponent(new AffectedByGravity(GRAVITY_WEIGHT));
            addComponent(new JumpsOnTap(JUMP_HEIGHT));
            addComponent(new Mover());
            addComponent(new BoxCollider() { isTrigger = true });
            addComponent(new HasVelocity());
            addComponent(new HasScore());
            addComponent(new HasLife());
            addComponent(new WaitsForFirstTap());

            this.scale = GameConstants.GetGameScale();

            this.position = new Vector2(125, 350);

            this.name = this.GetType().Name;
        }
    }
}
