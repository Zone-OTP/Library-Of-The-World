using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibraryOfTheWorld.Users;

namespace LibraryOfTheWorld.Classes
{
    internal class Book
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Author { get; set; }

        internal static int _nextId = 1;
        private static List<Book> BookList { get; set; } = new List<Book>();

        public Book(string name, string author)
        {
            Id = _nextId++;
            Name = name;
            Author = author;
        }
    }
    
    
}
