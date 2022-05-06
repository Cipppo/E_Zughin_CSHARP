using System;
using NUnit.Framework;

namespace Progetto
{
    [TestFixture]
    public class TestBonus
    {
        [Test]
        public void BonusCreate()
        {
            Pair<int, int> bounds = new Pair<int, int>(1000, 1000);
            BonusGenerator generator = new BonusGenerator(bounds);
            BonusEntity bonus = generator.GenerateNextBonus();

            Assert.IsNotNull(bonus);

        }

        [Test]
        public void BonusAboveTheBottomLine()
        {
            Pair<int, int> bounds = new Pair<int, int>(1000, 1000);
            BonusGenerator generator = new BonusGenerator(bounds);
            BonusEntity bonus = generator.GenerateNextBonus();
            
            Assert.AreEqual(bonus.GetShape().GetPos().Y, (bounds.GetX() - bonus.GetShape().GetDimensions().GetY()));
        }

        [Test]
        public void BonusInBounds()
        {
            Pair<int, int> bounds = new Pair<int, int>(1000, 1000);
            BonusGenerator generator = new BonusGenerator(bounds);
            BonusEntity bonus = generator.GenerateNextBonus();
            Assert.GreaterOrEqual(bonus.GetShape().GetPos().Y, 0);
            Assert.LessOrEqual(bonus.GetShape().GetPos().Y, (bounds.GetX() - bonus.GetShape().GetDimensions().GetY()));
            Assert.GreaterOrEqual(bonus.GetShape().GetPos().X, 0);
            Assert.LessOrEqual(bonus.GetShape().GetPos().X, (bounds.GetX() - bonus.GetShape().GetDimensions().GetX()));
        }

        [Test]
        public void RandomSpawnInX()
        {
            Pair<int, int> bounds = new Pair<int, int>(1000, 1000);
            BonusGenerator generator = new BonusGenerator(bounds);
            int nTest = 10;
            
            BonusEntity[] bonusContainer = new BonusEntity[nTest];
            int collision = 0;

            for (int i = 0; i < nTest; i++)
            {
                bonusContainer[i] = generator.GenerateNextBonus();
                if (i > 0 && bonusContainer[i].GetShape().GetPos().X == bonusContainer[i - 1].GetShape().GetPos().X)
                {
                    collision++;
                }
            }
            Assert.Less(collision, nTest-1);
        }

        [Test]
        public void RandomBonusPoints()
        {
            Pair<int, int> bounds = new Pair<int, int>(1000, 1000);
            BonusGenerator generator = new BonusGenerator(bounds);
            int nTest = 10;
            
            BonusEntity[] bonusContainer = new BonusEntity[nTest];
            int collision = 0;

            for (int i = 0; i < nTest; i++)
            {
                bonusContainer[i] = generator.GenerateNextBonus();
                if (i > 0 && bonusContainer[i].GetPoints() == bonusContainer[i - 1].GetPoints())
                {
                    collision++;
                }
            }
            Assert.Less(collision, nTest-1);
        }

        [Test]
        public void IsPickedUp()
        {
            Pair<int, int> bounds = new Pair<int, int>(1000, 1000);
            BonusGenerator generator = new BonusGenerator(bounds);
            BonusEntity bonus = generator.GenerateNextBonus();
            int range = bonus.GetShape().GetDimensions().GetX();
            int picked = 0;
            
            for (int i = 0; i <= bounds.GetX(); i += range)
            {
                EntityPos2D pos = new EntityPos2D(i, bounds.GetY()- bonus.GetShape().GetDimensions().GetY());
                Shape testShape = new Shape(pos, bonus.GetShape().GetDimensions().GetX(), bonus.GetShape().GetDimensions().GetY());

                if (bonus.IsPickedUp(testShape))
                    picked++;
            }
            
            Assert.NotZero(picked);
        }
        

        
    }
}
