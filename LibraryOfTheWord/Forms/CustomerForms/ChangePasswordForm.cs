using System.Text;
using LibraryOfTheWorld.Themes;


namespace LibraryOfTheWorld.Forms
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
        }

        private async void SendEmailButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            using (var client = new HttpClient())
            {
                var content = new StringContent($"\"{email}\"", Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5160/api/passwordreset/request", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reset email sent!");
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Error: " + response.ReasonPhrase);
                    this.Close();
                    return;
                }

            }
        }
    }
}
