using Montesi.Utilities;

namespace Montesi.Component
{
    public class BirdShape : IEntityShape
    {
        public EntityPos2D Pos { get; }
        public BirdPair<int, int> Dimension { get; }

        public BirdShape(EntityPos2D pos, BirdPair<int, int> dimension)
        {
            Pos = pos;
            Dimension = dimension;
        }

    }
}