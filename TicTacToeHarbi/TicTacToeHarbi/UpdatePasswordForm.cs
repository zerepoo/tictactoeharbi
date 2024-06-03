using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static TicTacToeHarbi.AdminPanel;

namespace TicTacToeHarbi
{
    public partial class UpdatePasswordForm : Form
    {
        private List<User> users;

        public string Username { get; private set; }
        public string Password { get; private set; }

        public UpdatePasswordForm(List<User> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void updatePasswordBtn_Click(object sender, EventArgs e)
        {
            Username = usernameTextBox.Text;
            Password = passwordTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
