using System.Runtime.Intrinsics.Arm;
using Ball.Physics;

namespace Ball.Utils;

public class SquaredShape
{
    public Pair<int> Dimension { get; }
    public Pos2D<int> Position { get; }

    public SquaredShape(int width, int height, Pos2D<int> position)
    {
        Dimension = new Pair<int>(width, height);
        Position = position;
    }
}