using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld.DattaHandlers;
using LibraryOfTheWorld.Interfaces;
using LibraryOfTheWorld.Users;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace LibraryOfTheWorld.Forms
{
    public partial class Library : Form
    {
        private static Book book = new Book("", "", false);
        private JsonUsersDataHandler dataHandler = new JsonUsersDataHandler();
       

        public string CurrentUser;
        
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
            Book.datahandler.LoadDataJson<Book>("Books");
            SignedInAs.Text = CurrentUser;
            BookSelectionComboBox.DataSource = book.LoadBooks();
            BookSelectionComboBox.DisplayMember = "Name";
        }

        private void Library_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BookSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book selectedBook = BookSelectionComboBox.SelectedItem as Book;

            NameOfBook.Text = selectedBook.Name;
            AuthorOfBook.Text = selectedBook.Author;
            TakenOrNot.Text = $"{selectedBook.isTaken}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameOfBook_Click(object sender, EventArgs e)
        {

        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            Book selectedBook = BookSelectionComboBox.SelectedItem as Book;
            book.ReturnBook(selectedBook);

        }

        private void AddBook_Click(object sender, EventArgs e)
        {
            AddBookForm.Instance.Show();
            AddBookForm.Instance.Location = this.Location;
        }

        private void SignedInAs_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BookSelectionComboBox_Click(object sender, EventArgs e)
        {

        }

        private void TakeBookOut_Click(object sender, EventArgs e)
        {
            Book selectedBook = BookSelectionComboBox.SelectedItem as Book;
            if (selectedBook.isTaken == true)
            {
                MessageBox.Show("book is not in ");
            }
            else
            {
                selectedBook.isTaken = true;
                book.saveBooks();
            }
            this.Update();
        }

        private void Library_Activated(object sender, EventArgs e)
        {

        }
    }
}
