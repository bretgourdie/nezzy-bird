using System;
using Microsoft.Xna.Framework;
using Nez;

namespace NezzyBird.Components
{
    public abstract class Scrolling : Component
    {
        public readonly Vector2 Movement;

        public Scrolling(ScrollDirection scrollDirection, float rate)
        {
            Movement = determineMovement(scrollDirection, rate);
        }

        private Vector2 determineMovement(
            ScrollDirection scrollDirection,
            float rate)
        {
            switch (scrollDirection)
            {
                case ScrollDirection.Up:
                    return new Vector2(0, -rate);
                case ScrollDirection.Left:
                    return new Vector2(-rate, 0);
                case ScrollDirection.Down:
                    return new Vector2(0, rate);
                case ScrollDirection.Right:
                    return new Vector2(rate, 0);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
