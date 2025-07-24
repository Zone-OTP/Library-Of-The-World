using System.ComponentModel.DataAnnotations;

namespace LibraryOfClasses.Classes
{
    public class PasswordReset
    {
        [Key]
        public int PasswordResetId { get; set; }
        public int CustomerId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public Customer Customer { get; set; }
    }
}
