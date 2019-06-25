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
                if (gameOverState.RemoveEntityAfterFinished)
                {
                    gameOverState.CurrentEntity.setEnabled(false);
                }

                gameOverState.AdvanceToNextEntity();
            }

            var currentEntity = gameOverState.CurrentEntity;

            currentEntity.update();
        }
    }
}
