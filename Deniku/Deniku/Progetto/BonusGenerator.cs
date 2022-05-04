using System;
namespace Progetto
{
    public class BonusGenerator
    {
        private const int BONUS_WIDTH = 20;
        private const int BONUS_HEIGHT = 20;

        private const int baseScore = 100;
        private Pair<int, int> bounds;

        public BonusGenerator(Pair<int, int> bounds)
        {
            this.bounds = bounds;
        }

        private int GetRandomInt(int bound)
        {
            Random rnd = new Random();
            return rnd.Next(bound);
        }

        private int GenerateNextScore()
        {
            return baseScore * (this.GetRandomInt(8) +1 );
        }

        private EntityPos2D GenerateRandomPos()
        {
            Random rnd = new Random();
            return new EntityPos2D(rnd.Next(bounds.GetX() - BONUS_WIDTH), bounds.GetY() - BONUS_HEIGHT);
        }
    }
}
