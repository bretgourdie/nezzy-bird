using Microsoft.Xna.Framework;
using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class HighScoreDisplay : Entity, IGameOverState
    {
        public HighScoreDisplay(int score)
        {
            addComponent(new DisplaysNumber(removeAfterBirdDies: false));
            addComponent(new HighScoreContainer(score));

            this.position = new Vector2(
                GameConstants.SCREEN_WIDTH,
                GameConstants.SCREEN_HEIGHT);

            this.name = this.GetType().Name;
        }

        public Entity Get() => this;

        public bool IsFinished()
        {
            var highScoreContainer = this.getComponent<HighScoreContainer>();

            return highScoreContainer != null
                && highScoreContainer.IsHighScoreRetrieved
                && highScoreContainer.WasHighScoreWritten;
        }

        public bool RemoveAfterFinished() => false;
    }
}
