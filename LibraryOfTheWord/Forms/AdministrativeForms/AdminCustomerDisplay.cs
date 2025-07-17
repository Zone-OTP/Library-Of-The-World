using System.Threading.Tasks;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;
using LibraryOfTheWorld.VeiwModes;


namespace LibraryOfTheWorld.Forms.AdministrativeForms
{
    public partial class AdminCustomerDisplay : Form
    {
        public AdminCustomerDisplay()
        {
            InitializeComponent();
        }

        private async void AdminCustomerDisplay_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            CustomerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CustomerDataGrid.DataSource = await CustomerService.LoadCustmers();
            CustomerDataGrid.ReadOnly = true;
        }

        private async void DeleteCustomerAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                Customer Selectedcustomer = (Customer)CustomerDataGrid.SelectedRows[0].DataBoundItem;
                await CustomerService.DeleteCustomer(Selectedcustomer.CustomerId);
                CustomerDataGrid.Refresh();
                CustomerDataGrid.DataSource = await CustomerService.LoadCustmers();
            }
            catch (Exception ex) { NotificationService.ShowMessage(ex.Message); }
        }

        private async Task CustomerGridViewSetUp(int customerId)
        {
            try
            {
                var checkouts = await CheckoutService.LoadCheckouts();
                var customers = await CustomerService.LoadCustmers();
                var dailyFineRate = 0.5;
                var viewModels = checkouts.Where(c => c.CustomerId == customerId).Select(c => new CustomerCheckoutViewModel
                {
                    BookId = c.BookId,
                    CustomerId = c.CustomerId,
                    CustomerName = customers.FirstOrDefault(cu => cu.CustomerId == c.CustomerId).Name,
                    CheckoutDate = c.CheckoutDate,
                    FineAmount = DateTime.Now.Month > c.CheckoutDate.Month ? (DateTime.Now - c.CheckoutDate).Days * dailyFineRate : 0.0,
                    DaysTakenOut = (DateTime.Now - c.CheckoutDate).Days
                }).ToList();

                CheckoutsDataGrid.DataSource = null;
                CheckoutsDataGrid.Columns.Clear();

                CheckoutsDataGrid.AutoGenerateColumns = false;
                CheckoutsDataGrid.AllowUserToAddRows = false;
                CheckoutsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                CheckoutsDataGrid.MultiSelect = false;
                CheckoutsDataGrid.ReadOnly = true;

                CheckoutsDataGrid.DefaultCellStyle.SelectionBackColor = CheckoutsDataGrid.DefaultCellStyle.BackColor;
                CheckoutsDataGrid.DefaultCellStyle.SelectionForeColor = CheckoutsDataGrid.DefaultCellStyle.ForeColor;

                CheckoutsDataGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Book ID",
                    DataPropertyName = "BookId",
                    Width = 80,
                });
                CheckoutsDataGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Customer ID",
                    DataPropertyName = "CustomerId",
                    Width = 80,
                });
                CheckoutsDataGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Customer Name",
                    DataPropertyName = "CustomerName",
                    Width = 120,
                });
                CheckoutsDataGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Checkout Date",
                    DataPropertyName = "CheckoutDate",
                    Width = 100,
                });
                CheckoutsDataGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Fine Due",
                    Name = "Fine Due",
                    DataPropertyName = "FineAmount",
                    Width = 80,
                });
                CheckoutsDataGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Days Taken Out",
                    DataPropertyName = "DaysTakenOut",
                    Width = 80,
                });

                CheckoutsDataGrid.DataSource = viewModels;
            }
            catch { NotificationService.ShowMessage("failed To Set Up Grid In AdminCustomerDisplayForm "); }
        }

        private async void CustomerDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Customer Selectedcustomer = (Customer)CustomerDataGrid.SelectedRows[0].DataBoundItem;

                await CustomerGridViewSetUp(Selectedcustomer.CustomerId);
            }
            catch { NotificationService.ShowMessage("Failed to Change SelectedCustomerData FROM CellClick in customerDataGrid"); }
        }

        private async void ForceReturnBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerCheckoutViewModel selectedCheckout = (CustomerCheckoutViewModel)CheckoutsDataGrid.SelectedRows[0].DataBoundItem;
                var tempId = selectedCheckout.CustomerId;
                await BookService.ReturnBook(selectedCheckout.BookId, selectedCheckout.CustomerId);
                await CustomerGridViewSetUp(tempId);
            }
            catch
            {
                NotificationService.ShowMessage("Error In ForceReturnBookButtonClick in Adminsistrator Customer Display --Falure");
            }
        }

        private void ForceReturnBookButton_MouseHover(object sender, EventArgs e)
        {
            SendCollectionOfficersToolTip.Show("This Sends Collection Officers to Forcibly get the book Back, For The Library\nIt Requires you to" +
                " click a checkout and then Click the button For the Officcers to know which book is to be returned", ForceReturnBookButton);

        }
    }
}
