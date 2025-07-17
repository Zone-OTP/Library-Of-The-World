using LibraryOfTheWorld.Forms.AdministrativeForms;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;
using LibraryOfTheWorld.VeiwModes;


namespace LibraryOfTheWorld.Forms
{
    public partial class LibraryForAdmins : Form
    {
        public string currentUser;
        public LibraryForAdmins()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }
        private static LibraryForAdmins instance;
        public static LibraryForAdmins Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new LibraryForAdmins();
                return instance;
            }
        }
        private async void Library_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            var bookViewModels = await BookService.LoadBooksWithAuthorsAsync();
            await SetupBookGrid(bookViewModels);
            SignedInAs.Text = currentUser;
            this.ResumeLayout(true);
            this.PerformLayout();
            this.Update();
            this.Refresh();


        }

        private void Library_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void RemoveByRoot_Click(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0)
            {

                BookViewModel selectedBook = (BookViewModel)BookGrid.SelectedRows[0].DataBoundItem;
                await BookService.RemoveBookByRoot(selectedBook.BookId);
                this.Activate();
                UpdateBookCounts();
                BookGrid.Refresh();
            }
            else
            {
                NotificationService.ShowMessage("Please select a book first!");
                return;
            }
            BookGrid.Refresh();
        }

        private void AddBook_Click(object sender, EventArgs e)
        {
            AddBookForm.Instance.Show();
            AddBookForm.Instance.Location = this.Location;

        }
        private async void UpdateBookCounts()
        {
            if (BookGrid.DataSource is List<BookViewModel> bookViewModels)
            {
                int totalBooks = bookViewModels.Sum(b => b.TotalAmountInLibrary);
                int booksAvailable = bookViewModels.Sum(b => b.AmountInLibrary);
                int booksTaken = totalBooks - booksAvailable;

                TotalBooksLable.Text = totalBooks.ToString();
                BooksTakenOutLabel.Text = booksTaken.ToString();
                BooksAvalablelabel.Text = booksAvailable.ToString();
            }
        }

        private async void RemoveOneBook_Click(object sender, EventArgs e)
        {

            if (BookGrid.SelectedRows.Count > 0)
            {
                BookViewModel selectedBook = (BookViewModel)BookGrid.SelectedRows[0].DataBoundItem;
                await BookService.RemoveBook(selectedBook.BookId);
                UpdateBookCounts();
                BookGrid.Refresh();
            }
            else
            {
                NotificationService.ShowMessage("Please select a book first!");
                return;
            }


        }

        private async void Library_Activated(object sender, EventArgs e)
        {
            UpdateBookCounts();
            var bookViewModels = await BookService.LoadBooksWithAuthorsAsync();
            await SetupBookGrid(bookViewModels);
            this.ResumeLayout(true);
            this.PerformLayout();
            this.Update();
            this.Refresh();



        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            SignedInAs.Text = currentUser = "";
            Signin.Instance.Show();
            Signin.Instance.Location = this.Location;
            this.Hide();

        }

        private async void BookGrid_SelectionChanged(object sender, EventArgs e)
        {
            UpdateBookCounts();
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

        private void EditBookButton_Click(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0)
            {

                BookViewModel selectedBook = (BookViewModel)BookGrid.SelectedRows[0].DataBoundItem;

                EditBookForm editForm = new EditBookForm(selectedBook);
                editForm.ShowDialog();
            }
            else
            {
                NotificationService.ShowMessage("Please select a book to edit.");
            }
        }

        private void DarkModeToggleButton_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = !ThemeManager.IsDarkMode;
            foreach (Form form in Application.OpenForms)
            {
                ThemeManager.ApplyTheme(form);
            }

        }

        private void BookGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewRow row = BookGrid.Rows[e.RowIndex];
                var AmountCell = row.Cells["AmountInLibrary"];


                var Amount = AmountCell.Value as int?;
                Console.WriteLine($"Fine Amount for row {e.RowIndex}: {Amount}");

                if (Amount.HasValue && (Amount == 0))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.SelectionForeColor = row.DefaultCellStyle.ForeColor;


            }
        }

        private async Task SetupBookGrid(List<BookViewModel> bookViewModels)
        {
            BookGrid.CellContentClick -= BookGrid_CellContentClick;

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
                            ("Available", "AmountInLibrary", 60),
                            ("Total", "TotalAmountInLibrary", 60)
                };

            foreach (var (header, prop, width) in cols)
            {
                BookGrid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = header,
                    Name = prop,
                    DataPropertyName = prop,
                    Width = width,
                    ReadOnly = true
                });
            }

            BookGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "View Checkouts",
                Name = "ViewCheckouts",
                Text = "View",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            BookGrid.DataSource = bookViewModels;
            BookGrid.CellContentClick += BookGrid_CellContentClick;
        }

        private void LibraryForAdmins_Shown(object sender, EventArgs e)
        {
        }

        private void BookGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && BookGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var buttonColumn = (DataGridViewButtonColumn)BookGrid.Columns[e.ColumnIndex];
                if (buttonColumn.Name == "ViewCheckouts")
                {
                    var bookGridRows = BookGrid.Rows[e.RowIndex].Cells;
                    var bookViewModel = (BookViewModel)BookGrid.Rows[e.RowIndex].DataBoundItem;
                    if (bookViewModel != null)
                    {
                        var bookId = bookViewModel.BookId;
                        using (var checkoutForm = new CustomerCheckoutForm(bookId))
                        {
                            checkoutForm.ShowDialog();
                        }
                    }
                    else
                    {
                        NotificationService.ShowMessage("Invalid Book ID.", "Error");
                    }

                }
            }
            return;
        }

        private void CustomerPanelButton_Click(object sender, EventArgs e)
        {
            var adminCustomerDisplay = new AdminCustomerDisplay();
            adminCustomerDisplay.ShowDialog();
        }
    }
}
