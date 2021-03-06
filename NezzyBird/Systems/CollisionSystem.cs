﻿using Nez;
using System;

namespace NezzyBird.Systems
{
    public class CollisionSystem : EntityProcessingSystem
    {
        private readonly Type _targetType;

        public event EventHandler<CollisionEventArgs> OnCollision;

        public CollisionSystem(
            Type targetType) : base(Matcher.empty())
        {
            _targetType = targetType;
        }

        public override void process(Entity entity)
        {
            var boxCollider = entity.getComponent<BoxCollider>();

            var colliders = Physics.boxcastBroadphaseExcludingSelf(boxCollider);

            foreach (var collider in colliders)
            {
                if (isColliding(boxCollider, collider))
                {
                    var components = collider.entity.components;
                    for (int ii = 0; ii < components.count; ii++)
                    {
                        var currentComponent = components[ii];

                        if (currentComponent.GetType().Equals(_targetType))
                        {
                            OnCollision(this, new CollisionEventArgs(entity, collider));
                        }
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
