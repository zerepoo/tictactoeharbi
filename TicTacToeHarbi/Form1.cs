using System;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToeHarbi
{
    public abstract class BaseForm : Form
    {
        protected char[,] board = new char[3, 3];
        protected Button[,] buttons;
        protected bool xTurn = true;

        protected abstract void InitializeBoard();
        protected abstract void CheckWinner();
        protected abstract void ShowWinner(char winner);

        protected void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = Array.IndexOf(buttons.Cast<Button>().ToArray(), btn);
            int row = buttonIndex / 3;
            int col = buttonIndex % 3;

            if (btn.Text == "")
            {
                btn.Text = xTurn ? "X" : "O";
                board[row, col] = xTurn ? 'X' : 'O';
                xTurn = !xTurn;

                CheckWinner();
            }
        }

        private void InitializeComponent()
        {
        }
    }

    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        protected override void InitializeBoard()
        {

            board = new char[3, 3];
            xTurn = true;

            buttons = new Button[3, 3] {
                { btn_1, btn_2, btn_3 },
                { btn_4, btn_5, btn_6 },
                { btn_7, btn_8, btn_9 }
            };

            foreach (Button btn in buttons)
            {
                btn.Text = "";
                btn.Enabled = true;
                btn.Click += Button_Click;
            }
        }

        protected override void CheckWinner()
        {

            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != '\0' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    ShowWinner(board[i, 0]);
                    return;
                }
                if (board[0, i] != '\0' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    ShowWinner(board[0, i]);
                    return;
                }
            }

            if (board[0, 0] != '\0' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                ShowWinner(board[0, 0]);
                return;
            }
            if (board[0, 2] != '\0' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                ShowWinner(board[0, 2]);
                return;
            }

            bool isDraw = true;
            foreach (char c in board)
            {
                if (c == '\0')
                {
                    isDraw = false;
                    break;
                }
            }

            if (isDraw)
            {
                lblResult.Text = "It's a Draw!";
            }
        }

        protected override void ShowWinner(char winner)
        {
            lblResult.Text = $"{winner} Wins!";
            foreach (Button btn in buttons)
            {
                btn.Enabled = false;
            }
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            InitializeBoard();

            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InitializeBoard();

            LoginInterface loginInterface = new LoginInterface();
            loginInterface.Show();

            this.Hide();
        }
    }
}
