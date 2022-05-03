using Ball.Agent;
using Ball.Controller;
using Ball.Physics;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
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
        Assert.IsFalse(ball.ActualPosition.Equals(pos), "Ball should be moved away from starting point");
        Reset();
    }

    [Test]
    public void TestThreadRunning()
    {
        var agent = new BallAgent(ball);
        var pos = CopyOfPosition(agent.GetBallPosition());
        agent.Start();
        Thread.Sleep(30);
        Assert.IsFalse(ball.ActualPosition.Equals(pos), "Thread didn't updated position");
        agent.Terminate();
    }

    [Test]
    public void TestWallCollision()
    {
        var checker = new BallBoundChecker(200, 200);
        ball.ActualPosition.Y = 1; //Ball touching ground
        var agent = new BallAgent(ball);
        if (ball.Velocity.Vy > 0)
        {
            var pos = CopyOfPosition(ball.ActualPosition);
            agent.Start();
            Thread.Sleep(10);
            checker.CheckConstraints(agent);
            Assert.IsTrue(ball.ActualPosition.Y < pos.Y, "Ball should have been moving up");
            agent.Terminate(); 
        }
        else
        {
            var pos = CopyOfPosition(ball.ActualPosition);
            agent.Start();
            Thread.Sleep(10);
            checker.CheckConstraints(agent);
            Assert.IsTrue(ball.ActualPosition.Y > pos.Y, "Ball should have been moving up");
            agent.Terminate();
        }
        Reset();
    }

    [Test]
    public void TestDuplication()
    {
        var runner = new BallRunner(1, new BallBoundChecker(200, 200));
        runner.Start();
        Assert.IsTrue(runner.GetBalls().Count.Equals(1), "Runner has wrong ball number");
        Assert.IsTrue(runner.GetBalls()[0].GetBallPosition().Dimension.Equals(Dimensions.Father));

        


        runner.TerminateAll();
    }

    [Test]
    public void TestDuplicationGranchild()
    {
        var runner = new BallRunner(1, new BallBoundChecker(200, 200));
        runner.Start();
        runner.Duplication(runner.GetBalls().ToArray()[0]);
        runner.Duplication(runner.GetBalls().ToArray()[0]);
        runner.GetBalls().ForEach(t => Console.WriteLine(t.GetBallPosition()));
        Assert.True(runner.GetBalls().Count.Equals(3));
        //Assert.Throws<IllegalStateException>(() => child.Duplicate());
        runner.TerminateAll();
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