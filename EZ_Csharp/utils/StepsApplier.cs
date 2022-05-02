namespace EZ_Csharp.utils;

public class StepsApplier
{
    private const int HeroStep = 20;
    private const int BulletStep = 5;

    private readonly EntityPos2D StartPos;

    public StepsApplier(EntityPos2D startPos)
    {
        this.StartPos = startPos;
    }

    public EntityPos2D ConvertHeroPosition(EntityPos2D pos)
    {
        var x = (pos.X * HeroStep) + this.StartPos.X;
        return new EntityPos2D(x, this.StartPos.Y);
    }

}