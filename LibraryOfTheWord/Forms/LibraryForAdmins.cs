using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.DattaHandlers;
using LibraryOfTheWorld.Interfaces;
using LibraryOfTheWorld.Users;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LibraryOfTheWorld.Services;


namespace LibraryOfTheWorld.Forms
{
    public partial class LibraryForAdmins : Form
    {
        

        private JsonUsersDataHandler dataHandler = new JsonUsersDataHandler();
        private List<Customer> allCustomers;



        public string currentUser;
        
        public LibraryForAdmins()
        {
            InitializeComponent();
            allCustomers = CustomerService.GetAllCustomers();
            SetupBookGrid();
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
        private void Library_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            SignedInAs.Text = currentUser;
            
        }

        private void Library_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RemoveByRoot_Click(object sender, EventArgs e)
        {
            Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
            BookService.RemoveBookByRoot(selectedBook);
            BookGrid.DataSource = BookService.LoadBooks();
        }

        private void AddBook_Click(object sender, EventArgs e)
        {
            AddBookForm.Instance.Show();
            AddBookForm.Instance.Location = this.Location;
        }
        private void UpdateBookCounts()
        {
            int totalBooks = 0;
            int booksTaken = 0;
            int booksAvailable = 0;
            List<Book> BooklistForCounter = BookService.LoadBooks();
            foreach (var book in BooklistForCounter)
            {
                totalBooks += book.TotalAmountInLibrary;
                booksAvailable += book.AmountInLibrary;
            }
            booksTaken = totalBooks - booksAvailable;

            TotalBooksLable.Text = $"{totalBooks}";
            BooksTakenOutLabel.Text = $"{booksTaken}";
            BooksAvalablelabel.Text = $"{booksAvailable}";
        }

        private void RemoveOneBook_Click(object sender, EventArgs e)
        {

            Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
            if (BookGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book first!");
                return;
            }
            BookService.RemoveBook(selectedBook);
            BookService.SaveBooks();
            BookGrid.DataSource = BookService.LoadBooks();
            UpdateBookCounts();
            BookGrid.Refresh();
            

        }

        private void Library_Activated(object sender, EventArgs e)
        {

            BookGrid.DataSource = BookService.LoadBooks();
            BookService.SaveBooks();
            UpdateBookCounts();
            BookGrid.Refresh();
        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            SignedInAs.Text = currentUser = "";
            Signin.Instance.Show();
            Signin.Instance.Location = this.Location;
            this.Hide();
            
        }

        private void BookGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0)
            {
                Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
                NameOfBook.Text = selectedBook.Name;
                AuthorOfBook.Text = AuthorService.GetAuthorNameById(selectedBook.AuthorId);
                if (selectedBook.AmountInLibrary == 0)
                {
                    TakenOrNot.Text = $"Taken/Not Available";
                }
                else if (selectedBook.AmountInLibrary != 0) { TakenOrNot.Text = $"{selectedBook.AmountInLibrary} Available!"; }
            }
            
        }

        private void BookGrid_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            BookService.SaveBooks();

        }

        private void BookGrid_Enter(object sender, EventArgs e)
        {
            BookGrid.DataSource = BookService.LoadBooks();

        }

        private void EditBookButton_Click(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0) 
            {
                
                Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
                
                EditBookForm editForm = new EditBookForm(selectedBook);
                editForm.ShowDialog(); 

                BookGrid.DataSource = null;
                BookGrid.DataSource = BookService.LoadBooks(); 
            }
            else
            {
                MessageBox.Show("Please select a book to edit.");
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
            if (e.ColumnIndex == BookGrid.Columns["TakenBy"].Index && e.RowIndex >= 0)
            {
                Book book = BookGrid.Rows[e.RowIndex].DataBoundItem as Book;
                if (book == null) return;

                var customersWhoTookBook = allCustomers
                    .Where(c => c.BooksTaken.Any(b => b.BookId == book.BookId))
                    .ToList();

                e.Value = customersWhoTookBook.Any() ? customersWhoTookBook.First().Name : "None";
                e.FormattingApplied = true; 
            }
        }

        private void SetupBookGrid()
        {
            BookGrid.AutoGenerateColumns = false;
            BookGrid.DataSource = BookService.LoadBooks(); 
            BookGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BookGrid.ReadOnly = false;
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                DataPropertyName = "BookId"
            });
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Title",
                DataPropertyName = "Name"
            });
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Author",
                HeaderText = "Author",
                DataPropertyName = "AuthorName"
            });
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AmountInLibrary",
                HeaderText = "Amount In The Library",
                DataPropertyName = "AmountInLibrary"
            });
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total Amoount In The Library",
                HeaderText = "Total Amoount In The Library",
                DataPropertyName = "TotalAmountInLibrary"
            });

            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn
            {
                DataSource = CustomerService.GetAllCustomers(),
                Name = "TakenBy",
                HeaderText = "Taken By",
                DisplayMember = "Name",
                ValueMember = "Name"
            };
            BookGrid.Columns.Add(comboColumn);

            allCustomers = CustomerService.GetAllCustomers();

            BookGrid.CellFormatting += BookGrid_CellFormatting;
        }

       
    }
}
