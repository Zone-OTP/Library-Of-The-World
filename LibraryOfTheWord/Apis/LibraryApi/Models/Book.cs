using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models;

public partial class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int BookId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int AuthorId { get; set; }

    [Required]
    public int AmountInLibrary { get; set; }

    [Required]
    public int TotalAmountInLibrary { get; set; }
}
