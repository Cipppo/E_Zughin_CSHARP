using System;
using NUnit.Framework;
using EZ_Csharp.hero;
using EZ_Csharp.modularGun;
using EZ_Csharp.utils;

namespace TestProject1;

[TestFixture]
public class Tests
{
    [Test]
    public void TestHeroDirections()
    {
        var hero = new Hero();
        hero.Move(Directions.LEFT);
        Assert.AreEqual(Directions.LEFT, hero.Dir);
        hero.Move(Directions.RIGHT);
        Assert.AreEqual(Directions.RIGHT, hero.Dir);
        Assert.AreNotEqual(Directions.LEFT, hero.Dir);
    }

    [Test]
    public void TestHeroHit()
    {
        var hero = new Hero();
        hero.Hit();
        Assert.AreEqual(2, hero.Lives);
    }

    [Test]
    public void TestHeroPause()
    {
        var hero = new Hero();
        hero.PauseAll();
        hero.Hit();
        Assert.AreEqual(3, hero.Lives);

    }

    [Test]
    public void TestHeroStatus()
    {
        var hero = new Hero();
        hero.Hit();
        Assert.AreEqual(HeroStatus.Hit, hero.Status);
    }
}