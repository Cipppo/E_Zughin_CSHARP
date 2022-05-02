using System;
namespace Progetto
{
    public class Player
    {
        private string nickname;
        private int score;
        private string date;


        public Player(string nickname, int score, string date)
        {
            this.nickname = nickname;
            this.score = score;
            this.date = date;
        }

        public string GetNickname() { return this.nickname; }

        public int GetScore() { return this.score; }

        public string GetDate() { return this.date; }

        public void increaseScore(int score)
        {
            this.score += score;
        }

        public override string ToString()
        {
            string line = string.Format("{0} {1} {2}", nickname, score, date);
            return line;
        }
    }
}
