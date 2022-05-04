namespace EZ_Csharp.utils;

public class EntityPos2D : Pos2D<int>
{
    public EntityPos2D(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override int X
    {
        get;
        set;
    }

    public override int Y
    {
        get;
        set;
    }

    public override string ToString()
    {
        return "X = " + this.X + " Y = " + this.Y;
    }

    protected bool Equals(EntityPos2D other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((EntityPos2D)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}