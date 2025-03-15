using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfTheWorld;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryOfTheWorld.Classes
{
    public class Customer
    {
        public int CustomerId { get; }
        public string Name { get; set; }
        public long PersonalGovermentID { get; set; }
        public string Password { get; set; }
        public int LibraryCardNumber { get; set; }
        public List<Book> BooksTaken { get; set; }

        public static int _nextId = 1;

        public Customer(string name, string password, long personalGovermentID, int libraryCardNumber)
        {
            CustomerId = _nextId++;
            Name = name;
            Password = password;
            PersonalGovermentID = personalGovermentID;
            LibraryCardNumber = libraryCardNumber;
            BooksTaken = new List<Book>();
        }
    }
}
