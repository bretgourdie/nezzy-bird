using Nez;
using Nez.Sprites;
using NezzyBird.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NezzyBird.Systems
{
    public class ParallaxScrollingSystem : EntityProcessingSystem
    {

        public ParallaxScrollingSystem() :
            base(new Matcher().all(
                typeof(ParallaxScrolling),
                typeof(Mover),
                typeof(Sprite)
            ))
        { }

        public override void process(Entity entity)
        {
            var parallaxScrolling = entity.getComponent<ParallaxScrolling>();
            var mover = entity.getComponent<Mover>();


        }
    }
}
