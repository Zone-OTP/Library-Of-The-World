using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibraryOfTheWorld.DattaHandlers;

namespace LibraryOfTheWorld
{
    public class Author
    {
        public int AuthorId { get;set; }
        public string Name { get; set; }
        private static int _nextId = 1;
        public Author(string name)
        {
            AuthorId = _nextId++;
            Name = name;
        }

        //public static List<Author> LoadAuthors()
        //{
        //    AuthorList = datahandler.LoadDataJson<Author>("Authors") ?? new List<Author>();
        //    return AuthorList;
        //}

        //public static void SaveAuthors()
        //{
        //    datahandler.SaveDataJson(AuthorList, "Authors");
        //}

        //public static bool DoesAuthorExists(string authorName)
        //{
        //    LoadAuthors();
        //    return AuthorList.Any(a => a.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase));
        //}

        //public static void AddAuthor(string authorName)
        //{
        //    LoadAuthors();
        //    if (DoesAuthorExists(authorName))
        //    {
        //        MessageBox.Show("Author already exists.");
        //        return;
        //    }
        //    Author newAuthor = new Author(authorName);
        //    AuthorList.Add(newAuthor);
        //    SaveAuthors();
        //}

        //public static Author GetAuthorByName(string authorName)
        //{
        //    LoadAuthors();
        //    return AuthorList.FirstOrDefault(a => a.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase));
        //}

        //public static Author GetAuthorById(int id)
        //{
        //    LoadAuthors();
        //    return AuthorList.FirstOrDefault(a => a.Id == id);
        //}

        //public static string GetAuthorNameById(int authorId)
        //{
        //    var author = AuthorList.FirstOrDefault(a => a.Id == authorId);
        //    return author != null ? author.Name : "Unknown Author";
        //}

        //public static int GetAuthorIdByName(string authorName) {
        //    var author = AuthorList.FirstOrDefault(a => a.Name == authorName);
        //    return author.Id;
        //}
    }
}