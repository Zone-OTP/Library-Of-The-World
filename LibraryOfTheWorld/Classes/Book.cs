using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LibraryOfTheWorld.DattaHandlers;
using LibraryOfTheWorld.Users;
using LibraryOfTheWorld;
using LibraryOfTheWorld.Services;
using LibraryOfTheWorld.Classes;

namespace LibraryOfTheWorld
{
    public class Book
    {
        public int BookId { get; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int AmountInLibrary { get; set; }
        public int TotalAmountInLibrary { get; set; }

        public string AuthorName
        {
            get
            {
                return AuthorService.GetAuthorNameById(AuthorId);
            }
        }

        private static int _nextId = 1;
        public Book(string name, int authorId)
        {
            BookId = _nextId++;
            Name = name;
            AuthorId = authorId;
        }
    }
}
