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
    public partial class GameBoard : Form
    {
        Board board;
        Score score;
        public GameBoard()
        {
            InitializeComponent();
            board = new Board();
            score = new Score();
            drawBoard();
        }

        private void drawBoard()
        {
            for (int i = 0; i <= this.tableLayoutPanel1.ColumnCount - 1; i++)
            {
                for (int j = 0; j <= this.tableLayoutPanel1.RowCount - 1; j++)
                {
                    Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                    if (board.gameBoard[i, j].getValue() > 0)
                        c.Text = board.gameBoard[i, j].getValue().ToString();
                    else
                        c.Text = " ";
                }
            }
            changeCellsBackColor();
        }

        private void changeColors(Control control, int value)
        {
            switch (value)
            {
                case 0:
                    control.BackColor = ColorTranslator.FromHtml("#dbd3d3"); 
                    control.ForeColor = ColorTranslator.FromHtml("#5c4d3b");
                    break;
                case 2:
                    control.BackColor = ColorTranslator.FromHtml("#ebe2e1");
                    control.ForeColor = ColorTranslator.FromHtml("#5c4d3b");
                    break;
                case 4:
                    control.BackColor = ColorTranslator.FromHtml("#b3c2a9");
                    control.ForeColor = ColorTranslator.FromHtml("#5c4d3b");
                    break;
                case 8:
                    control.BackColor = ColorTranslator.FromHtml("#ffaf03");
                    control.ForeColor = Color.White;
                    break;
                case 16:
                    control.BackColor = ColorTranslator.FromHtml("#ff5703");
                    control.ForeColor = Color.White;
                    break;
                case 32:
                    control.BackColor = ColorTranslator.FromHtml("#db331d");
                    control.ForeColor = Color.White;
                    break;
                case 64:
                    control.BackColor = ColorTranslator.FromHtml("#ff0000");
                    control.ForeColor = Color.White;
                    break;
                case 128:
                    control.BackColor = ColorTranslator.FromHtml("#ffdd00");
                    control.ForeColor = Color.White;
                    break;
                case 256:
                    control.BackColor = ColorTranslator.FromHtml("#4dad3e");
                    control.ForeColor = Color.White;
                    break;
                case 512:
                    control.BackColor = ColorTranslator.FromHtml("#22ff00");
                    control.ForeColor = Color.White;
                    break;
                case 1024:
                    control.BackColor = ColorTranslator.FromHtml("#006aff");
                    control.ForeColor = Color.White;
                    break;
                case 2048:
                    control.BackColor = ColorTranslator.FromHtml("#0033ff");
                    control.ForeColor = Color.White;
                    break;
            }
        }

        
        private void changeCellsBackColor()
        {
            int fieldValue = 0;
            for (int i = 0; i <= this.tableLayoutPanel1.ColumnCount - 1; i++)
            {
                for (int j = 0; j <= this.tableLayoutPanel1.RowCount - 1; j++)
                {
                    fieldValue = board.gameBoard[i, j].getValue();
                    Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                    changeColors(c, fieldValue);
                }
            }
        }

        private void GameBoard_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (board.moveCellsLeft())
                {
                    if (!board.isGameOver())
                    {
                        board.addNewCell();
                        drawBoard();
                    }
                }
                else if (board.isGameOver())
                    gameOver();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (board.moveCellsRight())
                {
                    if (!board.isGameOver())
                    {
                        board.addNewCell();
                        drawBoard();
                    }
                }
                else if (board.isGameOver())
                    gameOver();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (board.moveCellsUp())
                {
                    if (!board.isGameOver())
                    {
                        board.addNewCell();
                        drawBoard();
                    }
                }
                else if (board.isGameOver())
                    gameOver();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (board.moveCellsDown())
                {
                    if (!board.isGameOver())
                    {
                        board.addNewCell();
                        drawBoard();
                    }
                }
                else if (board.isGameOver())
                    gameOver();
            }
            if (board.takeBiggestCell() == 2048)
            {
                gameOver();
            }
            score.updateScore(board.getScoreValue());
            score.printBestScore(bestScoreLabel);
            score.printScore(scoreLabel);
            if (score.isScoreTheBest())
            {
                score.updateBestScore();
                score.printBestScore(bestScoreLabel);
                score.writeBestScore();
            }

        }


        private void gameOver()
        {
            MessageBox.Show("Game over !");
            if (score.isScoreTheBest())
            {
                score.updateBestScore();
                score.printBestScore(bestScoreLabel);
                score.writeBestScore();
            }
            score.resetScore();
            score.printScore(scoreLabel);
            board.resetBoard();
            drawBoard();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Reset the game ?", "Reset", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (score.isScoreTheBest())
                {
                    score.updateBestScore();
                    score.printBestScore(bestScoreLabel);
                    score.writeBestScore();
                }
                score.resetScore();
                score.printScore(scoreLabel);
                board.resetBoard();
                drawBoard();
            }
        }

        
    }
}
