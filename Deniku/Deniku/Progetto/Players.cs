using System;
namespace Progetto
{
    public class Players
    {
        private const int CMax = 10;
        private Player[] players;
        private int n;

        public Players()
        {
            this.players = new Player[CMax];
            this.n = 0;
        }

        public int Get() { return n; }

        public Player Get(int i) { return players[i]; }


        public void Add(Player p)
        {
            if(n == CMax)
            {
                if (!RemoveLastPlayerByScore(p.GetScore())){
                    return;
                }
            }
            players[n++] = p;
        }


        public bool RemoveLastPlayerByScore(int score)
        {
            if (players[n-1].GetScore() < score)
            {
                players[n - 1] = null;
                n--;
                return true;
            }

            return false;
        }

        public void Sort()
        {
            for(int i = 1; i < n; i++)
            {
                Player key = players[i];
                int j = i - 1;
                while (j >= 0 && players[j].GetScore() < key.GetScore())
                {
                    players[j + 1] = players[j];
                    j--;
                }
                players[j + 1] = key;
            }
        }

    }
}
