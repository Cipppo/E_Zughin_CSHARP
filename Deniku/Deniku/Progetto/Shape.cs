using System;

namespace Progetto
{
    public class Rectangle
    {
        private int x;
        private int y;
        private int width;
        private int height;

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public int GetX() { return x; }
        public int GetY() { return y; }
        public int GetWidth() { return width; }
        public int GetHeight() { return height; }
    }
        

    public class Shape
    {
        private Rectangle r;

        public Shape(EntityPos2D pos, int width, int height)
        {
            r = new Rectangle(pos.X, pos.Y, width, height);
        }

        public EntityPos2D GetPos() { return new EntityPos2D(r.GetX(), r.GetY()); }

        public Pair<int, int> getDimensions() { return new Pair<int, int>(r.GetWidth(), r.GetHeight()); }

        public Rectangle GetRectangle() { return r; }
    }
}
