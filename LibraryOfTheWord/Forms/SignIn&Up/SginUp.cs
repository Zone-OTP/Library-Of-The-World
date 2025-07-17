using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string password = PasswordTextBox.Text;
            string email = EmailTextBox.Text;
            try
            {
                long govId = Convert.ToInt64(GovermentIdTextBox.Text);
            }
            catch (FormatException)
            {
                NotificationService.ShowMessage("No Letters in the Goverment ID");
                return;
            }


            try
            {

                string govId = GovermentIdTextBox.Text;
                int digitCount = govId.ToString().Length;
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
                {
                    if (digitCount == 11)
                    {
                        await CustomerService.AddCustomer(name, password, govId, email);
                        Signin.Instance.Show();
                        Signin.Instance.Location = this.Location;
                        this.Hide();
                    }
                    else { throw new Exception("Goverment Id is not correct"); }
                }
                else { throw new Exception("name or password can't be empty"); }
            }
            catch (Exception ex) { NotificationService.ShowMessage(ex.Message); }
        }

        private void ShowUsersTest_Click(object sender, EventArgs e)
        {

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


        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
