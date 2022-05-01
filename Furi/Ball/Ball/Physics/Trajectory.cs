namespace Ball.Physics;

public class Trajectory
{
    public double Theta { get; private set; }
    public double InitialVelocity { get; private set; }

    public Trajectory(double theta, double initialVelocity)
    {
        Theta = theta;
        InitialVelocity = initialVelocity;
    }

    private double Vx => InitialVelocity * Math.Cos(Math.PI * Theta / 180);
    private double Vy => InitialVelocity * Math.Sin(Math.PI * Theta / 180);

    public Velocity2D GetXyVelocity() => new Velocity2D(Vx, Vy);
}