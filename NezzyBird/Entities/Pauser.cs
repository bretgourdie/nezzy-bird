using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Pauser : Entity, IGameOverState
    {
        public Pauser()
        {
            addComponent(new Pause());
            this.name = this.GetType().Name;
        }

        public Entity Get()
        {
            return this;
        }

        public bool IsFinished()
        {
            return !this.enabled;
        }

        public bool RemoveAfterFinished()
        {
            return true;
        }
    }
}
