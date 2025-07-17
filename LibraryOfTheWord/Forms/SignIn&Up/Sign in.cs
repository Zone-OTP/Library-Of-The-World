using LibraryOfTheWorld.Forms;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;


namespace LibraryOfTheWorld
{
    public partial class Signin : Form
    {

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
            ThemeManager.ApplyTheme(this);
        }


        private async void SignInButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string password = PasswordTextBox.Text;


            try
            {
                if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(password))
                {
                    if (await AdminService.SignInCheck(name, password))
                    {
                        NotificationService.ShowMessage("you have signed in as an Admin");
                        LibraryForAdmins.Instance.currentUser = name;
                        LibraryForAdmins.Instance.Show();
                        Application.DoEvents();
                        LibraryForAdmins.Instance.Location = this.Location;
                        NameTextBox.Text = "";
                        PasswordTextBox.Text = "";
                        this.Hide();
                    }
                    else if (await CustomerService.ValidateLoginAsync(name, password))
                    {
                        NotificationService.ShowMessage("you have signed in");
                        LibraryForCustomers.Instance.currentUser = await CustomerService.GetCustomerByNameAsync(name);
                        LibraryForCustomers.Instance.Show();
                        LibraryForCustomers.Instance.Location = this.Location;
                        NameTextBox.Text = "";
                        PasswordTextBox.Text = "";
                        Application.DoEvents();
                        this.Hide();
                    }
                    else { throw new Exception("name or password is incorrect"); }
                }
                else { throw new Exception("name or password can't be empty"); }
            }
            catch (Exception ex) { NotificationService.ShowMessage(ex.Message); }
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

        private void ForgotPasswordBtn_Click(object sender, EventArgs e)
        {
            var changepassform = new ChangePasswordForm();
            changepassform.ShowDialog();
        }
    }
}
