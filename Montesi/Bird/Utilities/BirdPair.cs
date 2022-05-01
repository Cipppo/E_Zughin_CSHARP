namespace Montesi.Utilities
{
    public class BirdPair<T, TE> : IPair<T, TE>
    {
        public T X { get; set; }
        public TE Y { get; set; }

        public BirdPair(T x, TE y)
        {
            X = x;
            Y = y;
        }
    }
}