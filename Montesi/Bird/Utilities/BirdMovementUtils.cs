using System;
using System.Threading;
using Montesi.Actions;
using Montesi.Component;

namespace Montesi.Utilities
{
    /// <summary>
    /// Utility that choose the bird's movements considering its position.
    ///The Parameters are:
    ///    <ul>
    ///    <li>Speed: number of pixels per movement</li>
    ///    <li>SizeX: width of the stage</li>
    ///    <li>SizeY: Height of the stage</li> 
    ///    <li>Width: width of the bird</li>
    ///    <li>Height: height of the bird</li>
    ///    </ul>
    /// </summary>
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

        /// <summary>
        /// Constructor that define the bird to move, the panel on which to move the bird
        /// and the mover utility.
        /// </summary>
        /// <param name="bird">The bird to move.</param>
        /// <param name="mover">The mover utility.</param>
        public BirdMovementUtils(BirdActor bird, BirdMover mover)
        {
            _bird = bird;
            _mover = mover;
        }

        /// <summary>
        /// Perform right movement along with vertical movement.
        /// </summary>
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

        /// <summary>
        /// Perform left movement along with vertical movement.
        /// </summary>
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

        /// <summary>
        /// Perform:
        ///     - Down movement: if bird hasn't touched the ground yet.
        ///     - Up movement: if bird has already touched ground.
        /// </summary>
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

        /// <summary>
        /// Given a direction, this method will call the appropriate movement method
        /// from the mover class.
        /// </summary>
        /// <param name="dir">The chosen direction.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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