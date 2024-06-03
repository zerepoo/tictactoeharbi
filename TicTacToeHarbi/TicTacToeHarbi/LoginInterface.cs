using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeHarbi
{
    public partial class LoginInterface : Form
    {
        public LoginInterface()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void LoginInterface_Load(object sender, EventArgs e)
        {

        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string password = textBox2.Text;


            if (username == "admin" && password == "adminpass123")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.Hide();


                AdminPanel adminPanel = new AdminPanel();
                adminPanel.ShowDialog();


                this.Hide();
            }
            else
            {
                var user = AdminPanel.users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    Form1 form1 = new Form1();
                    form1.Show();

                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
