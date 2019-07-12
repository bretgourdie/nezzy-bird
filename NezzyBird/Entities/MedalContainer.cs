using Microsoft.Xna.Framework;
using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class MedalContainer : Entity, IGameOverState
    {
        public MedalContainer(int score)
        {
            addComponent(new MedalContaining(score));
            this.position = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 2);
        }

        public Entity Get() => this;

        public bool IsFinished()
        {
            var medalContaining = this.getComponent<MedalContaining>();
            return medalContaining != null && medalContaining.IsMedalSet;
        }

        public bool RemoveAfterFinished() => false;
    }
}
