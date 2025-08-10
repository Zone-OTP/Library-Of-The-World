using LibraryOfClasses.Classes;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;
using LibraryOfClasses.VeiwModes;
using System.Reflection;



namespace LibraryOfTheWorld.Forms
{
    public partial class LibraryForCustomers : Form
    {
        public LibraryForCustomers()
        {
            InitializeComponent();
        }
        private static LibraryForCustomers instance;
        public Customer currentUser;
        private List<BookViewModel> bookViewModels;
        public static LibraryForCustomers Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new LibraryForCustomers();
                return instance;
            }
        }

        private async void LibraryForCustomers_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            bookViewModels = await BookService.LoadBooksWithAuthorsAsync();
            SetupBookGrid(bookViewModels);
            SignedInAs.Text = currentUser.Name;

            this.ResumeLayout(true);
            this.PerformLayout();
            this.Invalidate(true);
            this.Update();
            this.Refresh();
        }

        private void LibraryForCustomers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            SignedInAs.Text = "";
            Signin.Instance.Show();
            Signin.Instance.Location = this.Location;
            this.Hide();
        }

        private void DarkModeToggleButton_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = !ThemeManager.IsDarkMode;
            foreach (Form form in Application.OpenForms)
            {
                ThemeManager.ApplyTheme(form);

            }
        }

        private async void TakeBookOut_Click(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0)
            {
                BookViewModel selectedBook = (BookViewModel)BookGrid.SelectedRows[0].DataBoundItem;
                await BookService.TakeBookOutAsync(selectedBook.BookId, currentUser.CustomerId);
                BookGrid.DataSource = await BookService.LoadBooksWithAuthorsAsync();

            }
            else { NotificationService.ShowMessage("pick a book"); return; }
        }

        private async void ReturnBook_Click(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0)
            {
                BookViewModel selectedBook = (BookViewModel)BookGrid.SelectedRows[0].DataBoundItem;
                await BookService.ReturnBook(selectedBook.BookId, currentUser.CustomerId);
                BookGrid.DataSource = await BookService.LoadBooksWithAuthorsAsync();

            }
            else { NotificationService.ShowMessage("pick a book"); return; }
        }


        private async void BookGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0)
            {
                BookViewModel selectedBook = (BookViewModel)BookGrid.SelectedRows[0].DataBoundItem;
                NameOfBook.Text = selectedBook.Name;
                AuthorOfBook.Text = selectedBook.AuthorName ?? "Unknown Author";
                if (selectedBook.AmountInLibrary == 0)
                {
                    TakenOrNot.Text = "Taken/Not Available";
                }
                else
                {
                    TakenOrNot.Text = $"{selectedBook.AmountInLibrary} Available!";
                }
            }
        }

        private void SignedInAs_Click(object sender, EventArgs e)
        {
            CustomerDisplayForm custDisplay = new CustomerDisplayForm(currentUser);
            custDisplay.ShowDialog();
        }

        private async void LibraryForCustomers_Activated(object sender, EventArgs e)
        {
            BookGrid.DataSource = await BookService.LoadBooksWithAuthorsAsync();
        }

        private async void PayOverdue_Click(object sender, EventArgs e)
        {

            if (BookGrid.SelectedRows.Count > 0)
            {
                BookViewModel selectedBook = (BookViewModel)BookGrid.SelectedRows[0].DataBoundItem;
                await BookService.PayFine(selectedBook.BookId, currentUser.CustomerId);
            }
        }

        private async void SetupBookGrid(List<BookViewModel> bookViewModels)
        {
            try
            {
                BookGrid.DataSource = null;
                BookGrid.Columns.Clear();

                BookGrid.AutoGenerateColumns = false;
                BookGrid.AllowUserToAddRows = false;
                BookGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                BookGrid.MultiSelect = false;

                var cols = new[] {
                    ("ID", "BookId", 60),
                    ("Title", "Name", 100),
                    ("Author", "AuthorName", 100),
                    ("Amount In The Library", "AmountInLibrary", 120),
                    ("Total Amount In The Library", "TotalAmountInLibrary", 120)
                };

                foreach (var (header, prop, width) in cols)
                {
                    BookGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = header,
                        DataPropertyName = prop,
                        Width = width,
                        ReadOnly = true
                    });
                }

                BookGrid.CellFormatting -= BookGrid_CellFormatting;
                BookGrid.CellFormatting += BookGrid_CellFormatting;

                typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                                    ?.SetValue(BookGrid, true);

                BookGrid.DataSource = bookViewModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        private async void BookGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
