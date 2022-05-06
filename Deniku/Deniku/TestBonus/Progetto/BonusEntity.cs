using System;
namespace Progetto
{
    public class BonusEntity : Pickable
    {
        private int points;

        public BonusEntity(int points, Shape shape) : base(shape)
        {
            this.points = points;
        }

        public int GetPoints() { return points; }
    }
}
