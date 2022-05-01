namespace Ball.Physics;

public abstract class Pos2D<T>
{
    protected abstract T X { get; set; }
    protected abstract T Y { get; set; }

    protected Pos2D(T x, T y)
    {
        X = x;
        Y = y;
    }
}