using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public class PasswordReset
{
    [Key]
    public int PasswordResetId { get; set; }
    public int CustomerId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}
