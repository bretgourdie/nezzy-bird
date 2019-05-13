using Microsoft.Xna.Framework;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class ScrollingMovement
    {
        public Vector2 Convert(
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
                    throw new System.NotImplementedException();
            }
        }
    }
}
