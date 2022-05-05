using System.Threading;
using Montesi.Actions;
using Montesi.Component;
using Montesi.Controller;
using Montesi.Utilities;
using NUnit.Framework;

namespace Tests
{
    public class BirdNUnitTests
    {
        private const int SizeX = 40;   // width of the stage;
        private const int SizeY = 15;   // height of the stage;
        private const int Width = 5;    // width of the bird;
        private const int Height = 3;   // height of the bird;
        private const int StartY = 0;   // start height of the bird.
        
        private BirdMover _mover;
        private Optional<BirdActor> Actor { get; set; }
        private int _startPosX;
        private readonly BirdBoundChecker _bc =
            new BirdBoundChecker(new BirdPair<int, int>(0, SizeX), new BirdPair<int, int>(0, SizeY));
        private readonly BirdActionFactory _actionFactory = new BirdActionFactory();
        private BirdHandler _birdHandler;

        /// <summary>
        /// Set up the bird for the tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _startPosX = 0;
            Actor = Optional<BirdActor>.Of(new BirdActor(new EntityPos2D(_startPosX, StartY)));
            _mover = new BirdMover(Actor.Get(), _bc);
        }
        
        /// <summary>
        /// Check bird's right movement.
        /// </summary>
        [Test]
        public void Moving_Bird_Right()
        {
            _actionFactory.GetRightAction(_mover);
            
            Assert.AreEqual(1, Actor.Get().S.Pos.X);
        }
        
        /// <summary>
        /// Check bird's down movement
        /// </summary>
        [Test]
        public void Moving_Bird_Down()
        {
            _actionFactory.GetDownAction(_mover);
            
            Assert.AreEqual(1, Actor.Get().S.Pos.Y);
        }

        /// <summary>
        /// Check righter bound.
        /// </summary>
        [Test]
        public void Check_Bounds_Width()
        {
            Actor.Get().ChangeLocation(new EntityPos2D(SizeX - Width + 1, 0));

            Assert.False(_bc.IsInside(Actor.Get().S.Pos, Width, Height));
        }
        
        /// <summary>
        /// Check lower bound.
        /// </summary>
        [Test]
        public void Check_Bounds_Height()
        {
            Actor.Get().ChangeLocation(new EntityPos2D(0, SizeY - Height + 1));

            Assert.False(_bc.IsInside(Actor.Get().S.Pos, Width, Height));
        }

        /// <summary>
        /// Check if optional functionality is working.
        /// </summary>
        [Test]
        public void Check_Bird_Optional_IsPresent()
        {
            Assert.True(Actor.IsPresent);
            
            Actor = Optional<BirdActor>.Empty();

            Assert.False(Actor.IsPresent);
        }

        /// <summary>
        /// Check if the bird die correctly.
        /// </summary>
        [Test]
        public void Check_Bird_Dead()
        {
            _birdHandler = new BirdHandler();
            _birdHandler.Start();
            Thread.Sleep(5000);
            _birdHandler.SetBirdDead();
            Thread.Sleep(1000);
            
            Assert.False(_birdHandler.Actor.IsPresent);
            _birdHandler.Terminate();
        }

        /// <summary>
        /// Check if another bird (after a the max wait time) spawn.
        /// </summary>
        [Test]
        public void Check_Bird_Respawn()
        {
            _birdHandler = new BirdHandler();
            _birdHandler.Start();
            Thread.Sleep(1000);
            _birdHandler.SetBirdDead();
            Thread.Sleep(15000); // max wait time.

            Assert.True(_birdHandler.Actor.IsPresent);
            _birdHandler.Terminate();
        }

        /// <summary>
        /// Check if the Pause status works as it should.
        /// </summary>
        [Test]
        public void Check_Pause_Status()
        {
            _birdHandler = new BirdHandler();
            _birdHandler.Start();
            Thread.Sleep(1000);
            _birdHandler.PauseAll();
            var firstPos = _birdHandler.Actor.Get().S.Pos;
            Thread.Sleep(1000);
            
            Assert.True(firstPos == _birdHandler.Actor.Get().S.Pos);
            
            _birdHandler.ResumeAll();
            Thread.Sleep(1000);
            
            Assert.False(firstPos == _birdHandler.Actor.Get().S.Pos);
            _birdHandler.Terminate();
        }
    }
}