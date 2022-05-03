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
    
    [Test]
    public void SpawnTest()
    {
        var startPos = new EntityPos2D(756, 432);
        var visual = new FakeVisual(1512, 864, startPos);
        Assert.IsTrue(startPos.Equals(visual.ArpionComponent.S.Pos));
        Assert.IsTrue(startPos.Equals(visual.HeroComponent.S.Pos));
    }

    [Test]
    public void StepLeft()
    {
        var startPos = new EntityPos2D(756, 432);
        var visual = new FakeVisual(1512, 864, startPos);
        var hero = new Hero();
        Assert.AreEqual(new EntityPos2D(0, 0), hero.Pos);
        var moover = new Moover(visual, hero);
        moover.MoveLeft();
        Assert.AreEqual(Directions.LEFT, hero.Dir);
        Assert.AreEqual(new EntityPos2D(-1, 0), hero.Pos);
    }

    [Test]
    public void StepRight()
    {
        var startPos = new EntityPos2D(756, 432);
        var visual = new FakeVisual(1512, 864, startPos);
        var hero = new Hero();
        var moover = new Moover(visual, hero);
        moover.MoveRight();
        Assert.AreEqual(Directions.RIGHT, hero.Dir);
        Assert.AreEqual(new EntityPos2D(1, 0), hero.Pos);
    }

    [Test]
    public void TestArpionStep()
    {
        var startPos = new EntityPos2D(756, 432);
        var visual = new FakeVisual(1512, 864, startPos);
        var hero = new Hero();
        var moover = new Moover(visual, hero);
        moover.MoveRight();
        Assert.AreEqual(Directions.RIGHT, visual.ArpionComponent.Dir);
    }

    [Test]
    public void testPause()
    {
        var startPos = new EntityPos2D(756, 432);
        var visual = new FakeVisual(1512, 864, startPos);
        var hero = new Hero();
        var moover = new Moover(visual, hero);
        hero.PauseAll();
        moover.MoveLeft();
        Assert.AreEqual(new EntityPos2D(0, 0), hero.Pos);
        Assert.AreEqual(new EntityPos2D(756, 432), visual.ArpionComponent.S.Pos);
        hero.ResumeAll();
        moover.MoveLeft();
        Assert.AreEqual(new EntityPos2D(-1, 0), hero.Pos);
    }
}