using LibraryOfTheWorld.Forms;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;
using LibraryErrorLogs;

namespace LibraryOfTheWorld
{
    public partial class Signin : Form
    {

        private static Signin instance;
        private readonly ILoggerService _logger;
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
            _logger = new LoggerService("Signin");
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
                        await _logger.LogInformation($"Admin has Signed in Name of {name}");
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
                        await _logger.LogInformation($"Customer has Signed in Name of {name}");
                        var customer = await CustomerService.GetCustomerByNameAsync(name);
                        LibraryForCustomers.Instance.currentUser = customer;
                        LibraryForCustomers.Instance.Show();
                        LibraryForCustomers.Instance.Location = this.Location;
                        NameTextBox.Text = "";
                        PasswordTextBox.Text = "";
                        await NotificationService.MailNotifySignIn(customer);
                        Application.DoEvents();
                        this.Hide();
                    }
                    else { throw new Exception("name or password is incorrect"); }
                }
                else { throw new Exception("name or password can't be empty"); }
            }
            catch (Exception ex) { await _logger.LogError(ex,"Error at SignIn"+ex.Message); }
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
