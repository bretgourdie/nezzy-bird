using Nez;
using System;

namespace NezzyBird.Systems
{
    public class CollisionSystem : EntityProcessingSystem
    {
        private readonly Type _targetType;
        private readonly Action<Entity, Collider> _onCollisionAction;

        public CollisionSystem(
            Type targetType,
            Action<Entity, Collider> onCollisionAction) : base(Matcher.empty())
        {
            _targetType = targetType;
            _onCollisionAction = onCollisionAction;
        }

        public override void process(Entity entity)
        {
            var boxCollider = entity.getComponent<BoxCollider>();

            var colliders = Physics.boxcastBroadphaseExcludingSelf(boxCollider);

            foreach (var collider in colliders)
            {
                if (isColliding(boxCollider, collider))
                {
                    if (collider.entity.GetType().Equals(_targetType))
                    {
                        _onCollisionAction.Invoke(entity, collider);
                    }
                }
            }
        }

        private bool isColliding(
            Collider entityCollider,
            Collider otherCollider)
        {
            CollisionResult collisionResult;
            return entityCollider.collidesWith(otherCollider, out collisionResult);
        }
    }
}
