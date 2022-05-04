using Ball.Agent;
using Ball.Physics;
using Ball.Utils;

namespace Ball.Controller;

public class BallBoundChecker
{
    private readonly double _width;
    private readonly double _height;

    public BallBoundChecker(double width, double height)
    {
        _width = width;
        _height = height;
    }

    public void CheckConstraints(BallAgent t)
    {
        var x =  (t.GetBallPosition().X * _width);
        var y =  (t.GetBallPosition().Y * _height);
        var diameter = t.GetBallPosition().Diameter;
        if (x < 0) {
            t.ApplyConstraints(0.1, 1);
        } else if (x + diameter >= _width) {
            t.ApplyConstraints(t.GetBallPosition().Y - 0.009 , 1);
        } else if (y + diameter >= _height) {
            t.ApplyConstraints(t.GetBallPosition().Y - 0.009, 0);
        } else if (y < -1) {
            t.ApplyConstraints(0, 0);
        }
    }

    public bool CheckEnemyCollision(SquaredShape entity, BallAgent ball)
    {
        var bPos = new SpherePos2D(ball.GetBallPosition().X * _width,
            ball.GetBallPosition().Y * _height,
            ball.GetBallPosition().Dimension,
            ball.GetBallPosition().Diameter);
        return IntersectionChecker.IsBallCollision(bPos, entity);
    }

    public Pair<double> GetDimensions() => new Pair<double>(_width, _height);
}