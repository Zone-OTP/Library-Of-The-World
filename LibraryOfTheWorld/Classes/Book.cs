using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LibraryOfTheWorld.DattaHandlers;
using LibraryOfTheWorld.Users;

namespace LibraryOfTheWorld
{
    internal class Book
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsTaken { get; set; }
        public string TakenByUser { get; set; }

        internal static int _nextId = 1;
        internal static JsonUsersDataHandler datahandler = new JsonUsersDataHandler();
        private static List<Book> BookList { get; set; } = new List<Book>();

        public Book(string name, string author,bool istaken)
        {
            Id = _nextId++;
            Name = name;
            Author = author;
            IsTaken = istaken;
            TakenByUser = "empty";
        }
        public List<Book> LoadBooks() {
            BookList = datahandler.LoadDataJson<Book>("Books");
            datahandler.SaveDataJson(BookList, "Books");
            return BookList;
        }
        public void saveBooks() {
            datahandler.SaveDataJson(BookList, "Books");
            BookList = datahandler.LoadDataJson<Book>("Books");
        }
        public bool IsBookTaken(string bookName, string authorName)
        {
            return BookList.Any(book => book.Name == bookName && book.Author == authorName && book.IsTaken);
        }
        public void ReturnBook(Book book,string currentUser)
        {
            if (IsBookTaken(book.Name, book.Author)) {
                var ChosenBook = BookList.FirstOrDefault(b => b.Name == book.Name && b.Author == book.Author);
                if (ChosenBook != null)
                {
                    if (book.TakenByUser == currentUser)
                    {
                        ChosenBook.IsTaken = !ChosenBook.IsTaken;
                        MessageBox.Show("you've returned the book");
                        datahandler.SaveDataJson(BookList, "Books");
                        return;
                    }
                    else { MessageBox.Show("you're not the user that took this book,can't return it"); }
                 }
                 else { MessageBox.Show("we have the book, you can't return it"); }
            }
        }
        private bool IsBookInLibrary(string bookName)
        {
            return BookList.Any(book => book.Name == bookName);
        }
        public void AddBook(Book book)
        {
            BookList = datahandler.LoadDataJson<Book>("Books");
            if (IsBookInLibrary(book.Name))
            {
                MessageBox.Show("Name is taken, choose another Name");
                return;
            }
            BookList.Add(book);
            datahandler.SaveDataJson(BookList, "Books");
        }
    }
}
