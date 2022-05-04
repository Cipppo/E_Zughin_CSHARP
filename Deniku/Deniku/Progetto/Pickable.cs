using System;
namespace Progetto
{
    public class Pickable
    {
        Shape s;

        public Pickable(Shape shape)
        {
            this.shape = shape;
        }

        public Shape shape
        {
            get { return s; }

            set { s = value; }
        }

        public bool IsPickedUp(Shape HeroShape)
        {
            if(shape == HeroShape)
            {
                return true;
            }
            return false;
        }

        public Shape GetShape() { return shape;}


    }
}
