using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.DattaHandlers;

namespace LibraryOfTheWorld.Services
{

    public class BookService
    {
        private static List<Book> bookList;
        private static JsonUsersDataHandler dataHandler;
        public static int _nextId = 1;
        static BookService()
        {
            dataHandler = new JsonUsersDataHandler();
            bookList = dataHandler.LoadDataJson<Book>("Books");
        }

        internal List<Book> GetAllBooks()
        {
            return bookList;
        }

        public static List<Book> LoadBooks()
        {
            bookList = dataHandler.LoadDataJson<Book>("Books");
            return bookList;
        }
        public static void SaveBooks()
        {
            dataHandler.SaveDataJson(bookList, "Books");
        }
        public static bool IsBookTaken(string bookName, int authorId)
        {
            return bookList.Any(book => book.Name == bookName && book.AuthorId == authorId && book.AmountInLibrary == 0);
        }
        
        public static bool IsBookInLibrary(string bookName)
        {
            return bookList.Any(book => book.Name == bookName);
        }
        public void AddBook(Book book)
        {
            bookList = dataHandler.LoadDataJson<Book>("Books");
            if (IsBookInLibrary(book.Name) && AuthorService.DoesAuthorExists(book.AuthorName))
            {
                book = GetBookByName(book.Name);
                book.AmountInLibrary += 1;
                book.TotalAmountInLibrary += 1;
                SaveBooks();
                return;
            }
            book.AmountInLibrary = 1;
            book.TotalAmountInLibrary = 1;
            bookList.Add(book);
            dataHandler.SaveDataJson(bookList, "Books");
        }

        public static void RemoveBook(Book book)
        {
            if (book.AmountInLibrary > 0 && book.TotalAmountInLibrary > 0)
            {
                book = GetBookByName(book.Name);
                book.TotalAmountInLibrary -= 1;
                book.AmountInLibrary -= 1;
                dataHandler.SaveDataJson(bookList, "Books");
                return;
            }
            else if (book.AmountInLibrary == 0)
            {
                MessageBox.Show("this book is not within the library it can't be removed\n" +
                    "if you want it to be removed Forever, you can remove the Root The 'REMOVE BY ROOT' button");
            }
        }
        public static void RemoveBookByRoot(Book book) {
            if (book == null)
            {
                MessageBox.Show("No book selected to remove.");
                return;
            }
            

            DialogResult result = MessageBox.Show(
                "Are you sure you want to remove this book?\nIt will be deleted permanently",
                "Confirmation",
                MessageBoxButtons.YesNo
            );
            var bookToRemove = bookList.FirstOrDefault(b => b.BookId == book.BookId);

            if (result == DialogResult.Yes)
            {
                if (bookList.Contains(bookToRemove))
                {
                    bookList.Remove(bookToRemove);
                    try
                    {
                        dataHandler.SaveDataJson(bookList, "Books");
                        MessageBox.Show("Book removed successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving book list: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Book not found in the library.");
                }
            }
        }
        public static Book GetBookByName(string bookName)
        {
            bookList = dataHandler.LoadDataJson<Book>("Books");
            return bookList.FirstOrDefault(a => a.Name.Equals(bookName, StringComparison.OrdinalIgnoreCase));
        }
        public static void ReturnBook(Book book)
        {
            if (book.AmountInLibrary != book.TotalAmountInLibrary)
            {
                var ChosenBook = bookList.FirstOrDefault(b => b.Name == book.Name && b.AuthorId == book.AuthorId);
                if (ChosenBook != null)
                {
                    ChosenBook.AmountInLibrary++;
                    SaveBooks();
                    MessageBox.Show("you've returned the book");
                    return;
                }
                else { MessageBox.Show("we have the book, you can't return it"); }
            }
            else { MessageBox.Show("Unable to take book, you can't return something you never borrowed"); }
        }

        public static void TakeBookOut(Book book)
        {

            if (!IsBookTaken(book.Name, book.AuthorId))
            {
                var ChosenBook = bookList.FirstOrDefault(b => b.Name == book.Name && b.AuthorId == book.AuthorId && b.BookId == book.BookId);
                    ChosenBook.AmountInLibrary--;
                    SaveBooks();
                    MessageBox.Show($"you've Taken the boook {book.Name}");
                    return;
                    
                    
            }
            else { MessageBox.Show("This Book is not in the Library"); }

        }
    }
}
