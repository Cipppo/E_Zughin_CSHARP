namespace EZ_Csharp.utils;

public class Optional<T>
{
    private T value;
    public bool isPresent { get; private set; } = false;

    private Optional() { }

    public static Optional<T> Empty()
    {
        return new Optional<T>();
    }

    public static Optional<T> of(T value)
    {
        var obj = new Optional<T>();
        obj.Set(value);
        return obj;
    }

    public void Set(T value)
    {
        this.value = value;
        isPresent = true;
    }

    public T Get()
    {
        return value;
    }
}