using LibraryApi.Data;
using LibraryApi.Models;
using LibraryErrorLogs;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Services
{

    public class BookService
    {
        private static List<Book> bookList;
        private readonly LibraryContext _context;
        private readonly static ILoggerService _logger = new LoggerService("BookServiceBackEnd");
        public BookService()
        {

        }


        public static async Task<List<Book>> GetBooks(LibraryContext _context)
        {
            return bookList = await _context.Books.ToListAsync();
        }

        public static async Task<bool> IsBookUnavialabe(string bookName, int authorId, LibraryContext _context)
        {
            return await _context.Books.AnyAsync(book => book.Name == bookName && book.AuthorId == authorId && book.AmountInLibrary == 0);
        }

        public static async Task<bool> IsBookInLibrary(string bookName, int authorId, LibraryContext _context)
        {
            return await _context.Books.AnyAsync(b => b.Name == bookName && b.AuthorId == authorId);
        }
        public static async Task<bool> AddNewBook(Book book, LibraryContext _context)
        {
            try
            {
                Author author = await AuthorService.GetAuthorById(book.AuthorId, _context);

                if (!await IsBookInLibrary(book.Name, book.AuthorId, _context) && await AuthorService.DoesAuthorExists(author.Name, _context))
                {
                    book.BookId = 0;
                    book.AmountInLibrary = 1;
                    book.TotalAmountInLibrary = 1;
                    await _context.Books.AddAsync(book);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else if (await IsBookInLibrary(book.Name, book.AuthorId, _context))
                {
                    book = await GetBookByName(book.Name, book.AuthorId, _context);
                    book.TotalAmountInLibrary += 1;
                    book.AmountInLibrary += 1;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { await _logger.LogError(ex, $"{ex.Message}"); return false; }



        }

        public async static Task<bool> RemoveBook(int bookId, LibraryContext _context)
        {
            try
            {
                var book = await GetBook(bookId, _context);
                if (book.AmountInLibrary > 0 && book.TotalAmountInLibrary > 0)
                {
                    book.TotalAmountInLibrary -= 1;
                    book.AmountInLibrary -= 1;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex) { await _logger.LogError(ex, ex.Message); return false; }
        }

        public static async Task<bool> RemoveBookByRoot(int bookId, LibraryContext _context)
        {
            var book = await GetBook(bookId, _context);
            try
            {

                _context.Books.Remove(book);
                await CheckoutService.RemoveBookCheckoutsByBookId(bookId, _context);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _logger.LogError(ex, $"Error removing book: {ex.Message}");
                return false;
            }
        }
        public static async Task<Book> GetBook(int bookId, LibraryContext _context)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
        }

        public static async Task<Book> GetSpesificBook(int bookId, int authorId, LibraryContext _context)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId && b.AuthorId == authorId);
        }
        public static async Task<Book> GetBookByName(string bookName, int authorId, LibraryContext _context)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Name == bookName && b.AuthorId == authorId);
        }
        public static async Task<double> ReturnBook(int bookId, int customerId, LibraryContext _context)
        {
            try
            {
                var book = await GetBook(bookId, _context);

                if ((book.AmountInLibrary != book.TotalAmountInLibrary) && await CheckoutService.CustomerHasCheckouts(bookId, customerId, _context))
                {
                    var checkout = await CheckoutService.GetCheckoutWithBookAndCustomer(bookId, customerId, _context);
                    var needsPayment = CheckoutService.PayFine(checkout);

                    if (needsPayment <= 0.0)
                    {
                        await CheckoutService.BookReturn(bookId, customerId, _context);
                        await _context.SaveChangesAsync();
                        return 0.0;
                    }
                    return Math.Round(needsPayment);
                }
                else { return 0.0; }
            }
            catch (Exception ex) { await _logger.LogError(ex, ex.Message); return 0.0; }
        }

        public static async Task<bool> TakeBookOut(int bookId, int customerId, LibraryContext _context)
        {
            try
            {
                var book = await GetBook(bookId, _context);
                var customer = await CustomerService.GetCustomerById(customerId, _context);

                if (book.AmountInLibrary != 0 && !await CheckoutService.CustomerHasCheckouts(bookId, customerId, _context))
                {

                    if (await CheckoutService.CreateCheckout(book.BookId, customerId, _context))
                    {
                        book.AmountInLibrary--;
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }

            }
            catch (Exception ex) { await _logger.LogError(ex, ex.Message); return false; }
        }

        public static async Task<bool> EditBook(int bookId, string bookNewName, int authorId, LibraryContext _context)
        {
            var book = await GetBook(bookId, _context);
            try
            {
                if (await IsBookInLibrary(bookNewName, authorId, _context) && (bookNewName != book.Name && authorId != book.AuthorId))
                {
                    await RemoveBookByRoot(bookId, _context);
                    var newBook = await GetBookByName(bookNewName, authorId, _context);
                    newBook.AmountInLibrary += 1;
                    newBook.TotalAmountInLibrary += 1;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    book.Name = bookNewName;
                    book.AuthorId = authorId;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { await _logger.LogError(ex, ex.Message); Console.WriteLine("EDITING ENDED"); ; return false; }
        }
        public static async Task<double> PayFine(int bookId, int customerId, LibraryContext _context)
        {
            try
            {
                var book = await GetBook(bookId, _context);

                if ((book.AmountInLibrary != book.TotalAmountInLibrary) && await CheckoutService.CustomerHasCheckouts(bookId, customerId, _context))
                {
                    var checkout = await CheckoutService.GetCheckoutWithBookAndCustomer(bookId, customerId, _context);
                    await CheckoutService.BookReturn(bookId, customerId, _context);
                    await _context.SaveChangesAsync();
                    return 0.0;
                }
                else { return 0.0; }
            }
            catch (Exception ex) { await _logger.LogError(ex,ex.Message); return 0.0; }
        }
    }
}
