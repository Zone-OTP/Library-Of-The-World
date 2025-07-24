using LibraryOfClasses.Classes;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;

namespace LibraryOfTheWorld.Forms
{
    public partial class AdminCustomerCheck : Form
    {
        private Customer _customer;
        public AdminCustomerCheck(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private async void DeleteAccButton_Click(object sender, EventArgs e)
        {
            DialogResult result = NotificationService.ShowMessageYesNo("are you sure you want to Delete Your account?", "Are You Sure?");

            if (result == DialogResult.Yes)
            {
                await CustomerService.DeleteCustomer(_customer.CustomerId);
                NotificationService.ShowMessage("You're account Has Been Deleted");
                this.Close();
                return;
            }
            else { return; }
        }

        private void AdminCustomerDisplay_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            LibraryCardOfCustomer.Text = Convert.ToString(_customer.LibraryCardNumber);
            NameOfCustomer.Text = _customer.Name;
            EmailOfCustomer.Text = _customer.Email;
            GovermentIdOfCustomer.Text = _customer.PersonalGovermentID;
            IdOfCustomer.Text = Convert.ToString(_customer.CustomerId);
        }
    }
}
