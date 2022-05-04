namespace EZ_Csharp.utils;

public interface EntityShape
{
    EntityPos2D Pos { get; }

    FullPair<int, int> Dimensions { get; }
}