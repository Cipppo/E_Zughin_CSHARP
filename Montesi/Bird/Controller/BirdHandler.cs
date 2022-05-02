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
    public class BirdHandler : BaseThread
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
        private bool BirdDead { get; set; }
        private bool Terminated { get; set; }

        /// <summary>
        /// This thread make the bird move.
        /// </summary>
        protected override void RunThread()
        {
            while (!Terminated)
            {
                while (!BirdDead)
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
                    BirdDead = false;
                }   
            }
            // ReSharper disable once FunctionNeverReturns
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

        public void SetBirdDead()
        {
            BirdDead = true;
            _movUtils.SetDead();
        }
        
        /// <returns>A random direction for the bird.</returns>
        private BirdDirections RandomDirectionChooser() =>
            _random.Next(2) == 0 ? BirdDirections.Right : BirdDirections.Left;
        
        /// <returns>The shape if the bird exists, Optional.empty() otherwise.</returns>
        public Optional<BirdShape> GetShape() => 
            Actor.IsPresent ? Optional<BirdShape>.Of(Actor.Get().S) : Optional<BirdShape>.Empty();

        public void Terminate()
        {
            SetBirdDead();
            Terminated = true;
        }
    }
}