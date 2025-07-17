using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models;

public partial class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    [Column("PersonalGovermentID")]
    public string PersonalGovermentId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; } = null!;

    public int LibraryCardNumber { get; set; }
}
