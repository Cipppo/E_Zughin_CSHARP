using EZ_Csharp.modularGun;
using NUnit.Framework;

namespace TestProject1;

[TestFixture]
public class ArpionTest
{
    [Test]
    public void TestRise()
    {
        var arpion = new Arpion();
        arpion.Lock();
        arpion.Raise();
        Assert.AreEqual(Status.Rising, arpion.Status);
        Assert.NotZero(arpion.Steps);
    }

    [Test]
    public void TestReset()
    {
        var arpion = new Arpion();
        arpion.Lock();
        arpion.Raise();
        Assert.NotZero(arpion.Steps);
        arpion.Restore();
        Assert.Zero(arpion.Steps);
    }
}