using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class GameOverSystem : EntityProcessingSystem
    {
        public GameOverSystem() : base(
            new Matcher().all(
                typeof(GameOverState)
        ))
        { }

        public override void process(Entity entity)
        {
            var gameOverState = entity.getComponent<GameOverState>();

            if (gameOverState.CurrentEntityIsComplete)
            {
                gameOverState.AdvanceToNextEntity();
            }

            var currentEntity = gameOverState.GetCurrentEntity();

            currentEntity.update();
        }
    }
}
