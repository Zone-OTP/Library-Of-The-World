using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.Services;

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
        public static LibraryForCustomers Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new LibraryForCustomers();
                return instance;
            }
        }
       
        private void LibraryForCustomers_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            SignedInAs.Text = currentUser.Name;
            BookGrid.DataSource = BookService.LoadBooks();
            BookGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BookGrid.ReadOnly = true;
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

        private void TakeBookOut_Click(object sender, EventArgs e)
        {
            Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
            CustomerService.TakeBookOut(selectedBook,currentUser.LibraryCardNumber);
            BookGrid.DataSource = null;
            BookGrid.DataSource = BookService.LoadBooks();
            BookGrid.Refresh();
        }

        private void ReturnBook_Click(object sender, EventArgs e)
        {
            Book selectedBook = (Book)BookGrid.SelectedRows[0].DataBoundItem;
            CustomerService.ReturnBook(selectedBook,currentUser.LibraryCardNumber);
            BookGrid.DataSource = null;
            BookGrid.DataSource = BookService.LoadBooks();
            BookGrid.Refresh();
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

        private void SignedInAs_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Name: {currentUser.Name}\n Library Card:{currentUser.LibraryCardNumber}");
        }
    }
}
