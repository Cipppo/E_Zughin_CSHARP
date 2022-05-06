using System;

namespace Progetto
{
    public class Shape
    {
        private Rectangle r;

        public Shape(EntityPos2D pos, int width, int height)
        {
            r = new Rectangle(pos.X, pos.Y, width, height);
        }

        public EntityPos2D GetPos() { return new EntityPos2D(r.GetX(), r.GetY()); }

        public Pair<int, int> GetDimensions() { return new Pair<int, int>(r.GetWidth(), r.GetHeight()); }

        public Rectangle GetRectangle() { return r; }


        public override bool Equals(object myObject)
        {
            Shape s = myObject as Shape;
            return s == this;
        }


        public static bool operator ==(Shape s1, Shape s2)
        {
            if (s1.GetPos().X <= s2.GetPos().X && (s1.GetPos().X + s1.GetDimensions().GetX()) >= s2.GetPos().X)
            {
                return true;
            } else
            if (s1.GetPos().X <= (s2.GetPos().X + s2.GetDimensions().GetX()) && (s1.GetPos().X + s1.GetDimensions().GetX()) >= (s2.GetPos().X + s2.GetDimensions().GetX()))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Shape s1, Shape s2)
        {
            if (s1.GetPos().X < s2.GetPos().X && (s1.GetPos().X + s1.GetDimensions().GetX()) < s2.GetPos().X)
            {
                return true;
            }
            else
            if (s1.GetPos().X > (s2.GetPos().X + s2.GetDimensions().GetX()) && (s1.GetPos().X + s1.GetDimensions().GetX()) > (s2.GetPos().X + s2.GetDimensions().GetX()))
            {
                return true;
            }
            return false;
        }
    }

    
}
