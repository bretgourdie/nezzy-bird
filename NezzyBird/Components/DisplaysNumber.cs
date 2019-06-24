using Nez;
using Nez.Sprites;
using NezzyBird.Entities;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class DisplaysNumber : Component
    {
        public List<Number> NumberSpriteHolders { get; private set; }

        public int NumberSpriteHoldersCount { get { return NumberSpriteHolders.Count; } }

        public int Number { get; private set; }

        public bool NumberNeedsToBeUpdated { get; private set; }

        public DisplaysNumber()
        {
            NumberSpriteHolders = new List<Number>();
            NumberNeedsToBeUpdated = true;
        }

        public void OnNumberUpdated()
        {
            NumberNeedsToBeUpdated = true;
            Number += 1;
        }

        public void HandleUpdatedNumber()
        {
            NumberNeedsToBeUpdated = false;
        }

        public void AddNumberSpriteHolder(Number number)
        {
            NumberSpriteHolders.Add(number);
        }

        public void SetNumberSprite(int index, Sprite sprite)
        {
            NumberSpriteHolders[index].SetSprite(sprite);
        }
    }
}
