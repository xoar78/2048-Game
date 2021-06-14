using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_Game
{
    public partial class MainMenu : Form
    {
        Score score;
        public MainMenu()
        {
            InitializeComponent();
            score = new Score();
            score.printBestScore(label6);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameBoard board = new GameBoard();
            board.Show();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use WASD keys or arrows to move blocks on board in right direction. Have a good time !");
        }


        private void label7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Reset the best score ?", "Best score", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                score.resetBestScore();
                score.printBestScore(label6);
                score.writeBestScore();
            }
        }
    }
}
