using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.Users;
using LibraryOfTheWorld.Services;

namespace LibraryOfTheWorld
{

    public partial class SignUp : Form
    {
       
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string password = PasswordTextBox.Text;
            try
            {
                long govId = Convert.ToInt64(GovermentIdTextBox.Text);
            }
            catch(FormatException) {
                MessageBox.Show("No Letters in the Goverment ID");
                return;
            }

           
            try
            {
                
                long govId = Convert.ToInt64(GovermentIdTextBox.Text);
                int digitCount = govId.ToString().Length;
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
                {
                    if (digitCount == 11)
                    {
                        CustomerService.AddCustomer(name, password, govId);
                        Signin.Instance.Show();
                        Signin.Instance.Location = this.Location;
                        this.Hide();
                    }
                    else { throw new Exception("Goverment Id is not correct"); }
                }
                else { throw new Exception("name or password can't be empty"); }
            }catch (Exception ex) {MessageBox.Show(ex.Message); }
        }

        private void ShowUsersTest_Click(object sender, EventArgs e)
        {
            AdminService.ShowUsers();
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            Signin.Instance.Show();
            Signin.Instance.Location = this.Location;
            this.Hide();
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

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
