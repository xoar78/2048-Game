using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2048_Game
{
    class Score
    {
        int score;
        int bestScore;

        public Score()
        {
            takeBestScore();
            resetScore();
        }

        public int getScore()
        {
            return score;
        }

        public int getBestScore()
        {
            return bestScore;
        }

        public bool isScoreTheBest()
        {
            if (score > bestScore)
            {
                return true;
            }
            return false;
        }

        public void writeBestScore()
        {
            using (StreamWriter streamWriter = new StreamWriter("../../BestScore.txt"))
            {
                streamWriter.Write(bestScore.ToString());
                streamWriter.Flush();
            }
        }

        private void takeBestScore()
        {
            using (StreamReader read = new StreamReader("../../BestScore.txt"))
            {
                string textRow = "";
                if (new FileInfo("../../BestScore.txt").Length > 0)
                {
                    textRow = read.ReadLine();
                    bestScore = int.Parse(textRow);
                }
                else
                {
                    bestScore = 0;
                }
            }
        }

        public void resetScore()
        {
            score = 0;
        }

        public void resetBestScore()
        {
            bestScore = 0;
        }

        public void updateScore(int value)
        {
            score = value;
        }

        public void updateBestScore()
        {
            bestScore = score;
        }

        public void printScore(Label label)
        {
            label.Text = score.ToString();
        }

        public void printBestScore(Label label)
        {
            label.Text = bestScore.ToString();
        }

    }
}
