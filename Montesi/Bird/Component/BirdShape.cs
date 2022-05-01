using Montesi.Utilities;

namespace Montesi.Component
{
    public class BirdShape : IEntityShape
    {
        public EntityPos2D Pos { get; }
        public BirdPair<int, int> Dimension { get; }

        /// <summary>
        /// This constructor creates a new rectangle for the bird.
        /// </summary>
        /// <param name="pos">Bird's position.</param>
        /// <param name="dimension">Width and height of the bird.</param>
        public BirdShape(EntityPos2D pos, BirdPair<int, int> dimension)
        {
            Pos = pos;
            Dimension = dimension;
        }

    }
}