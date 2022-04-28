namespace EZ_Csharp.utils;

public class EntityPos2D<T> : Pos2D<T>
{
    public EntityPos2D(T x, T y)
    {
        this.x = x;
        this.y = y;
    }

    public override T X
    {
        get => this.x;
        set => this.x = value;
    }

    public override T Y
    {
        get => this.y;
        set => this.y = value;
    }

    public override string ToString()
    {
        return "X = " + this.x + " Y = " + this.y;
    }
}