using Montesi.Utilities;

namespace Montesi.Component
{
    public interface IEntityShape
    {
        EntityPos2D Pos { get; }
        BirdPair<int, int> Dimension { get; }
    }
}