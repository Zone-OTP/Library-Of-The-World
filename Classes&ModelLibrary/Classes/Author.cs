using System.ComponentModel.DataAnnotations;

namespace LibraryOfClasses.Classes
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