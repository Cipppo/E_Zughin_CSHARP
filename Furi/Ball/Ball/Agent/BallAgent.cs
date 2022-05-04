using Ball.Physics;

namespace Ball.Agent;

public class BallAgent
{
    private Thread _thread;
    private readonly Ball _ball;
    private bool _stop = false;
    private bool _pause = false;

    public BallAgent() => _ball = BallFactory.RandomPos();
    public BallAgent(Ball ball) => _ball = ball;

    public void Start()
    {
        _thread = new Thread(UpdatePosition);
        _thread.Start();
    }

    private void UpdatePosition()
    {
        while (!_stop)
        {
            if (!_pause)
                _ball.UpdatePos();
            Thread.Sleep(10);
        }
    }
    
    public List<Ball> Duplicate()
    {
        if (_ball.ActualPosition.Dimension == Dimensions.Grandson) throw new IllegalStateException();
        var ball1 = GenerateBall();
        var ball2 = GenerateBall();

        ball1.Velocity.Vx *= -1;

        var list = new List<Ball>
        {
            ball1,
            ball2
        };
        return list;
    }

    private Ball GenerateBall()
    {
        return BallFactory.FromFatherBall(_ball);
    }

    public SpherePos2D GetBallPosition() => _ball.ActualPosition;

    public void ApplyConstraints(double position, int bound) => _ball.ApplyConstraints(position, bound);

    public void Terminate() => _stop = true;

    public void Pause() => _pause = true;

    public void Resume() => _pause = false;

    public int GetSize() => _ball.ActualPosition.Diameter;
}