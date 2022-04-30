using Montesi.Utilities;

namespace Montesi.Actions
{
    public class BirdActionFactory
    {
        private const int Speed = 1;

        public class RightAction
        {
            public RightAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X + Speed, m.GetCurrentPos().Y), BirdDirections.Right);
        }
        
        public class LeftAction
        {
            public LeftAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X - Speed, m.GetCurrentPos().Y), BirdDirections.Right);
        }
        
        public class DownAction
        {
            public DownAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X, m.GetCurrentPos().Y + Speed), BirdDirections.Right);
        }
        
        public class UpAction
        {
            public UpAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X, m.GetCurrentPos().Y - Speed), BirdDirections.Right);
        }

        public RightAction GetRightAction(BirdMover m) => new RightAction(m);
        public LeftAction GetLeftAction(BirdMover m) => new LeftAction(m);
        public DownAction GetDownAction(BirdMover m) => new DownAction(m);
        public UpAction GetUpAction(BirdMover m) => new UpAction(m);

    }
}