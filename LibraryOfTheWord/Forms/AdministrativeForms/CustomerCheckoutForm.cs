using System.Data;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;
using LibraryOfTheWorld.VeiwModes;

namespace LibraryOfTheWorld.Forms
{
    public partial class CustomerCheckoutForm : Form
    {
        private readonly int _bookId;
        public CustomerCheckoutForm(int bookId)
        {
            InitializeComponent();
            _bookId = bookId;
            this.DoubleBuffered = true;
        }

        private async Task CustomerGridViewSetUp(int bookId)
        {
            var book = await BookService.GetBookById(bookId);
            if (book == null)
            {
                NotificationService.ShowMessage("Book not found.", "Error");
                return;
            }
            var authorName = await AuthorService.GetAuthorNameById(book.AuthorId);

            BookInfoLabel.Text = $"Book ID: {book.BookId}, Title: {book.Name}, Author: {authorName}";

            var checkouts = await CheckoutService.LoadCheckouts();
            var customers = await CustomerService.LoadCustmers();
            var dailyFineRate = 0.5;
            var viewModels = checkouts.Where(c => c.BookId == _bookId).Select(c => new CustomerCheckoutViewModel
            {
                BookId = _bookId,
                CustomerId = c.CustomerId,
                CustomerName = customers.FirstOrDefault(cu => cu.CustomerId == c.CustomerId).Name,
                CheckoutDate = c.CheckoutDate,
                FineAmount = DateTime.Now.Month > c.CheckoutDate.Month ? (DateTime.Now - c.CheckoutDate).Days * dailyFineRate : 0.0,
                DaysTakenOut = (DateTime.Now - c.CheckoutDate).Days
            }).ToList();

            CustomerGrid.DataSource = null;
            CustomerGrid.Columns.Clear();

            CustomerGrid.AutoGenerateColumns = false;
            CustomerGrid.AllowUserToAddRows = false;
            CustomerGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomerGrid.MultiSelect = false;
            CustomerGrid.ReadOnly = true;

            CustomerGrid.DefaultCellStyle.SelectionBackColor = CustomerGrid.DefaultCellStyle.BackColor;
            CustomerGrid.DefaultCellStyle.SelectionForeColor = CustomerGrid.DefaultCellStyle.ForeColor;

            CustomerGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Book ID",
                DataPropertyName = "BookId",
                Width = 80,
            });
            CustomerGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Customer ID",
                DataPropertyName = "CustomerId",
                Width = 80,
            });
            CustomerGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Customer Name",
                DataPropertyName = "CustomerName",
                Width = 120,
            });
            CustomerGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Checkout Date",
                DataPropertyName = "CheckoutDate",
                Width = 100,
            });
            CustomerGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fine Due",
                Name = "Fine Due",
                DataPropertyName = "FineAmount",
                Width = 80,
            });
            CustomerGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Days Taken Out",
                DataPropertyName = "DaysTakenOut",
                Width = 80,
            });

            CustomerGrid.DataSource = viewModels;
        }

        private void CustomerGridVeiw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomerCheckoutForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            CustomerGridViewSetUp(_bookId);
            this.ResumeLayout(true);
            this.PerformLayout();
            this.Update();
            this.Refresh();

        }

        private void CustomerCheckoutForm_Activated(object sender, EventArgs e)
        {

            this.ResumeLayout(true);
            this.PerformLayout();
            this.Update();
            this.Refresh();
        }

        private void CustomerGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                foreach (DataGridViewColumn col in CustomerGrid.Columns)
                {
                    Console.WriteLine($"Column Name: {col.Name}, HeaderText: {col.HeaderText}");
                }

                DataGridViewRow row = CustomerGrid.Rows[e.RowIndex];
                var fineAmountCell = row.Cells["Fine Due"];
                if (fineAmountCell == null)
                {
                    Console.WriteLine("Fine Due cell not found!");
                    return;
                }

                var fineAmount = fineAmountCell.Value as double?;
                Console.WriteLine($"Fine Amount for row {e.RowIndex}: {fineAmount}");

                if (fineAmount.HasValue && (fineAmount > 0.0))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.SelectionForeColor = row.DefaultCellStyle.ForeColor;
                //CustomerGrid.InvalidateRow(e.RowIndex);

            }
        }

        private async void CheckCustomerButton_Click(object sender, EventArgs e)
        {
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                CustomerCheckoutViewModel customerVeiwModel = (CustomerCheckoutViewModel)CustomerGrid.SelectedRows[0].DataBoundItem;
                var customer = await CustomerService.GetCustomerByIdAsync(customerVeiwModel.CustomerId);

                var AdminCustomerDisplay = new AdminCustomerCheck(customer);
                AdminCustomerDisplay.ShowDialog();
            }
        }
    }
}