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
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.Services;

namespace LibraryOfTheWorld.Forms
{
    public partial class AddBookForm : Form
    {
        

        //private static Book book = new Book("", 0);
        private BookService bookService = new BookService();
     
        public AddBookForm()
        {
            InitializeComponent();
        }

        private static AddBookForm instance;
        public static AddBookForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new AddBookForm();
                return instance;
            }
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("HERE TO DOWN");
            string bookName = BookNameText.Text;
            string authorName = AuthorComboBox.Text;

            if (string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(authorName))
            {
                MessageBox.Show("Book name and or author cannot be empty.");
                return;
            }

            if (!AuthorService.DoesAuthorExists(authorName))
            {
                AuthorService.AddAuthor(authorName);
            }

            Author author = AuthorService.GetAuthorByName(authorName);
            if (author != null)
            {
                Book newBook = new Book(bookName, author.AuthorId);
                bookService.AddBook(newBook);
                LibraryForAdmins.Instance.Activate();
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Error adding author.");
                return;
            }
        }

        private void AddBookForm_Activated(object sender, EventArgs e)
        {
            List<Author> authors = AuthorService.LoadAuthors(); 
            AuthorComboBox.DataSource = null; 
            AuthorComboBox.DataSource = authors;
            AuthorComboBox.DisplayMember = "Name";
        }
    }
}
