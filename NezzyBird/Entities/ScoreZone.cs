using Nez;
using Nez.Systems;
using NezzyBird.Components;
using NezzyBird.Systems;

namespace NezzyBird.Entities
{
    public class ScoreZone : Entity
    {
        public ScoreZone(Emitter<NezzyEvents> emitter)
        {
            addComponent(new Mover());
            addComponent(new IncreasesScoreWhenPassing());
            addComponent(
                new SimpleScrolling(
                    ScrollDirection.Left,
                    GameConstants.PIPE_SCROLL_SPEED,
                    emitter));

            var boxCollider = new BoxCollider(
                1f,
                GameConstants.SCREEN_HEIGHT)
            {
                isTrigger = true,
                height = GameConstants.SCREEN_HEIGHT
            };

            addComponent(boxCollider);

            var startingX = GameConstants.SCREEN_WIDTH + 200;
            this.position = new Microsoft.Xna.Framework.Vector2(startingX, this.position.Y);
        }
    }
}
