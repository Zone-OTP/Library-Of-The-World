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


namespace LibraryOfTheWorld.Forms
{
    public partial class Library : Form
    {

        private static Book book = new Book("", 0, false);
       
        private JsonUsersDataHandler dataHandler = new JsonUsersDataHandler();
        
        public string currentUser;
        
        public Library()
        {
            InitializeComponent();
        }
        private static Library instance;
        public static Library Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new Library();
                return instance;
            }
        }
        private void Library_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            SignedInAs.Text = currentUser;
            BookGrid.DataSource = book.LoadBooks();
            BookGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BookGrid.Columns["AuthorId"].Visible = false;
            BookGrid.ReadOnly = true;
        }

        private void Library_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
            if (!selectedBook.IsTaken) {
                MessageBox.Show("book is not taken, how are you returning it?");
                return;
            }
            book.ReturnBook(selectedBook,currentUser);
            book.saveBooks();
            BookGrid.DataSource = book.LoadBooks();
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

            foreach (var book in book.LoadBooks())
            {
                totalBooks++;
                if (book.IsTaken == true) { booksTaken++; }
                if (book.IsTaken == false) { booksAvailable++; }
            }

            TotalBooksLable.Text = $"{totalBooks}";
            BooksTakenOutLabel.Text = $"{booksTaken}";
            BooksAvalablelabel.Text = $"{booksAvailable}";
        }

        private void TakeBookOut_Click(object sender, EventArgs e)
        {
            
            Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
            if (BookGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book first!");
                return;
            }
            if (selectedBook.IsTaken)
            {
                MessageBox.Show("Book is already taken out!");
                return;
            }
            selectedBook.TakenByUser = currentUser;
            selectedBook.IsTaken = true;
            book.saveBooks();
            BookGrid.DataSource = book.LoadBooks();
            UpdateBookCounts();
            BookGrid.Refresh();
            

        }

        private void Library_Activated(object sender, EventArgs e)
        {
            BookGrid.DataSource = book.LoadBooks();
            book.saveBooks();
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
                AuthorOfBook.Text = Author.GetAuthorNameById(selectedBook.AuthorId);
                if (selectedBook.IsTaken)
                {
                    TakenOrNot.Text = $"Taken/Not Available";
                }
                else if (!selectedBook.IsTaken) { TakenOrNot.Text = $"Available"; }
            }
            
        }

        private void BookGrid_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            book.saveBooks();

        }

        private void BookGrid_Enter(object sender, EventArgs e)
        {
            BookGrid.DataSource = book.LoadBooks();

        }

        private void EditBookButton_Click(object sender, EventArgs e)
        {
            if (BookGrid.SelectedRows.Count > 0) 
            {
                
                Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
                
                EditBookForm editForm = new EditBookForm(selectedBook);
                editForm.ShowDialog(); 

                BookGrid.DataSource = null;         
                BookGrid.DataSource = book.LoadBooks(); 
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
    }
}
