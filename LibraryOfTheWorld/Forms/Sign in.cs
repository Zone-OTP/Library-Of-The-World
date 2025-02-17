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
using LibraryOfTheWorld.DattaHandlers;
using LibraryOfTheWorld.Forms;


namespace LibraryOfTheWorld
{
    public partial class Signin : Form
    {
        private static User users = new User("", "");
        private static JsonUsersDataHandler dataHandler = new JsonUsersDataHandler();

        private static Signin instance;
        public static Signin Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed) 
                    instance = new Signin();
                return instance;
            }
        }
        public Signin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string password = PasswordTextBox.Text;

            try
            {
                if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(password))
                {
                    if (users.SignInCheck(name, password))
                    {
                        MessageBox.Show("you have signed in");
                        Library.Instance.Show();
                        Library.Instance.Location = this.Location;
                        this.Hide();
                    }
                    else { throw new Exception("name or password is incorrect"); }
                }
                else { throw new Exception("name or password can't be empty"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Switch_Click(object sender, EventArgs e)
        {
            SignUp.Instance.Show();
            SignUp.Instance.Location = this.Location;
            this.Hide();
        }

        private void Signin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }
    }
}
