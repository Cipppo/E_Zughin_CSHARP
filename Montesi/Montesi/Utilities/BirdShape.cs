namespace Montesi.Utilities
{
    public class BirdShape : IEntityShape
    {
        public EntityPos2D Pos { get; }
        public BirdPair<int, int> Dimension { get; }
        private BirdDirections Dir { get; }
        
        public BirdShape(EntityPos2D pos, BirdPair<int, int> dimension, BirdDirections dir)
        {
            Pos = pos;
            Dimension = dimension;
            Dir = dir;
        }

    }
}