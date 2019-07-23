using Microsoft.Xna.Framework;
using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class ScoreCounter : Entity, IGameOverState
    {
        public ScoreCounter(int score)
        {
            addComponent(new ScoreCounting(score));
            addComponent(new DisplaysNumber(removeAfterBirdDies: false));
            addComponent(new DisplaysCurrentScore());

            this.position = new Vector2(
                GameConstants.SCREEN_WIDTH,
                GameConstants.SCREEN_HEIGHT);
        }

        public Entity Get()
        {
            return this;
        }

        public bool IsFinished()
        {
            var scoreCounting = getComponent<ScoreCounting>();
            return scoreCounting == null || scoreCounting.CurrentNumber >= scoreCounting.CountTo;
        }

        public bool RemoveAfterFinished()
        {
            return false;
        }
    }
}
