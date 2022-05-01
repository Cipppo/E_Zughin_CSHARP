using System.Reflection.Emit;
using Ball.Physics;

namespace Ball.Agent;

public class Ball
{
    public Trajectory Trajectory { get; }
    public SpherePos2D ActualPosition { get; }
    private readonly SpherePos2D _initialPosition;
    public Velocity2D Velocity { get; }
    private Time _time;
    private double _gravity;
    private int Size { get; }
    private readonly double _tickFactor;

    protected Ball(Trajectory trajectory, SpherePos2D position, double gravity, double tickFactor)
    {
        Trajectory = trajectory;
        ActualPosition = position;
        _initialPosition = new SpherePos2D(position.X, position.Y, position.Dimension, position.Diameter);
        Velocity = Trajectory.GetXyVelocity();
        _gravity = gravity;
        Size = position.Diameter;
        _time = new Time(0, 0);
        _tickFactor = tickFactor;
    }

    public void UpdatePos()
    {
        _time.Inc(_tickFactor);
        ActualPosition.X = _initialPosition.X + 0.001 * Velocity.Vx * _time.X;
        ActualPosition.Y = _initialPosition.Y -
                           0.001 * (Velocity.Vy * _time.Y - (0.5 * _gravity * Math.Pow(_time.Y, 2)));
    }

    public void ApplyConstraints(double position, Boundary bound)
    {
        if (bound is Boundary.Y0 or Boundary.Y1)
        {
            _initialPosition.Y = position;
            _time.ResetY();
            Velocity.InvertVy();
        }
        else
        {
            _initialPosition.X = position;
            _time.ResetY();
            Velocity.InvertVx();
        }
    }
}