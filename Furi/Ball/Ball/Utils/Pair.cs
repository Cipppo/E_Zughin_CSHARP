namespace Ball.Utils;

public class Pair<T>
{
    public T X { get; set; }
    public T Y { get; set; }

    public Pair(T x, T y)
    {
        X = x;
        Y = y;
    }
}