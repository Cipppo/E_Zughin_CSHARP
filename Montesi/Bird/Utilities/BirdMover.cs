using Montesi.Component;

namespace Montesi.Utilities
{
    /// <summary>
    /// Checks if the bird is inside the stage and than moves it.
    /// </summary>
    public class BirdMover
    {
        private readonly BirdActor _actor;
        private readonly BirdBoundChecker _bc;

        /// <summary>
        /// Constructor that initializes the bird and the bounds checker.
        /// </summary>
        /// <param name="actor">Bird.</param>
        /// <param name="bc">Bound checker.</param>
        public BirdMover(BirdActor actor, BirdBoundChecker bc)
        {
            _actor = actor;
            _bc = bc;
        }

        /// <summary>
        /// Moves the bird to the desired position.
        /// </summary>
        /// <param name="pos">Position to move the bird.</param>
        public void Move(EntityPos2D pos)
        {
            if (_bc.IsInside(pos, _actor.S.Dimension.X, _actor.S.Dimension.Y))
            {
                _actor.ChangeLocation(pos);
            }
        }
        
        /// <returns>The current position of the bird.</returns>
        public EntityPos2D GetCurrentPos() => _actor.S.Pos;
    }
}