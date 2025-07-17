using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Themes;


namespace LibraryOfTheWorld.Forms
{
    public partial class AddBookForm : Form
    {

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

        private async void button2_Click(object sender, EventArgs e)
        {
            string bookName = BookNameText.Text;
            string authorName = AuthorComboBox.Text;

            if (string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(authorName))
            {
                NotificationService.ShowMessage("Book name and or author cannot be empty.");
                return;
            }

            if (!await AuthorService.DoesAuthorExists(authorName))
            {
                await AuthorService.AddAuthor(authorName);
            }

            Author author = await AuthorService.GetAuthorByName(authorName);


            if (await BookService.AddBook(bookName, author.AuthorId))
            {
                LibraryForAdmins.Instance.Activate();
                this.Close();
                return;
            }
        }

        private async void AddBookForm_Activated(object sender, EventArgs e)
        {
            List<Author> authors = await AuthorService.LoadAuthors();
            AuthorComboBox.DataSource = null;
            AuthorComboBox.DataSource = authors;
            AuthorComboBox.DisplayMember = "Name";
        }
    }
}
