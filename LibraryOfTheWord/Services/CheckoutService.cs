using System.Text.Json;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.DattaHandlers;

namespace LibraryOfTheWorld.Services
{
    public static class CheckoutService
    {
        private static List<BookCheckout> checkoutList;
        private static readonly DataHandler dataHandler = new DataHandler();
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5160") };

        public static void RemoveCheckOut(int checkoutId)
        {
            dataHandler.RemoveFromDatabase<BookCheckout>(checkoutId);

        }


        public static double CheckDateAndSetPayment(int customerId, int bookId)
        {
            var checkouts = dataHandler.LoadFromDatabase<BookCheckout>();

            foreach (var checkout in checkouts)
            {
                if (checkout.CustomerId == customerId && checkout.BookId == bookId && checkout.CheckoutDate.Month != DateTime.Now.Month)
                {

                    var timePassed = checkout.CheckoutDate.Subtract(DateTime.Now).Days / ((365.25 / 12));

                    if (timePassed > 0.9)
                    {
                        return timePassed;
                    }

                }
            }
            return 0;
        }

        public static async Task<List<BookCheckout>> LoadCheckouts()
        {
            try
            {
                var endpoint = $"/api/bookcheckouts";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                checkoutList = JsonSerializer.Deserialize<List<BookCheckout>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return checkoutList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Authors from API: {ex.Message}");
                return new List<BookCheckout>();
            }
        }

        public static async Task<List<Customer>> LoadCustomersWithBooksAsync()
        {
            var customers = await CustomerService.LoadCustmers();
            var books = await BookService.LoadBooks();
            var checkouts = await LoadCheckouts();

            var bookLookup = books.ToDictionary(b => b.BookId);

            foreach (var customer in customers)
            {
                var customerCheckouts = checkouts
                    .Where(c => c.CustomerId == customer.CustomerId)
                    .ToList();

                customer.BookCheckouts = customerCheckouts;

                foreach (var checkout in customer.BookCheckouts)
                {
                    if (bookLookup.TryGetValue(checkout.BookId, out Book book))
                    {
                        checkout.Book = book;
                    }
                }
            }

            return customers;
        }

        public static async Task<List<Customer>> GetCustomersForBook(int bookId)
        {
            var customers = await LoadCustomersWithBooksAsync();
            return customers
                .Where(c => c.BookCheckouts.Any(bc => bc.BookId == bookId))
                .ToList();
        }


    }
}

