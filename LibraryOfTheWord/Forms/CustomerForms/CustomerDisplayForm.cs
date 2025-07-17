using System.Text;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;


namespace LibraryOfTheWorld.Forms
{
    public partial class CustomerDisplayForm : Form
    {
        private Customer _customer;
        public CustomerDisplayForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void CustomerDisplayForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            LibraryCardOfCustomer.Text = Convert.ToString(_customer.LibraryCardNumber);
            NameOfCustomer.Text = _customer.Name;
            EmailOfCustomer.Text = _customer.Email;
            GovermentIdOfCustomer.Text = _customer.PersonalGovermentID;
            IdOfCustomer.Text = Convert.ToString(_customer.CustomerId);
        }

        private async void DeleteAccButton_ClickAsync(object sender, EventArgs e)
        {
            DialogResult result = NotificationService.ShowMessageYesNo("are you sure you want to Delete Your account?", "Are You Sure?");

            if (result == DialogResult.Yes)
            {
                await CustomerService.DeleteCustomer(_customer.CustomerId);
                NotificationService.ShowMessage("You're account Has Been Deleted");
                Signin.Instance.Show();
                Signin.Instance.Location = this.Location;
                LibraryForCustomers.Instance.Hide();
                this.Close();
                return;
            }
            else { return; }
        }

        private async void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            string email = _customer.Email;



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
