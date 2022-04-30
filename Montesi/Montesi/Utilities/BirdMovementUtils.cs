using System;
using System.Threading;
using Montesi.Actions;
using Montesi.Component;

namespace Montesi.Utilities
{
    public class BirdMovementUtils
    {
        private const int Speed = 1;
        private const int SizeX = 40;
        private const int SizeY = 15;
        private const int Width = 5;
        private const int Height = 3;

        private readonly BirdActor _bird;
        private readonly BirdMover _mover;
        private bool _moveUp;
        private readonly BirdActionFactory _actionFactory = new BirdActionFactory();
        private readonly BirdBoundChecker _bc =
            new BirdBoundChecker(new BirdPair<int, int>(0, SizeX), new BirdPair<int, int>(0, SizeY));

        public BirdMovementUtils(BirdActor bird, BirdMover mover)
        {
            _bird = bird;
            _mover = mover;
        }

        public void MoveRight()
        {
            _moveUp = false;
            while (_bird.S.Pos.X + Width <= _bc.X.Y - Speed)
            {
                DoMovement(BirdDirections.Right);
                MoveVertically();
                Console.WriteLine(_bird.S.Pos.ToString());
                Thread.Sleep(500);
            }
        }

        public void MoveLeft()
        {
            _moveUp = false;
            while (_bird.S.Pos.X >= _bc.X.X + Speed)
            {
                DoMovement(BirdDirections.Left);
                MoveVertically();
                Console.WriteLine(_bird.S.Pos.ToString());
                Thread.Sleep(500);
            }
        }

        private void MoveVertically()
        {
            if (_bird.S.Pos.Y + Height <= _bc.Y.Y && !_moveUp)
            {
                DoMovement(BirdDirections.Down);
            }
            else
            {
                _moveUp = true;
                DoMovement(BirdDirections.Up);
            }
        }

        private void DoMovement(BirdDirections dir)
        {
            switch (dir)
            {
                case BirdDirections.Right:
                    _actionFactory.GetRightAction(_mover);
                    break;
                case BirdDirections.Left:
                    _actionFactory.GetLeftAction(_mover);
                    break;
                case BirdDirections.Down:
                    _actionFactory.GetDownAction(_mover);
                    break;
                case BirdDirections.Up:
                    _actionFactory.GetUpAction(_mover);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }
    }
}