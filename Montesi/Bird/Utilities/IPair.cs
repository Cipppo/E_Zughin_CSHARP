namespace Montesi.Utilities
{
    public interface IPair<T, E>
    {
        public T X { get; set; }
        public E Y { get; set; }
    }
}