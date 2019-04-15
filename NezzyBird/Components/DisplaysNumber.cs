using Nez;

namespace NezzyBird.Components
{
    public class DisplaysNumber : Component
    {
        private readonly HasScore _hasScore;

        public int Score { get; private set; }

        public bool ScoreNeedsUpdated()
        {
            return Score != _hasScore.Score;
        }

        public void UpdateScore()
        {
            Score = _hasScore.Score;
        }

        public DisplaysNumber(HasScore hasScore)
        {
            _hasScore = hasScore;
        }
    }
}
