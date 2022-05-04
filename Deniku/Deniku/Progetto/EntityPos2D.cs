using System;
namespace Progetto
{
    public abstract class Pos2D<T>
    {
        protected T x;
        protected T y;

        public abstract T X { set; get; }

        public abstract T Y { set; get; }
    }

    public class EntityPos2D : Pos2D<int>
    {
        public EntityPos2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override int X
        {
            get => x;
            set => x = value;
        }

        public override int Y
        {
            get => y;
            set => y = value;
        }
    }
}
