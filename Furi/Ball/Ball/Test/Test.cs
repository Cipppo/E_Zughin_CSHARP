using Ball.Agent;

namespace Ball.Test;

public class Test
{
    static void Main()
    {
        var ball = new BallAgent();
        ball.Start();
        for (var i = 0; i < 50; i++)
        {
            Console.WriteLine(ball.GetBallPosition());
            Thread.Sleep(100);
        }
        ball.Pause();
        for (var i = 0; i < 20; i++)
        {
            Console.WriteLine(ball.GetBallPosition());
            Thread.Sleep(100);
        }
        
        ball.Resume();
        for (var i = 0; i < 20; i++)
        {
            Console.WriteLine(ball.GetBallPosition());
            Thread.Sleep(100);
        }
        ball.Terminate();
    }
}