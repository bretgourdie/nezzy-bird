using Nez;
using Nez.Sprites;
using NezzyBird.Entities;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class DisplaysNumber : Component
    {
        private readonly HasScore _hasScore;

        public List<Number> Numbers { get; private set; }

        public int NumbersCount { get { return Numbers.Count; } }

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
            Numbers = new List<Number>();
        }

        public void AddNumber(Number number)
        {
            Numbers.Add(number);
        }

        public void SetNumber(int index, Sprite sprite)
        {
            Numbers[index].SetSprite(sprite);
        }
    }
}
