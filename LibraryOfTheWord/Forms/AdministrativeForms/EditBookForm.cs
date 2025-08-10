using LibraryOfClasses.Classes;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;
using LibraryOfClasses.VeiwModes;
using LibraryErrorLogs;

namespace LibraryOfTheWorld.Forms
{
    public partial class EditBookForm : Form
    {
        private BookViewModel _book;
        private Author _author;
        private readonly ILoggerService _logger;
        public EditBookForm()
        {
            InitializeComponent();
        }
        internal EditBookForm(BookViewModel book)
        {
            InitializeComponent();
            _book = book;
            _logger = new LoggerService("EditBookForm");
            BookTitleTextBox.Text = _book.Name;
            
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            var pervAuthId = _book.AuthorId;
            if (!await AuthorService.DoesAuthorExists(AuthorEditComboBox.Text))
            {
                var author = await AuthorService.AddAuthor(AuthorEditComboBox.Text);
                _book.AuthorId = author.AuthorId;
            }

            if (string.IsNullOrEmpty(BookTitleTextBox.Text))
            {
                return;
            }
            _author = await AuthorService.GetAuthorByName(AuthorEditComboBox.Text);
            if (await BookService.EditBook(_book.BookId, BookTitleTextBox.Text, _author.AuthorId))
            {
                await _logger.LogInformation($"A book was Edited From{_book.Name} to {BookTitleTextBox.Text}, and {pervAuthId} to {_author.AuthorId}");
                this.Close();
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void EditBookForm_Activated(object sender, EventArgs e)
        {
            List<Author> authors = await AuthorService.LoadAuthors();
            AuthorEditComboBox.DataSource = null;
            AuthorEditComboBox.DataSource = authors;
            AuthorEditComboBox.DisplayMember = "Name";
        }

        private async void EditBookForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            _author = await AuthorService.GetAuthorById(_book.AuthorId);
            if (_author != null)
            {
                AuthorEditComboBox.Invoke(() => AuthorEditComboBox.Text = _author.Name);
            }
            else
            {
                NotificationService.ShowMessage("Author not found.");
            }
        }

        private void EditBookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
