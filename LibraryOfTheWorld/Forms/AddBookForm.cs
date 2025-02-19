using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryOfTheWorld.Forms
{
    public partial class AddBookForm : Form
    {
        private static Book book = new Book("", "",false);
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            book.AddBook(new Book(BookNameText.Text,BookAuthorText.Text,false));
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBookForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
