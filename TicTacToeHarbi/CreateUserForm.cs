using System;
using System.Windows.Forms;

namespace TicTacToeHarbi
{
    public partial class CreateUserForm : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void createUserBtn_Click(object sender, EventArgs e)
        {
            Username = usernameTextBox.Text;
            Password = passwordTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
