using Ball.Physics;

namespace Ball.Agent;

public class BallFactory
{
    private const double MAX_ANGLE = 80;
    private const double MIN_ANGLE = 50;
    private const double MAX_VELOCITY = 150;
    private const double MIN_VELOCITY = 80;

    private const double EARTH_GRAVITY = 9.81;
    private const double MOON_GRAVITY = 1.62;

    private const double STD_TICK = 0.07;

    private static Ball RandomVelAndAngleBall(SpherePos2D pos)
    {
        Random rand = new Random();
        var angle = rand.NextDouble() * (MAX_ANGLE - MIN_ANGLE) + MIN_ANGLE;
        var initialVelocity = rand.NextDouble() * (MAX_VELOCITY - MIN_VELOCITY) + MIN_VELOCITY;

        return CompleteBall(angle, initialVelocity, pos, EARTH_GRAVITY, STD_TICK);
    }

    public static Ball RandomPos()
    {
        Random rand = new Random();
        SpherePos2D pos = new SpherePos2D(rand.NextDouble(), 0, Dimensions.Father, 50);
        return RandomVelAndAngleBall(pos);
    }

    public static Ball MoonBall()
    {
        var ball = RandomPos();
        return CompleteBall(
            ball.Trajectory.Theta,
            ball.Trajectory.InitialVelocity,
            new SpherePos2D(
                ball.ActualPosition.X,
                ball.ActualPosition.Y,
                ball.ActualPosition.Dimension,
                ball.ActualPosition.Diameter),
            MOON_GRAVITY,
            STD_TICK);
    }

    public static Ball SpeedBall(double tick)
    {
        var ball = RandomPos();
        return CompleteBall(ball.Trajectory.Theta,
            ball.Trajectory.InitialVelocity,
            new SpherePos2D(ball.ActualPosition.X,
                ball.ActualPosition.Y,
                ball.ActualPosition.Dimension,
                ball.ActualPosition.Diameter),
            EARTH_GRAVITY,
            tick);
    }

    public static Ball CompleteBall(double angle, double initialVelocity, SpherePos2D pos, double gravity, double tick)
    {
        Trajectory traj = new Trajectory(angle, initialVelocity);
        return new Ball(traj, pos, gravity, tick);
    }

    public static Ball FromFatherBall(Ball ball)
    {
        SpherePos2D newPos = new SpherePos2D(
            ball.ActualPosition.X,
            ball.ActualPosition.Y,
            ball.ActualPosition.Dimension,
            ball.ActualPosition.Diameter);

        return CompleteBall(
            ball.Trajectory.Theta,
            ball.Trajectory.InitialVelocity,
            newPos,
            EARTH_GRAVITY,
            STD_TICK);
    }
    
}