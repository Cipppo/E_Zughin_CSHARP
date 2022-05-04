using EZ_Csharp.hero;
using EZ_Csharp.utils;

namespace EZ_Csharp.Moover;

using FakeVisual;

public class Moover
{
    private const int Speed = 20;
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
        if (!this.Hero.IsAwake) return false;
        var actualHeroPos = this.Hero.Pos;
        var axisHeroPos = new StepsApplier(Visual.startPos).ConvertHeroPosition(actualHeroPos);
        if (this.Bc.IsInside(new EntityPos2D(axisHeroPos.X + Speed, axisHeroPos.Y),
                this.Visual.HeroComponent.S.Dimensions.X,
                this.Visual.HeroComponent.S.Dimensions.Y)) return false;
        this.Hero.Move(Directions.RIGHT);
        this.Visual.Move(new EntityPos2D(axisHeroPos.X + Speed, axisHeroPos.Y));
        this.Visual.SetDirection(this.Hero.Dir);
        return true;
    }

    public bool MoveLeft()
    {
        if (!this.Hero.IsAwake) return false;
        var actualHeroPos = this.Hero.Pos;
        var axisHeroPos = new StepsApplier(Visual.startPos).ConvertHeroPosition(actualHeroPos);
        if (this.Bc.IsInside(new EntityPos2D(axisHeroPos.X - Speed, axisHeroPos.Y),
                this.Visual.HeroComponent.S.Dimensions.X,
                this.Visual.HeroComponent.S.Dimensions.Y)) return false;
        this.Hero.Move(Directions.LEFT);
        this.Visual.Move(new EntityPos2D(axisHeroPos.X - Speed, axisHeroPos.Y));
        this.Visual.SetDirection(this.Hero.Dir);
        return true;
    }
}