using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class GravitySystem : EntityProcessingSystem
    {
        public GravitySystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity)
        {
            var gravity = entity.getComponent<AffectedByGravity>();
        }
    }
}
