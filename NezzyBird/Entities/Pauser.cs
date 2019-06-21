using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Pauser : Entity
    {
        public Pauser()
        {
            addComponent(new Pause());
            this.name = this.GetType().Name;
        }
    }
}
