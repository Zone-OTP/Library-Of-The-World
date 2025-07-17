using System.ComponentModel.DataAnnotations;

namespace LibraryOfTheWorld.Classes
{
    internal class PasswordReset
    {
        [Key]
        public int PasswordResetId { get; set; }
        public int CustomerId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public Customer Customer { get; set; }
    }
}
