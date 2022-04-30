namespace Montesi.Utilities
{
    public class BirdPair<T, E> : IPair<T, E>
    {
        public T X { get; set; }
        public E Y { get; set; }

        public BirdPair(T x, E y)
        {
            X = x;
            Y = y;
        }
    }
}