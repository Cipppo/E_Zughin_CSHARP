namespace Ball.Physics;

public abstract class Pos2D<T>
{
    public abstract T X { get; set; }
    public abstract T Y { get; set; }

    protected Pos2D(T x, T y)
    {
        X = x;
        Y = y;
    }
}