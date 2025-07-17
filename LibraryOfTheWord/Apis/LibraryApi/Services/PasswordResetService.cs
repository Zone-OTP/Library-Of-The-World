using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class PasswordResetService
    {
        private readonly LibraryContext _context;
        public static async Task<bool> ValidateTokenAsync(string token, LibraryContext _context)
        {
            var reset = await _context.PasswordResets
                .FirstOrDefaultAsync(pr => pr.Token == token && pr.ExpiresAt > DateTime.UtcNow);
            return reset != null;
        }
        public static async Task<bool> ResetPasswordAsync(string token, string newPassword, LibraryContext _context)
        {
            var reset = await _context.PasswordResets.FirstOrDefaultAsync(pr => pr.Token == token && pr.ExpiresAt > DateTime.UtcNow);
            var customer = await CustomerService.GetCustomerById(reset.CustomerId, _context);
            if (reset == null) return false;

            customer.Password = newPassword;
            _context.PasswordResets.Remove(reset);
            await _context.SaveChangesAsync();
            return true;
        }
        public static async Task<bool> RequestSending(string email, LibraryContext _context)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
            if (customer == null)
            {
                throw new Exception("customer Not Found");
            }

            string token = Guid.NewGuid().ToString();

            var passwordReset = new PasswordReset
            {
                CustomerId = customer.CustomerId,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(30)
            };
            _context.PasswordResets.Add(passwordReset);
            _context.SaveChangesAsync();
            string resetLink = $"https://localhost:7169/reset?token={token}";
            MailingService.SendMailToResetPassword(email, resetLink);
            return true;
        }
    }
}
