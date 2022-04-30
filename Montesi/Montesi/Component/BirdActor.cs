using Montesi.Utilities;

namespace Montesi.Component
{
    public class BirdActor
    {
        private const int Width = 5;
        private const int Height = 3;
        
        public BirdShape S { get; private set; }

        public BirdActor(EntityPos2D startPos)
        {
            S = new BirdShape(startPos, new BirdPair<int, int>(Width, Height));
        }

        public void ChangeLocation(EntityPos2D pos)
        {
            S = new BirdShape(pos, new BirdPair<int, int>(Width, Height));
        }
    }
}