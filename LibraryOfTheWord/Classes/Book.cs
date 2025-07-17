using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LibraryOfTheWorld.Services;

namespace LibraryOfTheWorld.Classes
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public int AmountInLibrary { get; set; }
        public int TotalAmountInLibrary { get; set; }
        [JsonIgnore]
        public List<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();

        [JsonIgnore]
        public Task<string> AuthorName
        {
            get
            {
                return AuthorService.GetAuthorNameById(AuthorId);
            }
        }


        public Book(string name, int authorId)
        {
            Name = name;
            AuthorId = authorId;
        }
        public Book() { }
    }
}
