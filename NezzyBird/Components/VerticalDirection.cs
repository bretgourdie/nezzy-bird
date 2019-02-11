using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace NezzyBird.Components
{
    public class VerticalDirection : Component
    {
        public enum MouthOpens
        {
            Up,
            Down
        }

        private readonly MouthOpens _openDirection;

        public VerticalDirection(MouthOpens openDirection)
        {
            _openDirection = openDirection;
        }
    }
}
