using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public partial class JsonData
{
    [Key]
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public string Content { get; set; } = null!;
}
