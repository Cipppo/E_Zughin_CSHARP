namespace Montesi.Utilities
{
    public interface IEntityShape
    {
        EntityPos2D Pos { get; }
        BirdPair<int, int> Dimension { get; }
    }
}