using System.Text;
using System.Text.Json;
using LibraryErrorLogs;
using LibraryOfClasses.Classes;
using LibraryOfTheWorld.Services;

namespace LibraryOfTheWorld.Services
{
    public class CustomerService
    {
        private static List<Customer> customerList;
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5160") };
        private readonly static ILoggerService _logger = new LoggerService("CustomerServiceFrontEnd");
        static CustomerService()
        {

        }

        public static async Task<Customer> GetCustomerByNameAsync(string name)
        {
            var endpoint = $"/api/customers/spesificcustomerget/0/{name}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                Customer customer = JsonSerializer.Deserialize<Customer>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return customer;
            }
            catch (Exception ex)
            {
                await _logger.LogError(ex, $"Error {ex.Message}");
                return null;
            }
        }

        public static async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var endpoint = $"/api/customers/spesificcustomerget/{customerId}/empty";
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                Customer customer = JsonSerializer.Deserialize<Customer>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
                return null;
            }
        }
        public static async Task<bool> ValidateLoginAsync(string name, string password)
        {

            string endpoint = $"/api/customers/Validate";
            try
            {
                Customer customer = new Customer(name, password, "000000000", "empty");
                string jsonCustomer = JsonSerializer.Serialize(customer);
                var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static async Task<Customer> AddCustomer(string name, string password, string govermentId, string email)
        {
            var endpoint = $"/api/customers";
            Customer customer = new Customer(name, password, govermentId, email);
            try
            {
                string jsonCustomer = JsonSerializer.Serialize(customer);
                var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                if (response.IsSuccessStatusCode)
                {
                    NotificationService.ShowMessage(await response.Content.ReadAsStringAsync());
                    string responseJson = await response.Content.ReadAsStringAsync();
                    Customer createdEntity = JsonSerializer.Deserialize<Customer>(responseJson,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
                    return createdEntity;
                }
                else {throw new Exception("no Customer Could be created"); }
            }
            catch (Exception ex)
            {
                await _logger.LogError(ex,$"Error posting Customers to API: {ex.Message}");
                return null;
            }

        }

        public static async Task PayFineAsync(int bookId, int customerId)
        {
            var book = await BookService.GetBookById(bookId);
            var monthsPassed = await CheckoutService.CheckDateAndSetPayment(customerId, book.BookId);

            if (monthsPassed > 0)
            {
                NotificationService.ShowMessage($"pay {Math.Round(monthsPassed * 1.5)}$ ?", "yes or no?");
                DialogResult dialogResult = (DialogResult)MessageBoxButtons.YesNo;
                if (dialogResult == DialogResult.Yes)
                {
                    await BookService.ReturnBook(book.BookId, customerId);
                }
                else if (dialogResult == DialogResult.No)
                {
                    NotificationService.ShowMessage("okay, you're not returning the book i guess");
                    return;
                }
            }



        }

        public static async Task<List<Customer>> LoadCustmers()
        {
            try
            {
                var endpoint = $"/api/customers";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                customerList = JsonSerializer.Deserialize<List<Customer>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return customerList;
            }
            catch (Exception ex)
            {
                await _logger.LogError(ex, $"Error fetching Authors from API: {ex.Message}");
                return new List<Customer>();
            }
        }

        public static async Task<string> GetCustomerName(int customerId)
        {
            var customer = await GetCustomerByIdAsync(customerId);
            return customer.Name;

        }


        public static async Task DeleteCustomer(int customerId)
        {
            try
            {
                var endpoint = $"/api/customers/deletecustomer/{customerId}";
                HttpResponseMessage response = await client.DeleteAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    NotificationService.ShowMessage(await response.Content.ReadAsStringAsync());
                    return;
                }
                else
                {
                    NotificationService.ShowMessage(await response.Content.ReadAsStringAsync());
                    return;
                }
            }
            catch (Exception ex) { await _logger.LogError(ex, $"ERROR AT DELETEING CUSTOMER{ex.Message}"); }
        }
    }
}
