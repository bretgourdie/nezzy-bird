using Nez;

namespace NezzyBird.Components
{
    public class HighScoreContainer : Component
    {
        public bool IsHighScoreRetrieved { get; private set; }

        public bool WasHighScoreWritten { get; set; }

        public int HighScore { get; private set; }

        public readonly int PlayerScore;

        public bool WasNewHighScore { get; set; }

        public HighScoreContainer(int score)
        {
            PlayerScore = score;
        }

        public void SetHighScore(int highScore)
        {
            HighScore = highScore;
            IsHighScoreRetrieved = true;
        }
    }
}
