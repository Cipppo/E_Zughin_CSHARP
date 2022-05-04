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
        const int ballsToGenerate = 1;
        var runner = new BallRunner(ballsToGenerate, new BallBoundChecker(200, 200));
        runner.Start();
        //Testing if runner built required balls and checks if those are Dimensions.Father
        Assert.IsTrue(runner.GetBalls().Count == ballsToGenerate, "Runner has wrong ball number");
        Assert.IsTrue(runner.GetBalls()[0].GetBallPosition().Dimension == Dimensions.Father);
        
        //Checks if duplication worked
        runner.Duplication(runner.GetBalls()[0]);
        Assert.IsTrue(runner.GetBalls().Count == ballsToGenerate*2);
        Assert.IsTrue(runner.GetBalls()[0].GetBallPosition().Dimension == Dimensions.Son);
        
        //duplicating all the balls
        var ball1 = runner.GetBalls()[0];
        runner.Duplication(ball1);

        //finding the child ball and checking if it's splittable (else it throws IllegalStateException)
        var b1 = runner.GetBalls().Find(t => t.GetBallPosition().Dimension == Dimensions.Grandson);
        Assert.NotNull(b1);
        Assert.Throws<IllegalStateException>(() => b1?.Duplicate());
        
        runner.TerminateAll();
    }

    [Test]
    public void TestStopAndResume()
    {
        Reset();
        var agent = new BallAgent(ball);
        agent.Start();
        Thread.Sleep(50);
        agent.Pause();
        var pos = CopyOfPosition(agent.GetBallPosition());
        Thread.Sleep(50);
        Assert.IsTrue(agent.GetBallPosition().Equals(pos), "Ball should not be moving after stop is called");
        agent.Resume();
        Thread.Sleep(30);
        Assert.IsFalse(agent.GetBallPosition().Equals(pos));
        
        agent.Terminate();
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