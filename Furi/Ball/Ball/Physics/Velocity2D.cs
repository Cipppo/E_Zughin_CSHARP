namespace Ball.Physics;

public class Velocity2D
{
    public  double Vx { get; private set; }
    public double Vy { get; private set; }

    public Velocity2D(double vx, double vy)
    {
        Vx = vx;
        Vy = vy;
    }
    public void InvertVx() => Vx *= -1;

    public void InvertVy() => Vy *= -1;
}