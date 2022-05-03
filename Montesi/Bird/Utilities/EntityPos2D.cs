namespace Montesi.Utilities
{
    public class EntityPos2D : Pos2D<int>
    {
        public EntityPos2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override int X
        {
            get => x;
            set => x = value;
        }

        public override int Y
        {
            get => y; 
            set => y = value;
        }

        public override string ToString()
        {
            return "X = " + x + " Y = " + y;
        }
    }
}