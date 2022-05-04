using Ball.Agent;
using Ball.Controller;
using Ball.Physics;
using Ball.Utils;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;

namespace Ball.Test;

[TestFixture]
public class BallTests
{
    private Agent.Ball _ball = BallFactory.RandomPos();
    
    [Test]
    public void BasicMovementTest()
    {
        var pos = CopyOfPosition(_ball.ActualPosition);
        _ball.UpdatePos();
        Assert.IsFalse(_ball.ActualPosition.Equals(pos), "Ball should be moved away from starting point");
        Reset();
    }

    [Test]
    public void TestThreadRunning()
    {
        var agent = new BallAgent(_ball);
        var pos = CopyOfPosition(agent.GetBallPosition());
        agent.Start();
        Thread.Sleep(30);
        Assert.IsFalse(_ball.ActualPosition.Equals(pos), "Thread didn't updated position");
        agent.Terminate();
    }

    [Test]
    public void TestWallCollision()
    {
        var checker = new BallBoundChecker(200, 200);
        _ball.ActualPosition.Y = 1; //Ball touching ground
        var agent = new BallAgent(_ball);
        if (_ball.Velocity.Vy > 0)
        {
            var pos = CopyOfPosition(_ball.ActualPosition);
            agent.Start();
            Thread.Sleep(10);
            checker.CheckConstraints(agent);
            Assert.IsTrue(_ball.ActualPosition.Y < pos.Y, "Ball should have been moving up");
            agent.Terminate(); 
        }
        else
        {
            var pos = CopyOfPosition(_ball.ActualPosition);
            agent.Start();
            Thread.Sleep(10);
            checker.CheckConstraints(agent);
            Assert.IsTrue(_ball.ActualPosition.Y > pos.Y, "Ball should have been moving up");
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
        var agent = new BallAgent(_ball);
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

    [Test]
    public void CollisionWithShape()
    {
        Reset();
        var pos = CopyOfPosition(_ball.ActualPosition);
        //placing a rectangle in the same position of the ball
        var rect = new SquaredShape(50,50, new SimplePos2D((int)pos.X, (int)pos.Y));
        
        Assert.IsTrue(IntersectionChecker.IsBallCollision(_ball.ActualPosition, rect));
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
        _ball = BallFactory.RandomPos();
    }
}