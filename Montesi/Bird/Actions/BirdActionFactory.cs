using Montesi.Utilities;

namespace Montesi.Actions
{
    /// <summary>
    /// A factory which models the main character Actions.
    /// </summary>
    public static class BirdActionFactory
    {
        private const int Speed = 1;

        /// <summary>
        /// The action which permits the bird to move Right.
        /// </summary>
        public class RightAction
        {
            public RightAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X + Speed, m.GetCurrentPos().Y));
        }
        
        /// <summary>
        /// The action which permits the bird to move Left.
        /// </summary>
        public class LeftAction
        {
            public LeftAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X - Speed, m.GetCurrentPos().Y));
        }
        
        /// <summary>
        /// The action which permits the bird to move Down.
        /// </summary>
        public class DownAction
        {
            public DownAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X, m.GetCurrentPos().Y + Speed));
        }
        
        /// <summary>
        /// The action which permits the bird to move Up.
        /// </summary>
        public class UpAction
        {
            public UpAction(BirdMover m) =>
                m.Move(new EntityPos2D(m.GetCurrentPos().X, m.GetCurrentPos().Y - Speed));
        }

        public static RightAction GetRightAction(BirdMover m) => new RightAction(m);
        public static LeftAction GetLeftAction(BirdMover m) => new LeftAction(m);
        public static DownAction GetDownAction(BirdMover m) => new DownAction(m);
        public static UpAction GetUpAction(BirdMover m) => new UpAction(m);

    }
}