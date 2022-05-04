using Ball.Physics;
using Ball.Utils;

namespace Ball.Controller;

public class IntersectionChecker
{
    public static bool isBallCollision(SpherePos2D ball, SquaredShape rect) {
        var rectWidth = rect.Dimension.X;
        var rectHeight = rect.Dimension.Y;
        var rectCenter = new Pair<int>(rect.Position.X + (int)(0.5*rectWidth),
            rect.Position.Y + (int)(0.5*rectHeight));
        var ballCenter = new Pair<int>((int)(ball.X + ball.Diameter / 2), (int)(ball.Y + (ball.Diameter / 2) ));
        var circleDistance = new Pair<int>(0,0);
        
        circleDistance.X = Math.Abs(ballCenter.X - rectCenter.X);
        circleDistance.Y = Math.Abs(ballCenter.Y - rectCenter.Y);

        // Base cases, the two figures don't intersect
        if (circleDistance.X > rectWidth / 2 + ball.Diameter / 2) {
            return false;
        }

        if (circleDistance.Y > (rectHeight / 2 + ball.Diameter / 2)) {
            return false;
        }

        //Simple intersection (circle intersect rectangle)
        if (circleDistance.X <= (rectWidth / 2) || circleDistance.Y <= (rectHeight / 2)) {
            return true;
        }
        //Check distance of circle from corners of the rectangle.
        var cornerDistance_sq =
            Math.Sqrt(Math.Pow(circleDistance.X - rectWidth / 2, 2) + Math.Pow(circleDistance.Y - rectWidth / 2, 2));
        return (cornerDistance_sq <= (Math.Pow(ball.Diameter / 2, 2)));
    }
}