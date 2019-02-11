using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Pipe : Entity
    {
        public static readonly float SCROLL_SPEED = 1f;
        public Pipe(VerticalDirection.MouthOpens mouthOpens)
        {
            addComponent(new VerticalDirection(mouthOpens));
            addComponent(new ScrollingLeft(SCROLL_SPEED));
            addComponent(new Mover());
            addComponent(new EndsGameOnCollision());

            this.scale = GameConstants.GetGameScale();
        }
    }
}
