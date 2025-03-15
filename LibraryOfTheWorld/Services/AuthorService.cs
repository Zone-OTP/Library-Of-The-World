using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryOfTheWorld.DattaHandlers;

namespace LibraryOfTheWorld.Services
{
    public class AuthorService
    {

        private static List<Author> authorList;
        private static JsonUsersDataHandler dataHandler;
        public static int _nextId = 1;
        static AuthorService()
        {
            dataHandler = new JsonUsersDataHandler();
            authorList = dataHandler.LoadDataJson<Author>("Authors") ;
        }

        public static List<Author> LoadAuthors()
        {
            authorList = dataHandler.LoadDataJson<Author>("Authors") ;
            return authorList;
        }

        public static void SaveAuthors()
        {
            dataHandler.SaveDataJson(authorList, "Authors");
        }

        public static bool DoesAuthorExists(string authorName)
        {
            LoadAuthors();
            return authorList.Any(a => a.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase));
        }

        public static void AddAuthor(string authorName)
        {
            LoadAuthors();
            if (DoesAuthorExists(authorName))
            {
                MessageBox.Show("Author already exists.");
                return;
            }
            Author newAuthor = new Author(authorName);
            authorList.Add(newAuthor);
            SaveAuthors();
        }

        public static Author GetAuthorByName(string authorName)
        {
            return authorList.FirstOrDefault(a => a.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase));
        }

        public static Author GetAuthorById(int id)
        {
            return authorList.FirstOrDefault(a => a.AuthorId == id);
        }

        public static string GetAuthorNameById(int authorId)
        {
            var author = authorList.FirstOrDefault(a => a.AuthorId == authorId);
            return author != null ? author.Name : "Unknown Author";
        }

        public static int GetAuthorIdByName(string authorName)
        {
            var author = authorList.FirstOrDefault(a => a.Name == authorName);
            return author.AuthorId;
        }
    }
}
