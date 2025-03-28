using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.DBData;
using LibraryOfTheWorld.Services;

namespace LibraryOfTheWorld.Forms
{
    public partial class EditBookForm : Form
    {
        private Book _book;
        private Author _author;
        public EditBookForm()
        {
            InitializeComponent();
        }
        internal EditBookForm(Book book)
        {
            InitializeComponent();
            _book = book;
            BookTitleTextBox.Text = _book.Name;
            _author = AuthorService.GetAuthorByName(book.AuthorName);
            AuthorEditComboBox.Text = _author.Name;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BookTitleTextBox.Text))
            {
                MessageBox.Show("Title cannot be empty!");
                return;
            }
            if (!BookService.IsBookInLibrary(BookTitleTextBox.Text))
            {
                _book.Name = BookTitleTextBox.Text;
            }
            else 
            {
                _book.TotalAmountInLibrary += 1;
                _book.AmountInLibrary += 1;
                BookService.SaveBooks();
                this.Close();
                return; 
            }
            if (!AuthorService.DoesAuthorExists(_author.Name))
            {
                AuthorService.AddAuthor(AuthorEditComboBox.Text);
                _book.AuthorId = AuthorService.GetAuthorIdByName(AuthorEditComboBox.Text);
                Console.WriteLine(_book.AuthorId);
            }
            else
            {
                _book.AuthorId = AuthorService.GetAuthorIdByName(AuthorEditComboBox.Text);
            }


            BookService.SaveBooks();
            MessageBox.Show("Book updated successfully!");
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditBookForm_Activated(object sender, EventArgs e)
        {
            List<Author> authors = AuthorService.LoadAuthors(); 
            AuthorEditComboBox.DataSource = null; 
            AuthorEditComboBox.DataSource = authors;
            AuthorEditComboBox.DisplayMember = "Name";
        }

        private void EditBookForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
        }
    }
}
