using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class CustomerService
    {
        private static List<Customer> customerList;
        private static Random random = new Random();
        private readonly LibraryContext _context;


        public static async Task<List<Customer>> GetCustomers(LibraryContext _context)
        {
            return await _context.Customers.ToListAsync();
        }
        public static async Task<Customer> GetCustomerById(int customerId, LibraryContext _context)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public static async Task<Customer> GetCustomerByName(string customerName, LibraryContext _context)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Name == customerName);
        }

        public static async Task<bool> CheckCustomerData(Customer customer, LibraryContext _context)
        {
            var custcheck = await _context.Customers.AnyAsync(c => c.Name == customer.Name);
            var custcheck2 = await _context.Customers.AnyAsync(c => c.PersonalGovermentId == customer.PersonalGovermentId);
            var custcheck3 = await _context.Customers.AnyAsync(c => c.Email == customer.Email);
            if (custcheck || custcheck2 || custcheck3) { return true; } else { return false; }
        }

        public static async Task<bool> AddCustomer(Customer customer, LibraryContext _context)
        {
            try
            {
                if (await CheckCustomerData(customer, _context)) { return false; }
                customer.LibraryCardNumber = await GenerateUniqueLibraryCardNumber(_context);
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                MailingService.SendMailPostRegistration(customer.Email, customer.Name);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }
        //corw rjzi umka logq

        public static async Task<int> GenerateUniqueLibraryCardNumber(LibraryContext _context)
        {
            while (true)
            {
                int number = random.Next(1, 100000000);
                bool exists = await _context.Customers.AnyAsync(c => c.LibraryCardNumber == number);
                if (!exists)
                {
                    return number;
                }
            }
        }


        public static async Task<bool> RemoveCustomer(int customerId, LibraryContext _context)
        {
            try
            {
                var customerToRemove = await GetCustomerById(customerId, _context);
                if (customerToRemove != null)
                {
                    if (await CheckoutService.CustomerCheckout(customerId, _context))
                    {

                        return false;
                    }

                    _context.Customers.Remove(customerToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }

        public static async Task<Customer> GetCustmoerByLibraryCard(int libraryCardNumber, LibraryContext _context)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.LibraryCardNumber == libraryCardNumber);
        }


        public static async Task<bool> ValidateLoginAsync(Customer cust, LibraryContext _context)
        {
            try
            {
                var customer = await GetCustomerByName(cust.Name, _context);
                if (await _context.Customers.AnyAsync(c => c.Name == customer.Name && c.Password == customer.Password))
                {
                    MailingService.SendMailPostSginIn(customer.Email, customer.Name);
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }

        }


    }
}
