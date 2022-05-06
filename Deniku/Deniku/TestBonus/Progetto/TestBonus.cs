using System;
using NUnit.Framework;

namespace Progetto
{
    [TestFixture]
    public class TestBonus
    {
        [Test]
        public void TestBonusCreate()
        {
            Pair<int, int> bounds = new Pair<int, int>(200, 1000);
            BonusGenerator generator = new BonusGenerator(bounds);
            BonusEntity bonus = generator.GenerateNextBonus();

            Console.WriteLine("gino");

            Assert.IsNotNull(bonus);

        }


    }
}
