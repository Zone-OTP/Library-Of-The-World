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

namespace LibraryOfTheWorld.Forms
{
    public partial class AddBookForm : Form
    {
        

        private static Book book = new Book("", 0,false);
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
            string bookName = BookNameText.Text;
            string authorName = AuthorComboBox.Text;

            if (string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(authorName))
            {
                MessageBox.Show("Book name and or author cannot be empty.");
                return;
            }

            if (!Author.IsAuthorExists(authorName))
            {
                Author.AddAuthor(authorName);
            }

            Author author = Author.GetAuthorByName(authorName);
            if (author != null)
            {
                Book newBook = new Book(bookName, author.Id, false);
                book.AddBook(newBook);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error adding author.");
                return;
            }

            Library.Instance.Activate();
            this.Close();
        }

        private void AddBookForm_Activated(object sender, EventArgs e)
        {
            List<Author> authors = Author.LoadAuthors(); 
            AuthorComboBox.DataSource = null; 
            AuthorComboBox.DataSource = authors;
            AuthorComboBox.DisplayMember = "Name";
        }
    }
}
