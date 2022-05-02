using Ball.Agent;
using Ball.Physics;
using NUnit.Framework;

namespace Ball.Test;

[TestFixture]
public class BallTests
{
    private Agent.Ball ball = BallFactory.RandomPos();
    
    [Test]
    public void BasicMovementTest()
    {
        var pos = CopyOfPosition(ball.ActualPosition);
        ball.UpdatePos();
        Assert.IsFalse(CompareSamePos(pos, ball.ActualPosition), "Ball should be moved away from starting point");
        Reset();
    }

    [Test]
    public void TestThreadRunning()
    {
        var agent = new BallAgent(ball);
        var pos = CopyOfPosition(agent.GetBallPosition());
        agent.Start();
        Thread.Sleep(30);
        Assert.IsFalse(CompareSamePos(pos, ball.ActualPosition), "Thread didn't updated position");
        agent.Terminate();
    }


    
    
    private bool CompareSamePos(SpherePos2D a, SpherePos2D b)
    {
        return a.X == b.X && a.Y == b.Y;
    } 
    
    private SpherePos2D CopyOfPosition(SpherePos2D pos)
    {
        return new SpherePos2D(
            pos.X,
            pos.Y,
            pos.Dimension,
            pos.Diameter);
    }

    private void Reset()
    {
        ball = BallFactory.RandomPos();
    }
}