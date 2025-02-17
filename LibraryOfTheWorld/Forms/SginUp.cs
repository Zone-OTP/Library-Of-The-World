using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld;
using LibraryOfTheWorld.Users;

namespace LibraryOfTheWorld
{
    public partial class SignUp : Form
    {
        private static User users = new User("","");

        private static SignUp instance;
        public static SignUp Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed) 
                    instance = new SignUp();
                return instance;
            }
        }

        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string password = PasswordTextBox.Text;

            try
            {
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
                {
                    users.AddUser(new User(name, password));
                    Signin.Instance.Show();
                    Signin.Instance.Location = this.Location;
                    this.Hide();
                }
                else { throw new Exception("name or password can't be empty"); }
            }catch (Exception ex) {MessageBox.Show(ex.Message); }
        }

        private void ShowUsersTest_Click(object sender, EventArgs e)
        {
            users.ShowUsers();
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            Signin.Instance.Show();
            Signin.Instance.Location = this.Location;
            this.Hide();
        }

        private void SignUp_FormClosed(object sender, EventArgs e) {
            Application.Exit();
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') 
            {
                e.Handled = true; 
            }
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
