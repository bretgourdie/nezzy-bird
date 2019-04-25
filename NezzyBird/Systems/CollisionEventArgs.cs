using Nez;
using System;

namespace NezzyBird.Systems
{
    public class CollisionEventArgs : EventArgs
    {
        public readonly Entity Entity;
        public readonly Collider CollidedWith;

        public CollisionEventArgs(Entity entity, Collider collidedWith)
        {
            Entity = entity;
            CollidedWith = collidedWith;
        }
    }
}
