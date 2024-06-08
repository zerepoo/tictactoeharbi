using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToeHarbi
{
    public partial class AdminPanel : Form
    {
     
        public static List<User> users = new List<User>();

        public AdminPanel()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label3_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void admin_create_btn_Click(object sender, EventArgs e)
        {

            CreateUserForm createUserForm = new CreateUserForm();
            if (createUserForm.ShowDialog() == DialogResult.OK)
            {
                var newUser = new User { Username = createUserForm.Username, Password = createUserForm.Password };
                users.Add(newUser);
                MessageBox.Show($"User '{newUser.Username}' created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void admin_updt_btn_Click(object sender, EventArgs e)
        {
           
            UpdatePasswordForm updatePasswordForm = new UpdatePasswordForm(users);
            if (updatePasswordForm.ShowDialog() == DialogResult.OK)
            {
                var user = users.FirstOrDefault(u => u.Username == updatePasswordForm.Username);
                if (user != null)
                {
                    user.Password = updatePasswordForm.Password;
                    MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void admin_backbtn_Click(object sender, EventArgs e)
        {

            LoginInterface loginInterface = new LoginInterface();
            loginInterface.Show();

            this.Hide();
        }
    }   

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
