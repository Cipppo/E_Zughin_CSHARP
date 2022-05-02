using Ball.Agent;
using Ball.Physics;

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
            t.ApplyConstraints((double)Boundary.X0 , Boundary.X0);
        } else if (x + diameter >= _width) {
            t.ApplyConstraints(t.GetBallPosition().X - (diameter * 0.0001), Boundary.X1);
        } else if (y + diameter > _height) {
            t.ApplyConstraints(t.GetBallPosition().Y - 0.009, Boundary.Y1);
        } else if (y < -1) {
            t.ApplyConstraints((double)Boundary.Y0, Boundary.Y0);
        }
    }
}