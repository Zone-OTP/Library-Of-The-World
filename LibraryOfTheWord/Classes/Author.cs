using System.ComponentModel.DataAnnotations;

namespace LibraryOfTheWorld.Classes
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public Author(string name)
        {
            Name = name;
        }

        public Author() { }

    }
}