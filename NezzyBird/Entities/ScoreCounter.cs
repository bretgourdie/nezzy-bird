using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class ScoreCounter : Entity, IGameOverState
    {
        public ScoreCounter(int score)
        {
            addComponent(new ScoreCounting(score));
        }

        public Entity Get()
        {
            return this;
        }

        public bool IsFinished()
        {
            var scoreCounting = getComponent<ScoreCounting>();
            return scoreCounting == null || scoreCounting.CurrentNumber < scoreCounting.CountTo;
        }

        public bool RemoveAfterFinished()
        {
            return false;
        }
    }
}
