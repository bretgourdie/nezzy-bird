using Microsoft.Xna.Framework;
using Nez;
using System.IO;

namespace NezzyBird.Systems
{
    public class HighScoreSystem : PassiveSystem
    {
        public int HighScore { get; private set; }

        private const string _highScoreFile = "HighScore.txt";

        public HighScoreSystem()
        {
            HighScore = _retrieveScore();
        }

        private int _retrieveScore()
        {
            using (var fsHighScore = TitleContainer.OpenStream(_highScoreFile))
            {
                using (var streamReader = new StreamReader(fsHighScore))
                {
                    var sHighScore = streamReader.ReadLine();

                    int highScore;
                    if (int.TryParse(sHighScore, out highScore))
                    {
                        return highScore;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public void SetScore(int newScore)
        {
            if (newScore <= HighScore)
            {
                return;
            }

            HighScore = newScore;

            using (var fsHighScore = TitleContainer.OpenStream(_highScoreFile))
            {
                using (var streamWriter = new StreamWriter(fsHighScore))
                {
                    streamWriter.Write(HighScore);
                }
            }
        }
    }
}
