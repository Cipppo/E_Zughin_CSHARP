namespace EZ_Csharp.utils;

public class Shape : EntityShape
{
    public EntityPos2D Pos { get; }

    public FullPair<int, int> Dimensions { get; }
        
    public Shape(EntityPos2D pos, FullPair<int, int> dimensions)
    {
        this.Pos = pos;
        this.Dimensions = dimensions;
    }

    public EntityPos2D GetLeftFoot()
    {
        return new EntityPos2D(this.Pos.X, this.Pos.Y + this.Dimensions.Y);
    }


}