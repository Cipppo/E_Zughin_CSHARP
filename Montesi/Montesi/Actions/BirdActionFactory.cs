using Montesi.Utilities;

namespace Montesi.Actions
{
    /// <summary>
    /// A factory which models the main character Actions.
    /// </summary>
    public class BirdActionFactory
    {
        private const int Speed = 1;

        /// <summary>
        /// The action which permits the bird to move Right.
        /// </summary>
        public class RightAction
        {
            public RightAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X + Speed, m.GetCurrentPos().Y), BirdDirections.Right);
        }
        
        /// <summary>
        /// The action which permits the bird to move Left.
        /// </summary>
        public class LeftAction
        {
            public LeftAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X - Speed, m.GetCurrentPos().Y), BirdDirections.Right);
        }
        
        /// <summary>
        /// The action which permits the bird to move Down.
        /// </summary>
        public class DownAction
        {
            public DownAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X, m.GetCurrentPos().Y + Speed), BirdDirections.Right);
        }
        
        /// <summary>
        /// The action which permits the bird to move Up.
        /// </summary>
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