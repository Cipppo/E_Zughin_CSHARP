using EZ_Csharp.utils;

namespace EZ_Csharp.FakeVisual;

public class BoundChecker
{
    private FullPair<int, int> Bounds;

    public BoundChecker(FullPair<int, int> guiBounds)
    {
        this.Bounds = guiBounds;
    }

    public bool IsInside(EntityPos2D pos, int width, int heigth)
    {
        return pos.X >= this.Bounds.X && pos.X + width <= Bounds.X;
    }

    public bool IsExtendible(EntityPos2D pos)
    {
        return pos.Y > 0 ? true : false;
        
    }
}