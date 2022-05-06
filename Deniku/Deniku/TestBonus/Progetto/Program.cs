using System;
using System.IO;

namespace Progetto
{
    class MainClass
    {
        static string CF = "BestPlayersSaves.txt";


        public static void Main(string[] args)
        {
            Pair<int, int> bounds = new Pair<int, int>(200, 1000); 
            BonusGenerator generator = new BonusGenerator(bounds);
            
            BonusEntity bonus = generator.GenerateNextBonus();

            

            //TestResult(TestBonusCreation(bonus));

            //TestResult(TestBonusAboveTheBottomLine(bonus, bounds));

            //TestResult(TestBonusInBounds(bonus, bounds));

            //TestResult(TestBonusScore(generator, 10, true));

            //int range = bonus.GetShape().GetDimensions().GetX();

            //TestIsPickedUp(bonus, bounds, range);
        }


        static bool TestBonusCreation(BonusEntity bonus)
        {
            Console.WriteLine("Test Creation of Bonus: ");
            if (bonus != null)
            {
                return true;
            }
            return false;
        }

        static bool TestBonusAboveTheBottomLine(BonusEntity bonus, Pair<int, int> bounds)
        {
            Console.WriteLine("Test Bonus spawn above the south bounds:");
            if(bonus.GetShape().GetPos().Y == (bounds.GetX() - bonus.GetShape().GetDimensions().GetY()))
            {
                return true;
            }

            return false;
        }

        static bool TestBonusInBounds(BonusEntity bonus, Pair<int, int> bounds)
        {
            
            Console.WriteLine("Test Bonus inside Bounds: ");

            Console.Write("     Test1 Bonus.Pos.Y in [0:Bounds.Y] range: ");
            if (bonus.GetShape().GetPos().Y >= 0 &&
                bonus.GetShape().GetPos().Y <= (bounds.GetX() - bonus.GetShape().GetDimensions().GetY()))
            {
                Console.WriteLine("Succeed");
            }
            else
            {
                Console.WriteLine("Failed");
                return false;
            }

            Console.Write("     Test2 Bonus.Pos.X in [0:Bounds.X] range: ");
            if (bonus.GetShape().GetPos().X >= 0 &&
                bonus.GetShape().GetPos().X <= (bounds.GetX() - bonus.GetShape().GetDimensions().GetX()))
            {
                Console.WriteLine("Succeed");
            }
            else
            {
                Console.WriteLine("Failed");
                return false;
            }

            Console.WriteLine("     Bonus Pos: ({0};{1})   Bounds Range: ({2};{3})",
                bonus.GetShape().GetPos().X, bonus.GetShape().GetPos().Y, bounds.GetX(), bounds.GetY());


            return true;
        }

        static bool TestBonusSpawnInX(BonusGenerator generator, int nTest, bool display)
        {
            Console.WriteLine("Test Random Spawn In X:");

            BonusEntity[] bonusContainer = new BonusEntity[nTest];
            int collision = 0;

            for (int i = 0; i < nTest; i++)
            {
                bonusContainer[i] = generator.GenerateNextBonus();
                if (i > 0 && bonusContainer[i].GetShape().GetPos().X == bonusContainer[i - 1].GetShape().GetPos().X)
                {
                    collision++;
                }

                if (display)
                {
                    Console.WriteLine("     Bonus NO.{0} PosX = {1}", i, bonusContainer[i].GetShape().GetPos().X);
                }
            }

            if (collision < (nTest - 1))
            {
                Console.WriteLine("\n   Number of Collission between subsequent number: {0}", collision);
                return true;
            }
            return false;
        }

        static bool TestBonusScore(BonusGenerator generator, int nTest, bool display)
        {
            Console.WriteLine("Test Random Spawn In X:");

            BonusEntity[] bonusContainer = new BonusEntity[nTest];
            int collision = 0;

            for (int i = 0; i < nTest; i++)
            {
                bonusContainer[i] = generator.GenerateNextBonus();
                if (i > 0 && bonusContainer[i].GetPoints() == bonusContainer[i - 1].GetPoints())
                {
                    collision++;
                }

                if (display)
                {
                    Console.WriteLine("     Bonus NO.{0} Points = {1}", i, bonusContainer[i].GetPoints());
                }
            }

            if (collision < (nTest - 1))
            {
                Console.WriteLine("\n   Number of Collission between subsequent number: {0}", collision);
                return true;
            }
            return false;
        }

        static bool TestIsPickedUp(BonusEntity bonus, Pair<int, int> bounds, int range)
        {

            Console.WriteLine("Bonus Pos: ({0};{1})\n\n", bonus.GetShape().GetPos().X, bonus.GetShape().GetPos().Y);
            for (int i = 0; i <= bounds.GetX(); i += range)
            {
                EntityPos2D pos = new EntityPos2D(i, bounds.GetY()- bonus.GetShape().GetDimensions().GetY());
                Shape testShape = new Shape(pos, bonus.GetShape().GetDimensions().GetX(), bonus.GetShape().GetDimensions().GetY());

                Console.Write("Test NO.{0}: ", (i / range));
                if (bonus.IsPickedUp(testShape))
                    Console.Write("Succeed   ");
                else
                    Console.Write("Failed   ");
                Console.WriteLine("Test Pos: ({0};{1})\n", testShape.GetPos().X, testShape.GetPos().Y);
            }

            return false;
        }

        static void TestResult(bool r)
        {
            if (r)
            {
                Console.WriteLine("Test Succeed\n");
            }
            else
            {
                Console.WriteLine("Test Failed\n");
            }
        }

        static void PrintP(Players players)
        {
            for(int i = 0; i < players.Get(); i++)
            {
                Console.WriteLine(players.Get(i).ToString());
            }
        }


        static void Read(ref Players players, string filename)
        {
            string line;
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string name = parts[0].Trim();
                    Score score = new Score();
                    score.RaiseScore(int.Parse(parts[1]));
                    string date = parts[2].Trim();
                    players.Add(new Player(name, score, date));
                }
            }
        }

        static void Save(Players players, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                for(int i = 0; i < players.Get(); i++)
                {
                    writer.WriteLine("{0}; {1}; {2};", players.Get(i).GetNickname(), players.Get(i).GetScore(), players.Get(i).GetDate());
                }
            }
        }
    }
}
