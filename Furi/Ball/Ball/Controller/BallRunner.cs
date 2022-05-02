using Ball.Agent;

namespace Ball.Controller;

public class BallRunner
{
    private Thread _thread;
    private readonly List<BallAgent> _balls = new List<BallAgent>();
    private readonly BallBoundChecker _checker;
    private bool _stop = false;
    private bool _terminate = false;

    public BallRunner(int ballToGenerate, BallBoundChecker checker)
    {
        _checker = checker;
        for(var i = 0; i < ballToGenerate; i++)
        {
            _balls.Add(new BallAgent());
        }
    }

    public void Start()
    {
        _balls.ForEach(t => t.Start());
        _thread = new Thread(CheckConstraints);
        _thread.Start();
    }
    
    private void CheckConstraints()
    {
        while (!_terminate)
        {
            if (!_stop)
            {
                _balls.ForEach(t => _checker.CheckConstraints(t));
            }
            Thread.Sleep(10);
        }
    }

    public void Duplication(BallAgent ball)
    {
        _stop = true;
        try
        {
            var children = ball.Duplicate();
            foreach (var newAgent in children.Select(b => new BallAgent(b)))
            {
                _balls.Add(newAgent);
                newAgent.Start();
            }
        }
        catch (IllegalStateException e)
        {
            Console.WriteLine(e.GetMessage());
        }
        ball.Terminate();
        _balls.Remove(ball);
        _stop = false;
    }

    public void PauseAll() => _balls.ForEach(t => t.Pause());

    public void ResumeAll() =>_balls.ForEach(t => t.Resume());

    public void TerminateAll()
    {
        _balls.ForEach(t => t.Terminate());
        _terminate = true;
    }

    public List<BallAgent> GetBalls() => _balls;

}