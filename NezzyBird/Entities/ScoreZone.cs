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
                new Scrolling(
                    ScrollDirection.Left,
                    GameConstants.FOREGROUND_SCROLL_SPEED));

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

            this.name = $"{this.GetType().Name} {Time.timeSinceSceneLoad}";
        }
    }
}
