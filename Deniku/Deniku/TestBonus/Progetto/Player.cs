using System;
namespace Progetto
{
    public class Player
    {
        private string nickname;
        private Score score;
        private string date;


        public Player(string nickname, Score score, string date)
        {
            this.nickname = nickname;
            this.score = score;
            this.date = date;
        }

        public string GetNickname() { return this.nickname; }

        public Score GetScore() { return this.score; }

        public string GetDate() { return this.date; }

        public void increaseScore(int score)
        {
            this.score.RaiseScore(score);
        }

        public override string ToString()
        {
            int s = score.GetScore();
            string line = string.Format("{0} {1} {2}", nickname, s, date);
            return line;
        }
    }
}
