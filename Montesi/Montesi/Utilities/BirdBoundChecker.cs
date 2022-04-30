using System;

namespace Montesi.Utilities
{
    public class BirdBoundChecker
    {
        public BirdPair<int, int> X { get; }
        public BirdPair<int, int> Y { get; }

        public BirdBoundChecker(BirdPair<int, int> x, BirdPair<int, int> y)
        {
            X = x;
            Y = y;
        }

        public bool IsInside(EntityPos2D pos, int width, int height)
        {
            return (pos.X >= X.X && pos.X + width <= X.Y) && (pos.Y >= Y.X && pos.Y + height <= Y.Y);
        }
    }
}