using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryOfClasses.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PersonalGovermentID { get; set; }
        public string Password { get; set; }
        public int LibraryCardNumber { get; set; }
        public string Email { get; set; }
        public List<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();

        
        public Customer(string name, string password, string personalGovermentID, string email)
        {
            Name = name;
            Password = password;
            PersonalGovermentID = personalGovermentID;
            Email = email;
        }

        public Customer() { }
    }
}
