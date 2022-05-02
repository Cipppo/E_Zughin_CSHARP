using System;

namespace Progetto
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Players players = new Players();
            players.Add(new Player("GINO", 300, "09/03/2002"));
            players.Add(new Player("mario", 700, "09/03/2002"));
            players.Add(new Player("marco", 200, "09/03/2002"));

            players.Sort();
            PrintP(players);
        }



        static void PrintP(Players players)
        {
            for(int i = 0; i < players.Get(); i++)
            {
                Console.WriteLine(players.Get(i).ToString());
            }
        }
    }
}
