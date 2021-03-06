﻿using Nez;
using Nez.Sprites;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class DeathCollisionSystem : EntityProcessingSystem
    {
        private readonly Emitter<NezzyEvents> _emitter;
        private readonly CollisionSystem _collisionSystem;

        public DeathCollisionSystem(Emitter<NezzyEvents> emitter) :
            base(new Matcher()
                .all(
                    typeof(HasLife),
                    typeof(BoxCollider)
                )
            )
        {
            _emitter = emitter;
            _collisionSystem = new CollisionSystem(typeof(EndsGameOnCollision));
            _collisionSystem.OnCollision += onEndGameCollision;
        }

        private void onEndGameCollision(object sender, CollisionEventArgs e)
        {
            var entity = e.Entity;

            var hasLife = entity.getComponent<HasLife>();
            var spriteAnimation = entity.getComponent<Sprite<int>>();

            if (hasLife == null || !hasLife.IsAlive)
            {
                return;
            }

            hasLife.Kill();

            if (spriteAnimation != null && spriteAnimation.isPlaying)
            {
                spriteAnimation.stop();
            }

            _emitter.emit(NezzyEvents.BirdDied);
        }

        public override void process(Entity entity)
        {
            _collisionSystem.process(entity);
        }
    }
}
