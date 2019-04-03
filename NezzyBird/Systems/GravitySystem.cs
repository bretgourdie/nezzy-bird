﻿using Microsoft.Xna.Framework;
using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class GravitySystem : EntityProcessingSystem
    {
        public GravitySystem() :
            base(new Matcher().all(
                typeof(AffectedByGravity),
                typeof(Mover),
                typeof(HasVelocity)
            )) { }

        public override void process(Entity entity)
        {
            var gravity = entity.getComponent<AffectedByGravity>();
            var mover = entity.getComponent<Mover>();
            var velocity = entity.getComponent<HasVelocity>();

            velocity.CurrentVelocity =
                new Vector2(
                    velocity.CurrentVelocity.X,
                    velocity.CurrentVelocity.Y + gravity.GravitationalPull);

            var collisionResult = new CollisionResult();
            mover.move(velocity.CurrentVelocity, out collisionResult);
        }
    }
}
