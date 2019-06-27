using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Tweens;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class GameOverGraphic : Entity, IGameOverState
    {
        public GameOverGraphic(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("GameOver");
            var sprite = new Sprite(subtexture);
            addComponent(sprite);

            addComponent(new Fades(FadeDirection.In, 1f));

            var startPosition = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                -GameConstants.SCREEN_HEIGHT / 8);

            var endPosition = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 4);

            addComponent(
                new FloatIn(
                    startPosition,
                    endPosition,
                    EaseType.BackOut,
                    1f));

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
            return this.getComponent<Fades>() == null;
        }

        public bool RemoveAfterFinished()
        {
            return false;
        }
    }
}
