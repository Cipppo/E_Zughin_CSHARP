using Montesi.Utilities;

namespace Montesi.Component
{
    /// <summary>
    /// This class is the bird itself. It defines his dimension thanks to the shape and it can
    /// change the bird's position.
    /// </summary>
    public class BirdActor
    {
        private const int Width = 5;
        private const int Height = 3;
        public BirdShape S { get; private set; }

        /// <summary>
        /// Constructor that define the bird's dimension.
        /// </summary>
        /// <param name="startPos">Bird's position.</param>
        public BirdActor(EntityPos2D startPos)
        {
            S = new BirdShape(startPos, new BirdPair<int, int>(Width, Height));
        }

        /// <summary>
        /// This method changes the position of the bird to ne new desired position.
        /// </summary>
        /// <param name="pos">New position.</param>
        public void ChangeLocation(EntityPos2D pos)
        {
            S = new BirdShape(pos, new BirdPair<int, int>(Width, Height));
        }
    }
}