namespace Montesi.Utilities
{
    public interface IPair<T, TE>
    {
        public T X { get; set; }
        public TE Y { get; set; }
    }
}