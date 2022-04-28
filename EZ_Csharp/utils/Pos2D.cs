namespace EZ_Csharp.utils;

public abstract class Pos2D<T>
{
    protected T x;
    protected T y;
    
    public abstract T X { set; get; }
    public abstract T Y { set; get; }
}