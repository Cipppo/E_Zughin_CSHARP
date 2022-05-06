using System;
namespace Progetto
{
    public class Score
    {
        private int score;

        public Score()
        {
            this.score = 0;
        }

        public void ResetScore() { this.score = 0; }

        public int GetScore() { return this.score; }

        public void RaiseScore(int points) { this.score += points; }

        public override string ToString()
        {
            return string.Format("Actual Score: {0}", score);
        }
    }
}
