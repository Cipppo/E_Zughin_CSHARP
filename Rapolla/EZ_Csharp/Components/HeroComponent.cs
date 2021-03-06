using EZ_Csharp.utils;

namespace EZ_Csharp.Components;

public class HeroComponent
{
    private const int Width = 40;
    private const int Height = 50;

    public Shape S { get; private set; }

    public HeroComponent(EntityPos2D startPos)
    {
        this.S = new Shape(startPos, new FullPair<int, int>(Width, Height));
    }

    public void ChangeLocation(EntityPos2D pos)
    {
        this.S = new Shape(pos, new FullPair<int, int>(Width, Height));
    }
    
}