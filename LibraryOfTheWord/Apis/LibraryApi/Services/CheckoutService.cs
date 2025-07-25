using LibraryApi.Data;
using LibraryApi.Models;
using LibraryErrorLogs;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Services
{
    public class CheckoutService
    {
        private readonly LibraryContext _context;
        private readonly static ILoggerService _logger = new LoggerService("CheckoutServiceBackEnd");

        //get
        public static async Task<List<BookCheckout>> GetCheckouts(LibraryContext _context)
        {

            return await _context.BookCheckouts.ToListAsync();

        }


        //post
        public static async Task<bool> CreateCheckout(int bookId, int customerId, LibraryContext _context)
        {
            try
            {
                var checkout = new BookCheckout();
                checkout.BookId = bookId;
                checkout.CustomerId = customerId;
                checkout.CheckoutDate = DateTime.Now;
                await _context.BookCheckouts.AddAsync(checkout);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex) { await _logger.LogError(ex, ex.Message); return false; }

        }


        //delete
        public static async Task<bool> RemoveCheckOut(int checkoutId, LibraryContext _context)
        {
            try
            {
                var checkout = await GetCheckout(checkoutId, _context);
                if (checkout != null)
                {
                    _context.BookCheckouts.Remove(checkout);
                    _context.SaveChangesAsync();
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { await _logger.LogError(ex, $"Error removing checkout : {ex.Message}"); return false; }
        }

        public static async Task RemoveBookCheckoutsByBookId(int bookId, LibraryContext _context)
        {
            var checkoutsToRemove = _context.BookCheckouts
                .Where(bc => bc.BookId == bookId);

            _context.BookCheckouts.RemoveRange(checkoutsToRemove);

            await _context.SaveChangesAsync();
        }



        //functions 
        public async static Task<BookCheckout> GetCheckout(int checkoutId, LibraryContext _context)
        {
            return await _context.BookCheckouts.FirstOrDefaultAsync(b => b.BookCheckoutId == checkoutId);
        }

        public static async Task<bool> BookReturn(int bookId, int customerId, LibraryContext _context)
        {
            var book = await BookService.GetBook(bookId, _context);
            var checkoutsToRemove = _context.BookCheckouts
                .Where(bc => bc.BookId == bookId && bc.CustomerId == customerId);
            PayFine(checkoutsToRemove.First());
            book.AmountInLibrary += 1;
            _context.BookCheckouts.RemoveRange(checkoutsToRemove);

            await _context.SaveChangesAsync();
            return true;
        }

        public static async Task<bool> CustomerCheckout(int customerId, LibraryContext _context)
        {

            return await _context.BookCheckouts.AnyAsync(bc => bc.CustomerId == customerId);
        }

        public static async Task<bool> CustomerHasCheckouts(int bookId, int customerId, LibraryContext _context)
        {

            return await _context.BookCheckouts.AnyAsync(bc => bc.CustomerId == customerId && bc.BookId == bookId);
        }

        public static double PayFine(BookCheckout checkout)
        {
            var timePassed = (checkout.CheckoutDate.Subtract(DateTime.Now).Days / ((365.25 / 12))) * -1.0;

            if (timePassed > 0.9)
            {
                return timePassed * 0.5;
            }
            return 0;
        }
        public static async Task<BookCheckout> GetCheckoutWithBookAndCustomer(int bookId, int customerId, LibraryContext _context)
        {
            return await _context.BookCheckouts
                .FirstOrDefaultAsync(bc => bc.BookId == bookId && bc.CustomerId == customerId);
        }

        //public static double CheckDateAndSetPayment(int customerId, int bookId)
        //{
        //    var checkouts = dataHandler.LoadFromDatabase<BookCheckout>();

        //    foreach (var checkout in checkouts)
        //    {
        //        if (checkout.CustomerId == customerId && checkout.BookId == bookId && checkout.CheckoutDate.Month != DateTime.Now.Month)
        //        {

        //            var timePassed = checkout.CheckoutDate.Subtract(DateTime.Now).Days / ((365.25 / 12));

        //            if (timePassed > 0.9)
        //            {
        //                return timePassed;
        //            }

        //        }
        //    }
        //    return 0;
        //}




    }
}

