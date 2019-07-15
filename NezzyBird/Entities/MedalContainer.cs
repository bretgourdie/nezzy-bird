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

            const int xOffsetFromCenter = -98;
            const int yOffsetFromCenter =  12;
            this.position = new Vector2(
                GameConstants.SCREEN_WIDTH / 2 + xOffsetFromCenter,
                GameConstants.SCREEN_HEIGHT / 2 + yOffsetFromCenter);
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
