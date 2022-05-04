using System;
namespace Progetto
{

    public class Pair<T, E>
    {
        private T x;
        private E y;

        public Pair(T x, E y)
        {
            this.x = x;
            this.y = y;
        }

        public T GetX()
        {
            return x;
        }

        public E GetY()
        {
            return y;
        }

        public override string ToString()
        {
            return string.Format("Pair({0}, {1})", x, y);
        }
    }
}
