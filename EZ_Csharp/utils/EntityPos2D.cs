namespace EZ_Csharp.utils;

public class EntityPos2D : Pos2D<int>
{
    public EntityPos2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override int X
    {
        get => this.x;
        set => this.x = value;
    }

    public override int Y
    {
        get => this.y;
        set => this.y = value;
    }

    public override string ToString()
    {
        return "X = " + this.x + " Y = " + this.y;
    }
}