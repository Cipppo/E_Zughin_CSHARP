using System.Xml;
using Ball.Physics;

namespace Ball.Utils;

public class SimplePos2D : Pos2D<int>
{
    public SimplePos2D(int x, int y) : base(x, y)
    {
    }

    public override int X { get; set; }
    public override int Y { get; set; }
}