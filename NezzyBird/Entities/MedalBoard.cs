using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Tweens;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class MedalBoard : Entity, IGameOverState
    {
        public MedalBoard(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("MedalBoard");
            var sprite = new Sprite(subtexture);
            addComponent(sprite);

            var startPosition = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                -GameConstants.SCREEN_HEIGHT / 4);

            var endPosition = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 2);

            var floatInFromTop = new FloatInFromTop(
                startPosition,
                endPosition,
                EaseType.Linear,
                1f);

            addComponent(floatInFromTop);

            this.position = startPosition;

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }

        public Entity Get()
        {
            return this;
        }

        public bool IsFinished()
        {
            return this.getComponent<FloatInFromTop>() == null;
        }

        public bool RemoveAfterFinished()
        {
            return false;
        }
    }
}
