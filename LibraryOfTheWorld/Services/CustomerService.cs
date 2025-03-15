using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.DattaHandlers;
using System.Windows.Forms;
using LibraryOfTheWorld.Interfaces;

namespace LibraryOfTheWorld.Services
{
    public class CustomerService
    {
        private static List<Customer> customerList;
        private static JsonUsersDataHandler dataHandler;
        private static Random random = new Random();
        public static int _nextId = 1;

        static CustomerService()
        {
            dataHandler = new JsonUsersDataHandler();
            customerList = dataHandler.LoadDataJson<Customer>("Customers");
        }

        public static List<Customer> GetAllCustomers()
        {
            return customerList;
        }

        public static List<Customer> LoadCustomers()
        {
            customerList = dataHandler.LoadDataJson<Customer>("Customers");
            return customerList;
        }

        public static void AddCustomer(string name, string password, long govId)
        {
            int libraryCardNumber = GenerateUniqueLibraryCardNumber();
            var customer = new Customer(name, password, govId, libraryCardNumber);
            customerList.Add(customer);
            dataHandler.SaveDataJson(customerList, "Customers");
        }

        public static void SaveCustomers() {
            dataHandler.SaveDataJson(customerList, "Customers");
        }

        private static int GenerateUniqueLibraryCardNumber()
        {
            const int minValue = 10000000;
            const int maxValue = 99999999;
            int newCardNumber;

            do
            {
                newCardNumber = random.Next(minValue, maxValue + 1);
            } while (customerList.Any(c => c.LibraryCardNumber == newCardNumber));

            return newCardNumber;
        }

        public void RemoveCustomer(Customer customer)
        {
            var customerToRemove = customerList.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (customerToRemove != null)
            {
                var borrowedBooks = customerToRemove.BooksTaken;

                if (borrowedBooks.Any())
                {
                    MessageBox.Show("Cannot remove customer. They have borrowed books that must be returned first.");
                    return;
                }

                customerList.Remove(customerToRemove);
                dataHandler.SaveDataJson(customerList, "Customers");
                MessageBox.Show("Customer removed successfully.");
            }
            else
            {
                MessageBox.Show("Customer not found.");
            }
        }


        public bool DoesCustomerExistByLibraryCardNumber(int libraryCardNumber)
        {
            return customerList.Any(c => c.LibraryCardNumber.Equals(libraryCardNumber));
        }
        public bool DoesCustomerExistByName(string name)
        {
            return customerList.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static Customer GetCustmoerByLibraryCard(int libraryCardNumber)
        {
            return customerList.FirstOrDefault(c => c.LibraryCardNumber == libraryCardNumber);
        }

        public static Customer GetCustomerById(int id)
        {
            return customerList.FirstOrDefault(c => c.CustomerId == id);
        }

        public static Customer GetCustomerByName(string name)
        {
            Console.WriteLine($"Searching for customer with name: {name}");
            if (customerList == null || !customerList.Any())
            {
                Console.WriteLine("customerList is null or empty.");
                return null;
            }
            var customer = customerList.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (customer == null)
            {
                Console.WriteLine($"No customer found with name: {name}");
            }
            return customer;
        }

        public static bool ValidateLogin(string name, string password)
        {

            var customer = GetCustomerByName(name);
            return customer != null && customer.Password == password;
        }

        public List<Book> GetBooksTakenByCustomer(Customer customer)
        {
            
            return customer.BooksTaken;
        }

        public static void TakeBookOut(Book book, int libraryCard) {
            Customer currentUser = GetCustmoerByLibraryCard(libraryCard);

            if (book.AmountInLibrary != 0)
            {
                BookService.TakeBookOut(book);
                currentUser.BooksTaken.Add(book);
                SaveCustomers();
            }
            else { MessageBox.Show("This Book is not in the Library"); }

        }

        public static void ReturnBook(Book book, int libraryCard) {
            Customer currentCustomer = GetCustmoerByLibraryCard(libraryCard);

            if (currentCustomer.BooksTaken.Any(b => b.Name == book.Name && b.BookId == book.BookId && b.AuthorId == book.AuthorId))
            {
                var bookToRemove = currentCustomer.BooksTaken.FirstOrDefault(b => b.BookId == book.BookId);
                BookService.ReturnBook(book);
                currentCustomer.BooksTaken.Remove(bookToRemove);
                SaveCustomers();
            }
            else { MessageBox.Show("you're not the user that took this book,can't return it"); }

        }
        

    }
}
