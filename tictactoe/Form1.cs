namespace tictactoe
{
    public partial class TicTacToe : Form
    {

        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random rand = new Random();
        int playerWins = 0;
        int computerWins = 0;
        List<Button> buttons;

        public TicTacToe()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CPUmove(object sender, EventArgs e)
        {
            CPUFirst.Enabled = false;
            CPUFirst.BackColor = System.Drawing.Color.Gray;

            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTimer.Stop();

                foreach (Button btn in buttons)
                {
                    btn.Enabled = true;
                }
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            CPUFirst.Enabled = false;
            CPUFirst.BackColor = System.Drawing.Color.Gray;
            foreach (Button btn in buttons)
            {
                btn.Enabled = false;
            }

            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Cyan;
            buttons.Remove(button);
            CheckGame();
            CPUTimer.Start();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins");
                playerWins++;
                label1.Text = "Player Wins- " + playerWins;
                RestartGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                CPUTimer.Stop();
                MessageBox.Show("Computer Wins");
                computerWins++;
                label2.Text = "AI Wins- " + computerWins;
                RestartGame();
            }
        }
        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
            CPUFirst.Enabled = true;
            CPUFirst.BackColor = DefaultBackColor;
        }

        private void CPUFirst_Click(object sender, EventArgs e)
        {
            foreach (Button btn in buttons)
            {
                btn.Enabled = false;
            }

            var button = (Button)sender;
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Gray;
            buttons.Remove(button);
            CheckGame();
            CPUTimer.Start();
        }
    }
}