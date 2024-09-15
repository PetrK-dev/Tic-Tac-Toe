using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private char[] board;
        private int currentPlayer;
        private char[] players = { 'X', 'O' };

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            
            board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            currentPlayer = 1;

            foreach (Control c in this.Controls)
            {
                if (c is Button && c.Name.StartsWith("button"))
                {
                    c.Text = "";
                    c.Enabled = true;
                }
            }

            infoLabel.Text = "Hr·Ë 1 (X) je na tahu";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.Name.Substring(6)) - 1;

            if (board[index] != 'X' && board[index] != 'O')
            {
                board[index] = players[currentPlayer - 1];
                button.Text = players[currentPlayer - 1].ToString();

                if (CheckWin())
                {
                    MessageBox.Show($"Hr·Ë {currentPlayer} vyhr·l!");
                    EndGame();
                    return;
                }

                if (IsDraw())
                {
                    MessageBox.Show("RemÌza!");
                    EndGame();
                    return;
                }

                currentPlayer = (currentPlayer == 1) ? 2 : 1;
                infoLabel.Text = $"Hr·Ë {currentPlayer} ({players[currentPlayer - 1]}) je na tahu";
            }
        }

        private bool CheckWin()
        {
            int[,] winPatterns = new int[,]
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
                { 0, 4, 8 }, { 2, 4, 6 }
            };

            for (int i = 0; i < 8; i++)
            {
                if (board[winPatterns[i, 0]] == board[winPatterns[i, 1]] && board[winPatterns[i, 1]] == board[winPatterns[i, 2]])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsDraw()
        {
            foreach (char slot in board)
            {
                if (slot != 'X' && slot != 'O')
                {
                    return false;
                }
            }
            return true;
        }

        private void EndGame()
        {
           
            DisableButtons();

            DialogResult dialogResult = MessageBox.Show("Chcete hr·t znovu?", "Nov· hra", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                InitializeGame();
            }
            else
            {
                this.Close();
            }
        }

        private void DisableButtons()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button && c.Name.StartsWith("button"))
                {
                    c.Enabled = false;
                }
            }
        }
    }
}


