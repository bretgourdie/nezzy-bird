using Microsoft.Xna.Framework;
using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class JumpSystem : EntityProcessingSystem
    {

        public JumpSystem() : base(
            new Matcher().all(typeof(JumpsOnTap)))
        { }

        public override void process(Entity entity)
        {
            var jump = entity.getComponent<JumpsOnTap>();
            var velocity = entity.getComponent<HasVelocity>();

            if (jump.IsJumping)
            {
                velocity.CurrentVelocity = new Vector2(0, -jump.GetJumpAmount());
            }
        }
    }
}
