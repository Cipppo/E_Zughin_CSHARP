using EZ_Csharp.hero;
using EZ_Csharp.utils;

namespace EZ_Csharp.Moover;

using FakeVisual;

public class Moover
{
    public FakeVisual Visual { get; }
    public Hero Hero { get;  }
    
    public BoundChecker Bc { get; }

    public Moover(FakeVisual visual, Hero hero)
    {
        this.Visual = visual;
        this.Hero = hero;
        this.Bc = new BoundChecker(new FullPair<int, int>(this.Visual.Width, this.Visual.Heigth));
    }

    public bool MoveRight()
    {
        if (this.Hero.IsAwake)
        {
            
        }
    }
}