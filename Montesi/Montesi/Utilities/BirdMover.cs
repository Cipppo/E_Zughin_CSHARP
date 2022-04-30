using Montesi.Component;

namespace Montesi.Utilities
{
    public class BirdMover
    {
        private readonly BirdActor _actor;
        private readonly BirdBoundChecker _bc;

        public BirdMover(BirdActor actor, BirdBoundChecker bc)
        {
            _actor = actor;
            _bc = bc;
        }

        public void Move(EntityPos2D pos, BirdDirections dir)
        {
            if (_bc.IsInside(pos, _actor.S.Dimension.X, _actor.S.Dimension.Y))
            {
                _actor.ChangeLocation(pos);
            }
        }

        public EntityPos2D GetCurrentPos() => _actor.S.Pos;
    }
}