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
using LibraryOfTheWorld.DBData;
using System.Reflection;


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
        private void Library_Load(object sender, EventArgs e)
        {
            SetupBookGrid();
            SignedInAs.Text = currentUser; 
            ThemeManager.ApplyTheme(this);

            this.ResumeLayout(true);
            this.PerformLayout();
            this.Invalidate(true);
            this.Update();
            this.Refresh();
        }

        private void Library_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RemoveByRoot_Click(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0)
            {
                Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
                BookService.RemoveBookByRoot(selectedBook);
                BookGrid.DataSource = BookService.LoadBooks();
            }
            else
            {
                MessageBox.Show("Please select a book first!");
                return;
            }
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
            if (BookGrid.SelectedRows.Count > 0)
            {
                Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
                BookService.RemoveBook(selectedBook);
                BookService.SaveBooks();
                BookGrid.DataSource = BookService.LoadBooks();
                UpdateBookCounts();
                BookGrid.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a book first!");
                return;
            }

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
            UpdateBookCounts();
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
            this.Refresh();
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
            if (BookGrid.Columns[e.ColumnIndex].Name == "TakenBy" && e.RowIndex >= 0)
            {
                var book = (Book)BookGrid.Rows[e.RowIndex].DataBoundItem;
                if (book != null)
                {
                    var cell = BookGrid.Rows[e.RowIndex].Cells["TakenBy"] as DataGridViewComboBoxCell;
                    if (cell != null)
                    {
                        var takenByCustomers = CustomerService.GetCustomersForBook(book.BookId);
                        cell.DataSource = takenByCustomers;
                        cell.DisplayMember = "Name";
                        cell.ValueMember = "Name";

                        if (takenByCustomers.Any())
                        {
                            string selectedName = takenByCustomers.First().Name;
                            cell.Value = selectedName; 
                            e.Value = selectedName;    
                        }
                        else
                        {
                            cell.Value = null;
                            e.Value = null; 
                        }
                    }
                }
            }

        }

        private void SetupBookGrid()
        {
            BookGrid.Columns.Clear();
            BookGrid.AutoGenerateColumns = false;
            BookGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BookGrid.ReadOnly = true;
            BookGrid.EditMode = DataGridViewEditMode.EditOnEnter; 

            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                DataPropertyName = "BookId",
                //ReadOnly = true
            });
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Title",
                DataPropertyName = "Name",
                //ReadOnly = true
            });
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Author",
                HeaderText = "Author",
                DataPropertyName = "AuthorName",
                //ReadOnly = true
            });
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AmountInLibrary",
                HeaderText = "Amount In The Library",
                DataPropertyName = "AmountInLibrary",
                //ReadOnly = true
            });
            BookGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmountInLibrary",
                HeaderText = "Total Amount In The Library",
                DataPropertyName = "TotalAmountInLibrary",
                //ReadOnly = true
            });

            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn
            {
                Name = "TakenBy",
                HeaderText = "Taken By",
                DisplayMember = "Name",
                ValueMember = "Name",
                ReadOnly = false
            };
            BookGrid.Columns.Add(comboColumn);

            BookGrid.DataSource = BookService.LoadBooks();

            BookGrid.CellFormatting += BookGrid_CellFormatting;

            PropertyInfo gridProp = typeof(DataGridView).GetProperty("DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance);
            gridProp.SetValue(BookGrid, true, null);

            BookGrid.Invalidate();
        }

        private void LibraryForAdmins_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            BookGrid.Invalidate();
            BookGrid.Refresh();
        }
    }
}
