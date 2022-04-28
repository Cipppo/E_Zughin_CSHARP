namespace EZ_Csharp.utils;

public class FullPair<T, E> : Pair<T, E>
{
    public T X { get; set; }
    public E Y { get; set; }

    public FullPair(T x, E y)
    {
        X = x;
        Y = y;
    }
}