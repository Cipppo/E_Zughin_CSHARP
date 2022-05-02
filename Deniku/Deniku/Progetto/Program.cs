using System;
using System.IO;

namespace Progetto
{
    class MainClass
    {
        static string CF = "BestPlayersSaves.txt";


        public static void Main(string[] args)
        {
            Players players = new Players();
            /*players.Add(new Player("GINO", 300, "09/03/2002"));
            players.Add(new Player("mario", 700, "09/03/2002"));
            players.Add(new Player("marco", 200, "09/03/2002"));*/

            Read(ref players, CF);

            players.Sort();
            Save(players, CF);
            PrintP(players);
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
                    int score = int.Parse(parts[1]);
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
