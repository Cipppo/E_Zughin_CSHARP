namespace Montesi.Utilities
{
    public sealed class EntityPos2D : Pos2D<int>
    {
        public EntityPos2D(int x, int y)
        {
            base.X = x;
            base.Y = y;
        }

        public new int X => base.X;

        public new int Y => base.Y;

        public override string ToString()
        {
            return "X = " + base.X + " Y = " + base.Y;
        }
    }
}