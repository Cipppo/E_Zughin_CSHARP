namespace Ball.Physics;

public class Time
{
    public double X { get; private set; }
    public double Y { get; private set; }
    
    public Time(double x, double y) {
        X = x;
        Y = y;
    }

    public void Inc(double factor)
    {
        X += factor;
        Y += factor;
    }

    public void ResetX() => X = 0.0;

    public void ResetY() => Y = 0.0;

    public override string ToString()
    {
        return "Time(" + X + ", " + Y + ")";
    }
}