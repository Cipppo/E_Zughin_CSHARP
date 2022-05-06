namespace Montesi.Utilities
{
    /// <summary>
    /// This class checks if the position of the bird is out of the stage bounds or not.
    /// </summary>
    public class BirdBoundChecker
    {
        public BirdPair<int, int> X { get; }
        public BirdPair<int, int> Y { get; }

        /// <summary>
        /// Initializes the bounds with the stage's ones.
        /// </summary>
        /// <param name="x">Abscissas' bounds, lefter and righter.</param>
        /// <param name="y">Ordinates' bounds, upper and lower.</param>
        public BirdBoundChecker(BirdPair<int, int> x, BirdPair<int, int> y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Checks if the bird's position is inside the bounds.
        /// </summary>
        /// <param name="pos">Bird's position.</param>
        /// <param name="width">Bird's width.</param>
        /// <param name="height">Bird's height.</param>
        /// <returns>If the bird is inside the stage or not.</returns>
        public bool IsInside(EntityPos2D pos, int width, int height)
        {
            return (pos.X >= X.X && pos.X + width <= X.Y) && (pos.Y >= Y.X && pos.Y + height <= Y.Y);
        }
    }
}