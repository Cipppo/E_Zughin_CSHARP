using System;
using System.Threading;
using Montesi.Component;
using Montesi.Utilities;

namespace Montesi.Controller
{
    /// <summary>
    /// The handler of the bird.
    /// This class manage the bird spawning and movement.
    /// </summary>
    public class BirdHandler : BaseThread, IPausable
    {
        private const int SizeX = 40;
        private const int SizeY = 15;
        private const int Width = 5;
        private const int StartY = 0;

        private readonly Random _random = new Random();
        private BirdMover _mover;
        public Optional<BirdActor> Actor { get; private set; }
        private int _startPosX;
        private BirdDirections _dir;
        private readonly BirdBoundChecker _bc =
            new BirdBoundChecker(new BirdPair<int, int>(0, SizeX), new BirdPair<int, int>(0, SizeY));
        private BirdMovementUtils _movUtils;
        private int _timeToSleep;
        private bool _birdDead;
        private bool _terminated;
        private bool _pause;

        /// <summary>
        /// This thread make the bird move if it isn't dead and the thread isn't terminated.
        /// </summary>
        protected override void RunThread()
        {
            while (!_terminated)
            {
                while (!_birdDead)
                {
                    while (!_pause)
                    {
                        CreateBird();
                        Thread.Sleep(20);
                        Console.WriteLine("Chosen Direction: " + _dir);
                        switch (_startPosX)
                        {
                            case 0:
                                _movUtils.MoveRight();
                                break;
                            case SizeX - Width:
                                _movUtils.MoveLeft();
                                break;
                        }
                        Actor = Optional<BirdActor>.Empty();
                        Console.WriteLine("Reached Limit of the stage (or bird was hit), waiting " + _timeToSleep + " seconds...");
                        Thread.Sleep(_timeToSleep * 1000);
                        _birdDead = false;
                    }
                }   
            }
        }

        /// <summary>
        /// This method create the bird.
        /// </summary>
        private void CreateBird()
        {
            _dir = RandomDirectionChooser();
            _startPosX = _dir == BirdDirections.Right ? 0 : SizeX - Width;
            Actor = Optional<BirdActor>.Of(new BirdActor(new EntityPos2D(_startPosX, StartY)));
            _mover = new BirdMover(Actor.Get(), _bc);
            _movUtils = new BirdMovementUtils(Actor.Get(), _mover);
            _timeToSleep = GetTimeToSleep();
        }

        /// <summary>
        /// Timeout between the spawn of a bird after the dead of the previous one.
        /// </summary>
        /// <returns>The time to wait.</returns>
        private int GetTimeToSleep() => _random.Next(10) + 5;

        /// <summary>
        /// Set the death for the actual bird.
        /// </summary>
        public void SetBirdDead()
        {
            _birdDead = true;
            _movUtils.SetDead();
        }
        
        /// <returns>A random direction for the bird.</returns>
        private BirdDirections RandomDirectionChooser() =>
            _random.Next(2) == 0 ? BirdDirections.Right : BirdDirections.Left;
        
        /// <returns>The shape if the bird exists, Optional.empty() otherwise.</returns>
        public Optional<BirdShape> GetShape() => 
            Actor.IsPresent ? Optional<BirdShape>.Of(Actor.Get().S) : Optional<BirdShape>.Empty();

        /// <summary>
        /// Terminates the thread.
        /// </summary>
        public void Terminate()
        {
            SetBirdDead();
            _terminated = true;
        }

        /// <summary>
        /// <inheritdoc cref="IPausable"/>
        /// </summary>
        public void PauseAll()
        {
            _pause = true;
            _movUtils.SetPause();
        }

        /// <summary>
        /// <inheritdoc cref="IPausable"/>
        /// </summary>
        public void ResumeAll()
        {
            _pause = false;
            _movUtils.SetPause();
        }
    }
}