namespace Montesi.Utilities
{
    public class BirdShape : IEntityShape
    {
        public EntityPos2D Pos { get; }
        public BirdPair<int, int> Dimension { get; }
        private Directions Dir { get; }
        
        public BirdShape(EntityPos2D pos, BirdPair<int, int> dimension, Directions dir)
        {
            Pos = pos;
            Dimension = dimension;
            Dir = dir;
        }

    }
}