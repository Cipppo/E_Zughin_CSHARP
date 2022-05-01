namespace Montesi.Utilities
{
    public abstract class Pos2D<T>
    {
        protected T x;
        protected T y;
        
        public abstract T X { get; set; }
        public abstract T Y { get; set; }
    }
}