using Nez;
using Nez.Sprites;

namespace NezzyBird.Components
{
    public class MedalContaining : Component
    {
        public readonly int Score;

        public bool IsMedalSet => Medal != null;

        private Entity _medal;

        public Entity Medal
        {
            get => _medal;
            set
            {
                _medal = value;
                _medal.setParent(entity);
                entity.scene.addEntity(_medal);
            }
        }

        public MedalContaining(int score)
        {
            Score = score;
        }
    }
}
