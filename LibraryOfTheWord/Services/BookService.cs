using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LibraryOfClasses.Classes;
using LibraryOfClasses.VeiwModes;

namespace LibraryOfTheWorld.Services
{

    public class BookService
    {
        private static List<Book> bookList;
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5160") };

        static BookService()
        {

        }




        public static async Task<List<Book>> LoadBooks()
        {
            try
            {
                var endpoint = $"/api/books";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                bookList = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return bookList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Authors from API: {ex.Message}");
                return new List<Book>();
            }
        }



        public static async Task<bool> IsBookInLibrary(string bookName, int authorId)
        {
            var endpoint = $"/api/books/bookcheck/{bookName}/{authorId}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<bool>(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking existence: {ex.Message}");
                return false;
            }
        }
        public static async Task<bool> AddBook(string bookName, int authorId)
        {
            var endpoint = $"/api/books/";
            Book book = new Book(bookName, authorId);
            try
            {
                string jsonBook = JsonSerializer.Serialize(book, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                });
                var content = new StringContent(jsonBook, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                if (response.IsSuccessStatusCode)
                {
                    NotificationService.ShowMessage("AddedTheBook");
                    return true;
                }
                else { NotificationService.ShowMessage("no bueno"); return false; }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error posting Authors to API: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> RemoveBook(int bookId)
        {
            var endpoint = $"api/books/removeonebook/{bookId}";
            try
            {
                HttpResponseMessage response = await client.PatchAsync(endpoint, null);
                response.EnsureSuccessStatusCode();
                NotificationService.ShowMessage($"{await response.Content.ReadAsStringAsync()}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
                return false;
            }
        }
        public static async Task<bool> RemoveBookByRoot(int bookId)
        {
            var endpoint = $"api/books/deletebook/{bookId}";
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
                NotificationService.ShowMessage($"{await response.Content.ReadAsStringAsync()}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> ReturnBook(int bookId, int customerId)
        {
            var endpoint = $"api/books/returnbook/{bookId}/{customerId}";
            try
            {
                HttpResponseMessage response = await client.PatchAsync(endpoint, null);
                if (response.IsSuccessStatusCode)
                {

                    NotificationService.ShowMessage($"{await response.Content.ReadAsStringAsync()}");
                    return true;
                }
                else { NotificationService.ShowMessage($"{await response.Content.ReadAsStringAsync()}"); return false; }
            }
            catch (Exception ex)
            {

                NotificationService.ShowMessage($"Error {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> TakeBookOutAsync(int bookId, int customerId)
        {

            var endpoint = $"api/books/takebookout/{bookId}/{customerId}";
            try
            {
                HttpResponseMessage response = await client.PatchAsync(endpoint, null);
                if (response.IsSuccessStatusCode)
                {

                    NotificationService.ShowMessage($"{await response.Content.ReadAsStringAsync()}");
                    return true;
                }
                else { NotificationService.ShowMessage($"{await response.Content.ReadAsStringAsync()}"); return false; }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting book: {ex.Message}");
                NotificationService.ShowMessage($"Error {ex.Message}");
                return false;
            }
        }

        public static async Task<Book> GetBookById(int bookId)
        {
            var endpoint = $"api/books/getbook/{bookId}/";
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                Book book = JsonSerializer.Deserialize<Book>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
                return null;
            }

        }

        public static async Task<bool> EditBook(int bookId, string bookNewName, int authorId)
        {
            var endpoint = $"api/books/editbook/{bookId}/{bookNewName}/{authorId}";
            try
            {
                HttpResponseMessage response = await client.PatchAsync(endpoint, null);
                response.EnsureSuccessStatusCode();
                return true;

            }
            catch (Exception ex) { Console.WriteLine($"Error editing book: {ex.Message}"); return false; }
        }

        public static async Task<List<BookViewModel>> LoadBooksWithAuthorsAsync()
        {
            var books = await LoadBooks();
            var viewModels = new List<BookViewModel>();

            foreach (var book in books)
            {
                string authorName = await AuthorService.GetAuthorNameById(book.AuthorId);

                var customers = await CheckoutService.GetCustomersForBook(book.BookId);
                var customerNames = customers.Select(c => c.Name).ToList();
                var customerId = customers.Select(c => c.CustomerId).ToList();

                viewModels.Add(new BookViewModel
                {
                    BookId = book.BookId,
                    Name = book.Name,
                    AuthorId = book.AuthorId,
                    AuthorName = await AuthorService.GetAuthorNameById(book.AuthorId),
                    AmountInLibrary = book.AmountInLibrary,
                    TotalAmountInLibrary = book.TotalAmountInLibrary,
                    TakenByCustomerNames = customerNames,
                    CustomerId = customerId,
                });
            }

            return viewModels;
        }

        public static async Task<bool> PayFine(int bookId, int customerId)
        {
            var endpoint = $"api/books/payfine/{bookId}/{customerId}";
            try
            {
                await ReturnBook(bookId, customerId);
                DialogResult dialog = NotificationService.ShowMessageYesNo("would you like to pay the fine?", "Question");
                if (dialog == DialogResult.Yes)
                {

                    HttpResponseMessage response = await client.PatchAsync(endpoint, null);
                    if (response.IsSuccessStatusCode)
                    {

                        NotificationService.ShowMessage($"{await response.Content.ReadAsStringAsync()}");
                        return true;
                    }
                    else { NotificationService.ShowMessage($"{await response.Content.ReadAsStringAsync()}"); return false; }
                }
                else { return false; }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting book: {ex.Message}");
                NotificationService.ShowMessage($"Error {ex.Message}");
                return false;
            }
        }

    }
}
