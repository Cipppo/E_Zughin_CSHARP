using System;
using EZ_Csharp.FakeVisual;
using EZ_Csharp.hero;
using EZ_Csharp.Moover;
using EZ_Csharp.utils;
using NUnit.Framework;

namespace TestProject1;

[TestFixture]
public class FakeVisualTests
{
    
    private readonly EntityPos2D startPos = new EntityPos2D(756, 432);
    private readonly Pair<int, int> dimensions = new FullPair<int, int>(1512, 864);
    
    [Test]
    public void SpawnTest()
    {
        var env = new Enviroment(this.startPos, this.dimensions );
        Assert.IsTrue(startPos.Equals(env.Visual.ArpionComponent.S.Pos));
        Assert.IsTrue(startPos.Equals(env.Visual.HeroComponent.S.Pos));
    }

    [Test]
    public void StepLeft()
    {
        var env = new Enviroment(this.startPos, this.dimensions);
        Assert.AreEqual(new EntityPos2D(0, 0), env.Hero.Pos);
        env.Moover.MoveLeft();
        Assert.AreEqual(Directions.LEFT, env.Hero.Dir);
        Assert.AreEqual(new EntityPos2D(-1, 0), env.Hero.Pos);
    }

    [Test]
    public void StepRight()
    {
        var env = new Enviroment(this.startPos, this.dimensions);
        env.Moover.MoveRight();
        Assert.AreEqual(Directions.RIGHT, env.Hero.Dir);
        Assert.AreEqual(new EntityPos2D(1, 0), env.Hero.Pos);
    }
    
    [Test]
    public void TestArpionStepLeft()
    {
        var env = new Enviroment(this.startPos, this.dimensions);
        env.Moover.MoveLeft();
        Assert.AreEqual(Directions.LEFT, env.Visual.ArpionComponent.Dir);
        Assert.AreEqual(env.Visual.HeroComponent.S.Pos.X, env.Visual.ArpionComponent.S.Pos.X);
    }

    [Test]
    public void TestArpionStepRight()
    {
        var env = new Enviroment(this.startPos, this.dimensions);
        env.Moover.MoveRight();
        Assert.AreEqual(Directions.RIGHT, env.Visual.ArpionComponent.Dir);
        Assert.AreEqual((env.Visual.HeroComponent.S.Pos.X + env.Visual.HeroComponent.S.Dimensions.X) - env.Visual.ArpionComponent.S.Dimensions.X, env.Visual.ArpionComponent.S.Pos.X);
    }

    [Test]
    public void testPause()
    {
        var env = new Enviroment(this.startPos, this.dimensions);
        env.Hero.PauseAll();
        env.Moover.MoveLeft();
        Assert.AreEqual(new EntityPos2D(0, 0), env.Hero.Pos);
        Assert.AreEqual(new EntityPos2D(756, 432), env.Visual.ArpionComponent.S.Pos);
        env.Hero.ResumeAll();
        env.Moover.MoveLeft();
        Assert.AreEqual(new EntityPos2D(-1, 0), env.Hero.Pos);
    }

    private class Enviroment
    {
        private EntityPos2D StartPos { get; }
        public FakeVisual Visual { get; }
        public Hero Hero { get; } = new Hero();
        public Moover Moover { get; }

        public Enviroment(EntityPos2D startPos, Pair<int, int> dimesions)
        {
            this.StartPos = startPos;
            this.Visual = new FakeVisual(dimesions.X, dimesions.Y, startPos);
            this.Moover = new Moover(this.Visual, this.Hero);
        }

    }
    
}