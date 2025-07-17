using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models;

public partial class Admin
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int AdminId { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
}
