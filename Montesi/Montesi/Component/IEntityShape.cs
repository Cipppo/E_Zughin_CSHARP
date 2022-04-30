using Montesi.Utilities;

namespace Montesi.Component
{
    /// <summary>
    /// Models a useful class which can store a component position and his dimensions in the space.
    /// </summary>
    public interface IEntityShape
    {
        EntityPos2D Pos { get; }
        BirdPair<int, int> Dimension { get; }
    }
}