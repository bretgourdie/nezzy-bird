using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class PipePairSpawner : Entity
    {
        public PipePairSpawner()
        {
            addComponent(new SpawnsPipePair(1.75f));
            this.name = this.GetType().Name;
        }
    }
}
