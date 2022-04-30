using System;
using System.Threading;
using Montesi.Component;
using Montesi.Utilities;

namespace Montesi.Controller
{
    public class BirdHandler : BaseThread
    {
        private const int SizeX = 40;
        private const int SizeY = 50;
        private const int Width = 5;
        private const int StartY = 0;

        private readonly Random _random = new Random();
        private BirdMover _mover;
        public Optional<BirdActor> Actor { get; set; }
        private int _startPosX;
        private BirdDirections _dir;
        private readonly BirdBoundChecker _bc =
            new BirdBoundChecker(new BirdPair<int, int>(0, SizeX), new BirdPair<int, int>(0, SizeY));
        private BirdMovementUtils _movUtils;

        protected override void RunThread()
        {
            while (true)
            {
                CreateBird();
                Thread.Sleep(20);
                Console.WriteLine("Chosen Direction: " + _dir.ToString());
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
                Thread.Sleep(GetTimeToSleep() * 1000);
            }
        }

        private void CreateBird()
        {
            _dir = RandomDirectionChooser();
            _startPosX = _dir == BirdDirections.RIGHT ? 0 : SizeX - Width;
            Actor = Optional<BirdActor>.Of(new BirdActor(new EntityPos2D(_startPosX, StartY), _dir));
            _mover = new BirdMover(Actor.Get(), _bc);
            _movUtils = new BirdMovementUtils(Actor.Get(), _mover);
        }

        private int GetTimeToSleep() => _random.Next(10) + 5;

        private BirdDirections RandomDirectionChooser() =>
            _random.Next(2) == 0 ? BirdDirections.RIGHT : BirdDirections.LEFT;

        public Optional<BirdShape> GetShape() => 
            Actor.IsPresent ? Optional<BirdShape>.Of(Actor.Get().S) : Optional<BirdShape>.Empty();
    }
}