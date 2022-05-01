namespace Ball.Physics;

public static class Dimension
{
    public static Dimensions GetChild(Dimensions dim)
    {
        return dim switch
        {
            Dimensions.Father => Dimensions.Son,
            Dimensions.Son => Dimensions.Grandson,
            _ => Dimensions.None
        };
    }
}
public enum Dimensions
{
    Father = 100,
    Son = 85, 
    Grandson = 50, 
    None = 0
}