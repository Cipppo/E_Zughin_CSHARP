using Montesi.Actions;
using Montesi.Component;
using Montesi.Utilities;
using NUnit.Framework;

namespace Tests
{
    public class BirdNUnitTests
    {
        private const int SizeX = 40;
        private const int SizeY = 15;
        private const int Width = 5;
        private const int Height = 3;
        private const int StartY = 0;
        
        private BirdMover _mover;
        private Optional<BirdActor> Actor { get; set; }
        private int _startPosX;
        private readonly BirdBoundChecker _bc =
            new BirdBoundChecker(new BirdPair<int, int>(0, SizeX), new BirdPair<int, int>(0, SizeY));
        private readonly BirdActionFactory _actionFactory = new BirdActionFactory();

        [SetUp]
        public void SetUp()
        {
            _startPosX = 0;
            Actor = Optional<BirdActor>.Of(new BirdActor(new EntityPos2D(_startPosX, StartY)));
            _mover = new BirdMover(Actor.Get(), _bc);
        }
        
        [Test]
        public void Moving_Bird_Right()
        {
            _actionFactory.GetRightAction(_mover);
            
            Assert.AreEqual(1, Actor.Get().S.Pos.X);
        }
        
        [Test]
        public void Moving_Bird_Down()
        {
            _actionFactory.GetDownAction(_mover);
            
            Assert.AreEqual(1, Actor.Get().S.Pos.Y);
        }

        [Test]
        public void Check_Bounds_Width()
        {
            Actor.Get().ChangeLocation(new EntityPos2D(SizeX - Width + 1, 0));

            Assert.False(_bc.IsInside(Actor.Get().S.Pos, Width, Height));
        }
        
        [Test]
        public void Check_Bounds_Height()
        {
            Actor.Get().ChangeLocation(new EntityPos2D(0, SizeY - Height + 1));

            Assert.False(_bc.IsInside(Actor.Get().S.Pos, Width, Height));
        }

        [Test]
        public void Check_Bird_Optional_IsPresent()
        {
            Actor = Optional<BirdActor>.Empty();

            Assert.False(Actor.IsPresent);
        }
    }
}