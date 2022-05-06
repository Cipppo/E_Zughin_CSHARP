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
}
